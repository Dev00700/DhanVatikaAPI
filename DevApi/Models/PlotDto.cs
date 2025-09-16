using DevApi.Models.Enums;
using MyApp.Models.Common;

namespace DevApi.Models
{
    public class PlotDto:BaseDto
    {

        public Guid? PlotGuid { get; set; }
        public long? PlotId { get; set; }
        public string PlotName { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal AreaSize { get; set; }
        public int UnitTypeId { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string Facing { get; set; }
        public string PlotType { get; set; }
        public string NearbyLandmarks { get; set; }
       
    }
    public class PlotReqDto
    {
        public Guid PlotGuid { get; set; }
    }
    public class PlotResponseDto
    {
        public Guid PlotGuid { get; set; }
        public long PlotId { get; set; }
        public string PlotCode { get; set; }
        public string PlotName { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal AreaSize { get; set; }
        public int UnitTypeId { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string Facing { get; set; }
        public string PlotType { get; set; }
        public string NearbyLandmarks { get; set; }
        public string PlotStatus
        {
            get
            {
                return Enum.IsDefined(typeof(PlotStatusEnum), Status)
                    ? ((PlotStatusEnum)Status).ToString()
                    : string.Empty;
            }
        }

        public int LocationName { get; set; }
        public int UnitTypeName { get; set; }
    }
}
