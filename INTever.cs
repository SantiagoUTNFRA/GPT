namespace EventInterpreter
{
    public class Interpreter
    {
        public class EventBaseInfo
        {
            public string Action;
            public string Code;
            public int Index;
        }

        public class ExtensionInfo
        {
            public string EventLongID;
        }

        public class BinarizedPlateInfo
        {
            public int Height;
            public int Length;
            public int Offset;
            public int Width;
        }

        public class VehicleBodyInfo
        {
            public int Height;
            public int Length;
            public int Offset;
            public int Width;
        }

        public class CommInfo
        {
            public string Country;
            public int ParkType;
            public string Province;
            public string SnapCategory;
            public VehicleBodyInfo VehicleBody;
            public string VehicleTypeInTollStation;
            public BinarizedPlateInfo BinarizedPlate;
        }

        public class ImageInfo
        {
            public int Height;
            public int Length;
            public int Offset;
            public int Width;
        }

        public class MainSeatInfo
        {
            public string DriverCalling;
            public string DriverSmoking;
            public string SafeBelt;
        }

        public class SlaveSeatInfo
        {
            public string DriverCalling;
            public string DriverSmoking;
            public string SafeBelt;
        }

        public class ObjectInfo
        {
            public string Action;
            public int[] BoundingBox;
            public string Category;
            public int[] Center;
            public int Confidence;
            public string Country;
            public ImageInfo Image;
            public int[] MainColor;
            public MainSeatInfo MainSeat;
            public int ObjectID;
            public string ObjectType;
            public int[] OriginalBoundingBox;
            public string Province;
            public int RelativeID;
            public SlaveSeatInfo SlaveSeat;
            public int Speed;
            public string Text;
            public int TrackType;
            public int ValidAnalyseAttributes;
            public int FrameSequence;
            public double Source;
        }

        public class SceneImageInfo
        {
            public int Length;
            public int Offset;
        }

        public class BlackListInfo
        {
            public bool Enable;
        }
        public class TrafficCarInfo
        {
            public BlackListInfo BlackList;
            public double CapTime;
            public string CarType;
            public int CountInGroup;
            public string Country;
            public string CustomRoadwayDirection;
            public string DefendCode;
            public string DetailedAddress;
            public string DeviceAddress;
            public int Direction;
            public string[] DrivingDirection;
            public string Event;
            public int GroupID;
            public int IndexInGroup;
            public int Lane;
            public int LowerSpeedLimit;
            public string MachineAddress;
            public string MachineName;
            public int OverSpeedMargin;
            public int PhysicalLane;
            public string PlateColor;
            public string PlateNumber;
            public string PlateType;
            public string RoadwayNo;
            public string RouteNo;
            public int UnderSpeedMargin;
            public int UpperSpeedLimit;
            public string VehicleColor;
            public string VehicleSign;
            public string VehicleSize;
            public WhiteListInfo WhiteList;
            public int LaneDescription;
            public int Speed;
        }

        public class WhiteListInfo
        {
            public bool Enable;
            public bool TrustCar;
        }

        public class VehicleInfo
        {
            public string Action;
            public int[] BoundingBox;
            public int CarLogoIndex;
            public string Category;
            public int[] Center;
            public int Confidence;
            public int HeadDirection;
            public int[] MainColor;
            public int ObjectID;
            public string ObjectType;
            public int[] OriginalBoundingBox;
            public int RelativeID;
            public int Speed;
            public string SubText;
            public string Text;
            public int ValidAnalyseAttributes;
            public string VehicleDirection;
            public string VehicleTypeInTollStation;
            public bool ShotFrame;
            public double Source;
        }

        public class YuvPacketInfo
        {
            public ulong AddrU;
            public ulong AddrV;
            public ulong AddrY;
            public int Format;
            public uint FrmSeq;
            public int Height;
            public uint PhyAddrU;
            public uint PhyAddrV;
            public uint PhyAddrY;
            public int Priv;
            public int SourceType;
            public int[] Stride;
            public int Width;
            public ulong YuvPts;
        }

        public class EventInfo
        {
            public EventBaseInfo EventBaseInfo;
            public CommInfo CommInfo;
            public ObjectInfo Object;
            public SceneImageInfo SceneImage;
            public TrafficCarInfo TrafficCar;
            public VehicleInfo Vehicle;
            public YuvPacketInfo YuvPacket;
            public ExtensionInfo Extension;
            public string Action;
            public string Class;
            public string Code;
            public int CountInGroup;
            public int DSTTune;
            public int[][] DetectRegion;
            public int EncodeSequence;
            public int EncodeTimes;
            public int EventID;
            public int FrameSequence;
            public int FrameStamp;
            public int GroupID;
            public int Index;
            public int IndexInGroup;
            public string JunctionDirection;
            public int Lane;
            public int Mark;
            public string Name;
            public int ObjectID;
            public string OpenStrobeState;
            public double PTS;
            public int RuleId;
            public int Sequence;
            public double Source;
            public int TimeZone;
            public int TriggerType;
            public int UTC;
            public int UTCMS;
            public string VehicleDirection;
            public int VehicleHeadDirection;
            public int ViolationSnapSource;
            public string Direction;
            public bool NotSend;
            public int[] OSDFormat;
            public int PicType;
            public double RadarSpeedSetTime;
            public double RadarSpeedSourceTime;
            public int Speed;

        }

        public static EventInfo GetEventFields(string info)
        {
            // Inicializo las estructuras
            EventInfo eventInfo = new EventInfo();
            eventInfo.EventBaseInfo = new EventBaseInfo();
            eventInfo.CommInfo = new CommInfo();
            eventInfo.CommInfo.VehicleBody = new VehicleBodyInfo();
            eventInfo.CommInfo.BinarizedPlate = new BinarizedPlateInfo();
            eventInfo.SceneImage = new SceneImageInfo();
            eventInfo.Extension = new ExtensionInfo();
            eventInfo.Object = new ObjectInfo();
            eventInfo.Object.Image = new ImageInfo();
            eventInfo.Object.MainSeat = new MainSeatInfo();
            eventInfo.Object.SlaveSeat = new SlaveSeatInfo();
            eventInfo.Vehicle = new VehicleInfo();
            eventInfo.TrafficCar = new TrafficCarInfo();
            eventInfo.TrafficCar.WhiteList = new WhiteListInfo();
            eventInfo.TrafficCar.BlackList = new BlackListInfo();
            eventInfo.YuvPacket = new YuvPacketInfo();

            // Inicializo los arreglos
            eventInfo.DetectRegion = new int[4][];
            eventInfo.DetectRegion[0] = new int[2];
            eventInfo.DetectRegion[1] = new int[2];
            eventInfo.DetectRegion[2] = new int[2];
            eventInfo.DetectRegion[3] = new int[2];
            eventInfo.OSDFormat = new int[2];
            eventInfo.Object.BoundingBox = new int[4];
            eventInfo.Object.OriginalBoundingBox = new int[4];
            eventInfo.Object.Center = new int[2];
            eventInfo.Object.MainColor = new int[4];
            eventInfo.Vehicle.BoundingBox = new int[4];
            eventInfo.Vehicle.OriginalBoundingBox = new int[4];
            eventInfo.Vehicle.Center = new int[2];
            eventInfo.Vehicle.MainColor = new int[4];
            eventInfo.TrafficCar.DrivingDirection = new string[3];
            eventInfo.YuvPacket.Stride = new int[3];

            using (StringReader stringReader = new StringReader(info))
            {
                string line;

                while ((line = stringReader.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    string propName = parts[0];
                    string propValue = parts[1];

                    switch (propName)
                    {
                        case "Events[0].Action":
                            eventInfo.Action = propValue;
                            break;
                        case "Events[0].Class":
                            eventInfo.Class = propValue;
                            break;
                        case "Events[0].Code":
                            eventInfo.Code = propValue;
                            break;
                        case "Events[0].CommInfo.BinarizedPlate.Height":
                            eventInfo.CommInfo.BinarizedPlate.Height = int.Parse(propValue);
                            break;
                        case "Events[0].CommInfo.BinarizedPlate.Length":
                            eventInfo.CommInfo.BinarizedPlate.Length = int.Parse(propValue);
                            break;
                        case "Events[0].CommInfo.BinarizedPlate.Offset":
                            eventInfo.CommInfo.BinarizedPlate.Offset = int.Parse(propValue);
                            break;
                        case "Events[0].CommInfo.BinarizedPlate.Width":
                            eventInfo.CommInfo.BinarizedPlate.Width = int.Parse(propValue);
                            break;
                        case "Events[0].CommInfo.Country":
                            eventInfo.CommInfo.Country = propValue;
                            break;
                        case "Events[0].CommInfo.ParkType":
                            eventInfo.CommInfo.ParkType = int.Parse(propValue);
                            break;
                        case "Events[0].CommInfo.Province":
                            eventInfo.CommInfo.Province = propValue;
                            break;
                        case "Events[0].CommInfo.SnapCategory":
                            eventInfo.CommInfo.SnapCategory = propValue;
                            break;
                        case "Events[0].CommInfo.VehicleTypeInTollStation":
                            eventInfo.CommInfo.VehicleTypeInTollStation = propValue;
                            break;
                        case "Events[0].CountInGroup":
                            eventInfo.CountInGroup = int.Parse(propValue);
                            break;
                        case "Events[0].DSTTune":
                            eventInfo.DSTTune = int.Parse(propValue);
                            break;
                        case "Events[0].Direction":
                            eventInfo.Direction = propValue;
                            break;
                        case "Events[0].DetectRegion[0][0]":
                            eventInfo.DetectRegion[0][0] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[0][1]":
                            eventInfo.DetectRegion[0][1] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[1][0]":
                            eventInfo.DetectRegion[1][0] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[1][1]":
                            eventInfo.DetectRegion[1][1] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[2][0]":
                            eventInfo.DetectRegion[2][0] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[2][1]":
                            eventInfo.DetectRegion[2][1] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[3][0]":
                            eventInfo.DetectRegion[3][0] = int.Parse(propValue);
                            break;
                        case "Events[0].DetectRegion[3][1]":
                            eventInfo.DetectRegion[3][1] = int.Parse(propValue);
                            break;
                        case "Events[0].EncodeSequence":
                            eventInfo.EncodeSequence = int.Parse(propValue);
                            break;
                        case "Events[0].EncodeTimes":
                            eventInfo.EncodeTimes = int.Parse(propValue);
                            break;
                        case "Events[0].EventBaseInfo.Action":
                            eventInfo.EventBaseInfo.Action = propValue;
                            break;
                        case "Events[0].EventBaseInfo.Code":
                            eventInfo.EventBaseInfo.Code = propValue;
                            break;
                        case "Events[0].EventBaseInfo.Index":
                            eventInfo.EventBaseInfo.Index = int.Parse(propValue);
                            break;
                        case "Events[0].EventID":
                            eventInfo.EventID = int.Parse(propValue);
                            break;
                        case "Events[0].Extension.EventLongID":
                            eventInfo.Extension.EventLongID = propValue;
                            break;
                        case "Events[0].FrameSequence":
                            eventInfo.FrameSequence = int.Parse(propValue);
                            break;
                        case "Events[0].FrameStamp":
                            eventInfo.FrameStamp = int.Parse(propValue);
                            break;
                        case "Events[0].GroupID":
                            eventInfo.GroupID = int.Parse(propValue);
                            break;
                        case "Events[0].Index":
                            eventInfo.Index = int.Parse(propValue);
                            break;
                        case "Events[0].IndexInGroup":
                            eventInfo.IndexInGroup = int.Parse(propValue);
                            break;
                        case "Events[0].JunctionDirection":
                            eventInfo.JunctionDirection = propValue;
                            break;
                        case "Events[0].Lane":
                            eventInfo.Lane = int.Parse(propValue);
                            break;
                        case "Events[0].Mark":
                            eventInfo.Mark = int.Parse(propValue);
                            break;
                        case "Events[0].Name":
                            eventInfo.Name = propValue;
                            break;
                        case "Events[0].NotSend":
                            eventInfo.NotSend = bool.Parse(propValue);
                            break;
                        case "Events[0].OSDFormat[0]":
                            eventInfo.OSDFormat[0] = int.Parse(propValue);
                            break;
                        case "Events[0].OSDFormat[1]":
                            eventInfo.OSDFormat[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Action":
                            eventInfo.Object.Action = propValue;
                            break;
                        case "Events[0].Object.BoundingBox[0]":
                            eventInfo.Object.BoundingBox[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.BoundingBox[1]":
                            eventInfo.Object.BoundingBox[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.BoundingBox[2]":
                            eventInfo.Object.BoundingBox[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.BoundingBox[3]":
                            eventInfo.Object.BoundingBox[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Category":
                            eventInfo.Object.Category = propValue;
                            break;
                        case "Events[0].Object.Center[0]":
                            eventInfo.Object.Center[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Center[1]":
                            eventInfo.Object.Center[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Confidence":
                            eventInfo.Object.Confidence = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Country":
                            eventInfo.Object.Country = propValue;
                            break;
                        case "Events[0].Object.FrameSequence":
                            eventInfo.Object.FrameSequence = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Image.Height":
                            eventInfo.Object.Image.Height = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Image.Length":
                            eventInfo.Object.Image.Length = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Image.Offset":
                            eventInfo.Object.Image.Offset = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Image.Width":
                            eventInfo.Object.Image.Width = int.Parse(propValue);
                            break;
                        case "Events[0].Object.MainColor[0]":
                            eventInfo.Object.MainColor[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.MainColor[1]":
                            eventInfo.Object.MainColor[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.MainColor[2]":
                            eventInfo.Object.MainColor[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.MainColor[3]":
                            eventInfo.Object.MainColor[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.MainSeat.DriverCalling":
                            eventInfo.Object.MainSeat.DriverCalling = propValue;
                            break;
                        case "Events[0].Object.MainSeat.DriverSmoking":
                            eventInfo.Object.MainSeat.DriverSmoking = propValue;
                            break;
                        case "Events[0].Object.MainSeat.SafeBelt":
                            eventInfo.Object.MainSeat.SafeBelt = propValue;
                            break;
                        case "Events[0].Object.ObjectID":
                            eventInfo.Object.ObjectID = int.Parse(propValue);
                            break;
                        case "Events[0].Object.ObjectType":
                            eventInfo.Object.ObjectType = propValue;
                            break;
                        case "Events[0].Object.OriginalBoundingBox[0]":
                            eventInfo.Object.OriginalBoundingBox[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.OriginalBoundingBox[1]":
                            eventInfo.Object.OriginalBoundingBox[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.OriginalBoundingBox[2]":
                            eventInfo.Object.OriginalBoundingBox[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.OriginalBoundingBox[3]":
                            eventInfo.Object.OriginalBoundingBox[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Province":
                            eventInfo.Object.Province = propValue;
                            break;
                        case "Events[0].Object.RelativeID":
                            eventInfo.Object.RelativeID = int.Parse(propValue);
                            break;
                        case "Events[0].Object.SlaveSeat.DriverCalling":
                            eventInfo.Object.SlaveSeat.DriverCalling = propValue;
                            break;
                        case "Events[0].Object.SlaveSeat.DriverSmoking":
                            eventInfo.Object.SlaveSeat.DriverSmoking = propValue;
                            break;
                        case "Events[0].Object.Source":
                            eventInfo.Object.Source = double.Parse(propValue);
                            break;
                        case "Events[0].Object.SlaveSeat.SafeBelt":
                            eventInfo.Object.SlaveSeat.SafeBelt = propValue;
                            break;
                        case "Events[0].Object.Speed":
                            eventInfo.Object.Speed = int.Parse(propValue);
                            break;
                        case "Events[0].Object.Text":
                            eventInfo.Object.Text = propValue;
                            break;
                        case "Events[0].Object.TrackType":
                            eventInfo.Object.TrackType = int.Parse(propValue);
                            break;
                        case "Events[0].Object.ValidAnalyseAttributes":
                            eventInfo.Object.ValidAnalyseAttributes = int.Parse(propValue);
                            break;
                        case "Events[0].ObjectID":
                            eventInfo.ObjectID = int.Parse(propValue);
                            break;
                        case "Events[0].OpenStrobeState":
                            eventInfo.OpenStrobeState = propValue;
                            break;
                        case "Events[0].PTS":
                            eventInfo.PTS = double.Parse(propValue);
                            break;
                        case "Events[0].RuleId":
                            eventInfo.RuleId = int.Parse(propValue);
                            break;
                        case "Events[0].PicType":
                            eventInfo.PicType = int.Parse(propValue);
                            break;
                        case "Events[0].SceneImage.Length":
                            eventInfo.SceneImage.Length = int.Parse(propValue);
                            break;
                        case "Events[0].SceneImage.Offset":
                            eventInfo.SceneImage.Offset = int.Parse(propValue);
                            break;
                        case "Events[0].RadarSpeedSetTime":
                            eventInfo.RadarSpeedSetTime = double.Parse(propValue);
                            break;
                        case "Events[0].RadarSpeedSourceTime":
                            eventInfo.RadarSpeedSourceTime = double.Parse(propValue);
                            break;
                        case "Events[0].Sequence":
                            eventInfo.Sequence = int.Parse(propValue);
                            break;
                        case "Events[0].Source":
                            eventInfo.Source = double.Parse(propValue);
                            break;
                        case "Events[0].Speed":
                            eventInfo.Speed = int.Parse(propValue);
                            break;
                        case "Events[0].TimeZone":
                            eventInfo.TimeZone = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.BlackList.Enable":
                            eventInfo.TrafficCar.BlackList.Enable = bool.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.CapTime":
                            eventInfo.TrafficCar.CapTime = double.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.CarType":
                            eventInfo.TrafficCar.CarType = propValue;
                            break;
                        case "Events[0].TrafficCar.CountInGroup":
                            eventInfo.TrafficCar.CountInGroup = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.Country":
                            eventInfo.TrafficCar.Country = propValue;
                            break;
                        case "Events[0].TrafficCar.CustomRoadwayDirection":
                            eventInfo.TrafficCar.CustomRoadwayDirection = propValue;
                            break;
                        case "Events[0].TrafficCar.DefendCode":
                            eventInfo.TrafficCar.DefendCode = propValue;
                            break;
                        case "Events[0].TrafficCar.DetailedAddress":
                            eventInfo.TrafficCar.DetailedAddress = propValue;
                            break;
                        case "Events[0].TrafficCar.DeviceAddress":
                            eventInfo.TrafficCar.DeviceAddress = propValue;
                            break;
                        case "Events[0].TrafficCar.Direction":
                            eventInfo.TrafficCar.Direction = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.DrivingDirection[0]":
                            eventInfo.TrafficCar.DrivingDirection[0] = propValue;
                            break;
                        case "Events[0].TrafficCar.DrivingDirection[1]":
                            eventInfo.TrafficCar.DrivingDirection[1] = propValue;
                            break;
                        case "Events[0].TrafficCar.DrivingDirection[2]":
                            eventInfo.TrafficCar.DrivingDirection[2] = propValue;
                            break;
                        case "Events[0].TrafficCar.Event":
                            eventInfo.TrafficCar.Event = propValue;
                            break;
                        case "Events[0].TrafficCar.GroupID":
                            eventInfo.TrafficCar.GroupID = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.IndexInGroup":
                            eventInfo.TrafficCar.IndexInGroup = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.Lane":
                            eventInfo.TrafficCar.Lane = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.LaneDescription":
                            eventInfo.TrafficCar.LaneDescription = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.LowerSpeedLimit":
                            eventInfo.TrafficCar.LowerSpeedLimit = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.MachineAddress":
                            eventInfo.TrafficCar.MachineAddress = propValue;
                            break;
                        case "Events[0].TrafficCar.MachineName":
                            eventInfo.TrafficCar.MachineName = propValue;
                            break;
                        case "Events[0].TrafficCar.OverSpeedMargin":
                            eventInfo.TrafficCar.OverSpeedMargin = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.PhysicalLane":
                            eventInfo.TrafficCar.PhysicalLane = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.PlateColor":
                            eventInfo.TrafficCar.PlateColor = propValue;
                            break;
                        case "Events[0].TrafficCar.PlateNumber":
                            eventInfo.TrafficCar.PlateNumber = propValue;
                            break;
                        case "Events[0].TrafficCar.PlateType":
                            eventInfo.TrafficCar.PlateType = propValue;
                            break;
                        case "Events[0].TrafficCar.RoadwayNo":
                            eventInfo.TrafficCar.RoadwayNo = propValue;
                            break;
                        case "Events[0].TrafficCar.RouteNo":
                            eventInfo.TrafficCar.RouteNo = propValue;
                            break;
                        case "Events[0].TrafficCar.Speed":
                            eventInfo.TrafficCar.Speed = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.UnderSpeedMargin":
                            eventInfo.TrafficCar.UnderSpeedMargin = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.UpperSpeedLimit":
                            eventInfo.TrafficCar.UpperSpeedLimit = int.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.VehicleColor":
                            eventInfo.TrafficCar.VehicleColor = propValue;
                            break;
                        case "Events[0].TrafficCar.VehicleSign":
                            eventInfo.TrafficCar.VehicleSign = propValue;
                            break;
                        case "Events[0].TrafficCar.VehicleSize":
                            eventInfo.TrafficCar.VehicleSize = propValue;
                            break;
                        case "Events[0].TrafficCar.WhiteList.Enable":
                            eventInfo.TrafficCar.WhiteList.Enable = bool.Parse(propValue);
                            break;
                        case "Events[0].TrafficCar.WhiteList.TrustCar":
                            eventInfo.TrafficCar.WhiteList.TrustCar = bool.Parse(propValue);
                            break;
                        case "Events[0].TriggerType":
                            eventInfo.TriggerType = int.Parse(propValue);
                            break;
                        case "Events[0].UTC":
                            eventInfo.UTC = int.Parse(propValue);
                            break;
                        case "Events[0].UTCMS":
                            eventInfo.UTCMS = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Action":
                            eventInfo.Vehicle.Action = propValue;
                            break;
                        case "Events[0].Vehicle.BoundingBox[0]":
                            eventInfo.Vehicle.BoundingBox[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.BoundingBox[1]":
                            eventInfo.Vehicle.BoundingBox[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.BoundingBox[2]":
                            eventInfo.Vehicle.BoundingBox[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.BoundingBox[3]":
                            eventInfo.Vehicle.BoundingBox[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.CarLogoIndex":
                            eventInfo.Vehicle.CarLogoIndex = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Category":
                            eventInfo.Vehicle.Category = propValue;
                            break;
                        case "Events[0].Vehicle.Center[0]":
                            eventInfo.Vehicle.Center[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Center[1]":
                            eventInfo.Vehicle.Center[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Confidence":
                            eventInfo.Vehicle.Confidence = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.HeadDirection":
                            eventInfo.Vehicle.HeadDirection = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.MainColor[0]":
                            eventInfo.Vehicle.MainColor[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.MainColor[1]":
                            eventInfo.Vehicle.MainColor[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.MainColor[2]":
                            eventInfo.Vehicle.MainColor[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.MainColor[3]":
                            eventInfo.Vehicle.MainColor[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.ObjectID":
                            eventInfo.Vehicle.ObjectID = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.ObjectType":
                            eventInfo.Vehicle.ObjectType = propValue;
                            break;
                        case "Events[0].Vehicle.OriginalBoundingBox[0]":
                            eventInfo.Vehicle.OriginalBoundingBox[0] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.OriginalBoundingBox[1]":
                            eventInfo.Vehicle.OriginalBoundingBox[1] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.OriginalBoundingBox[2]":
                            eventInfo.Vehicle.OriginalBoundingBox[2] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.OriginalBoundingBox[3]":
                            eventInfo.Vehicle.OriginalBoundingBox[3] = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.RelativeID":
                            eventInfo.Vehicle.RelativeID = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Speed":
                            eventInfo.Vehicle.Speed = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.ShotFrame":
                            eventInfo.Vehicle.ShotFrame = bool.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.Source":
                            eventInfo.Vehicle.Source = double.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.SubText":
                            eventInfo.Vehicle.SubText = propValue;
                            break;
                        case "Events[0].Vehicle.Text":
                            eventInfo.Vehicle.Text = propValue;
                            break;
                        case "Events[0].Vehicle.ValidAnalyseAttributes":
                            eventInfo.Vehicle.ValidAnalyseAttributes = int.Parse(propValue);
                            break;
                        case "Events[0].Vehicle.VehicleDirection":
                            eventInfo.Vehicle.VehicleDirection = propValue;
                            break;
                        case "Events[0].Vehicle.VehicleTypeInTollStation":
                            eventInfo.Vehicle.VehicleTypeInTollStation = propValue;
                            break;
                        case "Events[0].VehicleDirection":
                            eventInfo.VehicleDirection = propValue;
                            break;
                        case "Events[0].VehicleHeadDirection":
                            eventInfo.VehicleHeadDirection = int.Parse(propValue);
                            break;
                        case "Events[0].ViolationSnapSource":
                            eventInfo.ViolationSnapSource = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.AddrU":
                            eventInfo.YuvPacket.AddrU = ulong.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.AddrV":
                            eventInfo.YuvPacket.AddrV = ulong.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.AddrY":
                            eventInfo.YuvPacket.AddrY = ulong.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Format":
                            eventInfo.YuvPacket.Format = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.FrmSeq":
                            eventInfo.YuvPacket.FrmSeq = uint.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Height":
                            eventInfo.YuvPacket.Height = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.PhyAddrU":
                            eventInfo.YuvPacket.PhyAddrU = uint.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.PhyAddrV":
                            eventInfo.YuvPacket.PhyAddrV = uint.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.PhyAddrY":
                            eventInfo.YuvPacket.PhyAddrY = uint.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Priv":
                            eventInfo.YuvPacket.Priv = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.SourceType":
                            eventInfo.YuvPacket.SourceType = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Stride[0]":
                            eventInfo.YuvPacket.Stride[0] = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Stride[1]":
                            eventInfo.YuvPacket.Stride[1] = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Stride[2]":
                            eventInfo.YuvPacket.Stride[2] = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.Width":
                            eventInfo.YuvPacket.Width = int.Parse(propValue);
                            break;
                        case "Events[0].YuvPacket.YuvPts":
                            eventInfo.YuvPacket.YuvPts = ulong.Parse(propValue);
                            break;
                    }
                }
            }
            return eventInfo;
        }

        public static void SaveSnapShot(string snapPath, string snapName, byte[] snapBytes)
        {
            if (snapPath != string.Empty && snapName != string.Empty)
            {

                if (!Directory.Exists(snapPath))
                {
                    Directory.CreateDirectory(snapPath);
                }
                File.WriteAllBytes(Path.Combine(snapPath, snapName), snapBytes);
            }
            else
            {
                Console.WriteLine("ERROR: Directorio o nombre de archivo incorrecto!");
            }
        }
    }
}   