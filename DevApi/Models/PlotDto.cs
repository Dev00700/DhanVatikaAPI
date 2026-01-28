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
        public string Plot_Code { get; set; }
        public string SubPlotCode { get; set; }
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
    public class PlotResponseDto:BaseDto
    {
        public Guid PlotGuid { get; set; }
        public long PlotId { get; set; }
        public string PlotCode { get; set; }
        public string Plot_Code { get; set; }
        public string SubPlotCode { get; set; }
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
        public string Plot_Code { get; set; }
        public string SubPlotCode { get; set; }
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
        public string? Facing { get; set; }

    }
    public class PlotForCustomerResponseDto
    {
        public Guid PlotGuid { get; set; }
        public long PlotId { get; set; }
        public string PlotCode { get; set; }
        public string SubPlotCode { get; set; }
        public string Plot_Code { get; set; }
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
        public string? NewRemarks { get; set; }
        public bool? IsRejected { get; set; }
          public List<PlotImageDto>? PlotImage { get; set; }
        public Guid? PlotImageGuid { get; set; }
        public DateTime? PaymentDate { get; set; }


        public string? PaymentDetails { get; set; }
        public List<CustomerPlotPaymentDto>? CustomerPlotPaymentList { get; set; }
        
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

    public class PlotAndCustomerEmiReqDto
    {
        public long PlotId { get; set; }
        public long CustomerId { get; set; }
    }
    public class PlotAndCustomerEmiResDto
    {
        public long CustomerPaymentId { get; set; }
        public long CustomerId { get; set; }
        public long PlotId { get; set; }
        public int EmiNo { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime EmiDate { get; set; }
        public bool IsPaid { get; set; }
        public string Remarks { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string PlotName { get; set; }
        public string PlotCode { get; set; }
        public string Plot_Code { get; set; }
        public string SubPlotCode { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PreviousDue { get; set; }
        public decimal TotalPendingAmount { get; set; }
        public bool isrejected { get; set; }
        public string newremarks { get; set; }
    }

    public class CustomerReceiptReqDto
    {
        public long CustomerId { get; set; }
        public long PlotId { get; set; }
        public long CustomerPaymentId { get; set; }
    }
    public class CustomerReceiptResDto
    {
        public int EmiNo { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime EMIDate { get; set; }
        public DateTime PaidDate { get; set; }
        public string CustomerName { get; set; }
        public string PlotCode { get; set; }
        public string SubPlotCode { get; set; }
        public string Plot_Code { get; set; }
        public string PlotName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
       
    }
}


