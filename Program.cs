using System.Net;
using System.Text;
using EventInterpreter;
using Newtonsoft.Json;

class Program
{
    static bool shouldReset = false;
    static int intervalMilliseconds = 90000; // 90 segundos
    static Timer? timer;

    static async Task Main(string[] args)
    {
        string rutaCarpetaFotos = Path.Combine(Directory.GetCurrentDirectory(), "fotos", DateTime.Now.ToString("yyyyMMdd"));
        string rutaCarpetaData = Path.Combine(Directory.GetCurrentDirectory(), "data", DateTime.Now.ToString("yyyyMMdd"));

        timer = new Timer(TimerCallback, null, 0, intervalMilliseconds);

        Uri uri = new Uri("http://192.168.0.245/");
        var credentialCache = new CredentialCache();
        credentialCache.Add(uri, "Digest", new NetworkCredential("admin", "vialcontrol1"));

        HttpClientHandler handler = new HttpClientHandler() { Credentials = credentialCache, };

        using (HttpClient client = new HttpClient(handler))
        {
            client.BaseAddress = uri;

            string url = "cgi-bin/snapManager.cgi?action=attachFileProc&Flags[0]=Event&Events=[TrafficJunction]&heartbeat=60";
            // string url = "cgi-bin/snapManager.cgi?action=attachFileProc&Flags[0]=Event&Events=[All]&heartbeat=60";

            // Crear la carpeta "data" si no existe
            if (!Directory.Exists(rutaCarpetaData))
            {
                Directory.CreateDirectory(rutaCarpetaData);
            }

            if (!Directory.Exists(rutaCarpetaFotos))
            {
                Directory.CreateDirectory(rutaCarpetaFotos);
            }

            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using var contentStream = await response.Content.ReadAsStreamAsync();

                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int partCount = 0;
                    int bytesRead;
                    string data = string.Empty;

                    byte[] separador = Encoding.ASCII.GetBytes("\r\n\r\n");
                    int startIndex = 0; // El índice donde comienza cada parte
                    int endIndex; // El índice donde termina cada parte
                    List<byte[]> partes = new List<byte[]>(); // La lista donde se guardarán las partes

                    while ((bytesRead = contentStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                        // Hacer algo con el contenido (por ejemplo, escribirlo en un archivo)
                        File.AppendAllText("fotos/data.txt", Encoding.UTF8.GetString(buffer, 0, bytesRead));

                        for (int i = 0; i < buffer.Length - 3; i++)
                        {
                            if (buffer[i] == '\r' && buffer[i + 1] == '\n' && buffer[i + 2] == '\r' && buffer[i + 3] == '\n')
                            {
                                partCount++;
                                if (partCount == 4)
                                {
                                    while ((endIndex = IndexOf(ms.ToArray(), separador, startIndex)) != -1)
                                    {
                                        int length = endIndex - startIndex; // La longitud de la parte actual
                                        byte[] parte = new byte[length]; // El array donde se guardará la parte actual
                                        Array.Copy(ms.ToArray(), startIndex, parte, 0, length); // Copiar la parte actual
                                        startIndex = endIndex + separador.Length; // Avanzar al siguiente índice después del separador

                                        if (Encoding.UTF8.GetString(parte).Contains("Content-Length:9"))
                                        {
                                            partCount = partCount > 0 ? partCount - 1 : 0;
                                            continue;
                                        }

                                        if (Encoding.UTF8.GetString(parte).Contains("Heartbeat"))
                                        {
                                            partCount = partCount > 0 ? partCount - 1 : 0;
                                            shouldReset = true;
                                            // Console.WriteLine("Heartbeat");
                                            continue;
                                        }

                                        partes.Add(parte);
                                        if (partes.Count == 4)
                                        {
                                            string rutaCarpetaFechaActual = Path.Combine(rutaCarpetaData, DateTime.Now.ToString("yyyyMMdd"));
                                            Interpreter.EventInfo eventInfo = Interpreter.GetEventFields(Encoding.UTF8.GetString(partes[1]));
                                            
                                            string json = JsonConvert.SerializeObject(eventInfo);

                                            File.WriteAllText(Path.Combine(rutaCarpetaData, $"{eventInfo.TrafficCar.PlateNumber}_{DateTime.Now.ToString("HHmmss")}{".json"}"), json);
                                            Interpreter.SaveSnapShot(rutaCarpetaFotos, eventInfo.TrafficCar.PlateNumber + "_" + DateTime.Now.ToString("HHmmss") + ".jpg", partes[3]);
                                            Console.WriteLine("Evento: {0} / Guardado exitoso", eventInfo.Code);
                                            partes.Clear();
                                            partCount = 0;
                                        }
                                    }
                                    partCount = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        timer.Change(Timeout.Infinite, Timeout.Infinite);
        timer.Dispose();
    }

    public static int IndexOf(byte[] array, byte[] pattern, int startIndex)
    {
        int i = Array.IndexOf(array, pattern[0], startIndex);
        while (i != -1 && i <= array.Length - pattern.Length)
        {
            int j;
            for (j = 1; j < pattern.Length; j++)
            {
                if (array[i + j] != pattern[j])
                {
                    break;
                }
            }
            if (j == pattern.Length)
            {
                return i;
            }
            else
            {
                i = Array.IndexOf(array, pattern[0], i + 1);
            }
        }
        return -1;
    }

    static void TimerCallback(object state)
    {
        // Console.WriteLine("Se ha activado el temporizador.");

        if (shouldReset)
        {
            // Reiniciar el temporizador con el nuevo intervalo de tiempo
            timer.Change(intervalMilliseconds, Timeout.Infinite);
            // Console.WriteLine("Temporizador reiniciado!");

            // Restablecer la variable shouldReset
            shouldReset = false;
        }
        else
        {
            // Console.WriteLine("Camara desconectada...");
        }
    }
}
