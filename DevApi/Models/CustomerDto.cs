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

}
