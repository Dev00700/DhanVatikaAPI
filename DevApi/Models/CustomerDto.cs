using DevApi.Models.Common;
using MyApp.Models.Common;

namespace DevApi.Models
{
    public class CustomerReqDto:BaseDto
    {
        public Guid? CustomerGuid { get; set; }
        public long? CustomerId { get; set; }
        public long EnquiryId { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? Mobile { get; set; }
        public string? Remarks { get; set; }
        public string? Image { get; set; }
        public long? PlotId{ get; set; }
        public long? CustomerPlotId { get; set; }
    }
    public class CustomerResDto : ValidationMessageDto
    {
        public Guid? CustomerGuid { get; set; }
        public long? CustomerId { get; set; }
        public long EnquiryId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Remarks { get; set; }
        public string? Image { get; set; }
        public string? Password { get; set; }
        public bool? IsFirstLogin { get; set; }
        public int ? PlotId { get; set; }
        public int ? BookingFlag { get; set; }
        public string ? PlotName { get; set; }
        public bool ? IsActive { get; set; }
        public string ? ImageUrl { get; set; }
        public long ? CustomerPlotId { get; set; }
        public int PlotStatus { get; set; }
      
        



    }

    public class CustomerLoginReqDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UpdatePasswordReqDto
    {
        public Guid CustomerGuid { get; set; }
        public string? OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class CustomerResDtoV2 : ValidationMessageDto
    {
        public Guid? CustomerGuid { get; set; }
        public long? CustomerId { get; set; }
        public long EnquiryId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Remarks { get; set; }
        public string? Image { get; set; }
        public string? Password { get; set; }
        public bool? IsFirstLogin { get; set; }
       
        public List<customerPlotDetailV2>? PLotList { get;set; }




    }
    public class customerPlotDetailV2 
    {
    public int? PlotId { get; set; }
    public int? BookingFlag { get; set; }
    public string? PlotName { get; set; }
    public bool? IsActive { get; set; }
    public string? ImageUrl { get; set; }
    public long? CustomerPlotId { get; set; }
    public int PlotStatus { get; set; }
}

}
