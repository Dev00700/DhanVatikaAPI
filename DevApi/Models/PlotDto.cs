using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;

namespace DevApi.Models
{
    public class PlotDto : BaseDto
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
        public bool? IsShowONWeb { get; set; }
        public string? Amenities { get; set; }

    }
    public class PlotReqDto
    {
        public Guid PlotGuid { get; set; }
    }
    public class PlotSerchDto
    {
        public string? PlotName { get; set; }
        public string? PlotType { get; set; }
        public int? LocationId { get; set; }
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

        public string? LocationName { get; set; }
        public string? UnitTypeName { get; set; }
        public bool? IsShowONWeb { get; set; }
        public string? Amenities { get; set; }
        public string? Image { get; set; }
        public List<PlotImageDto>? PlotImage { get; set; }
    }

    public class plotAddResDto : ValidationMessageDto
    {
        public long PlotId { get; set; }
    }

    public class LocationDto
    {
        public Guid LocationGuid { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string? Image { get; set; }
        public int? TotalPlot { get; set; }
    }

    public class PtotWebReq
    {
        public int LocationId { get; set; }
        public int PLotId { get; set; }

    }

    public class PlotWebResponseDto
    {
        public Guid PlotGuid { get; set; }
        public long PlotId { get; set; }
        public string PlotCode { get; set; }
        public string PlotName { get; set; }
        public string Description { get; set; }

        public decimal AreaSize { get; set; }
        public int Status { get; set; }
        public string PlotStatus
        {
            get
            {
                return Enum.IsDefined(typeof(PlotStatusEnum), Status)
                    ? ((PlotStatusEnum)Status).ToString()
                    : string.Empty;
            }
        }

        public string? UnitTypeName { get; set; }
        public bool? IsShowONWeb { get; set; }
        public string? Amenities { get; set; }

    }
    public class PlotForCustomerResponseDto
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

        public string? LocationName { get; set; }
        public string? UnitTypeName { get; set; }
        public bool? IsShowONWeb { get; set; }
        public string? Amenities { get; set; }
        public string? Image { get; set; }
        public decimal? Amount { get; set; }
        public string? Remarks { get; set; }
          public List<PlotImageDto>? PlotImage { get; set; }
        public Guid? PlotImageGuid { get; set; }
        public DateTime? PaymentDate { get; set; }
     



    }

    public class PlotForCustomerRequestDto
    {
        public long CustomerId
        {
            get; set;
        }
    }

    public class PLotWiseCustomerPaymentReqDto
    {
               public long PlotId { get; set; }
               public long CustomerId { get; set; }
    }
    public class PLotWiseCustomerPaymentResDto
    {
        public long PlotId { get; set; }
        public long CustomerId { get; set; }
        public decimal Amount { get; set; }
        public decimal AreaSize { get; set; }

        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string PlotName { get; set; }
        public string unitname { get; set; }

        public DateTime CreatedOn { get; set; }
        
    }
}

