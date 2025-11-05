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
    public class CustomerResDto : BaseDto
    {
        public Guid? CustomerGuid { get; set; }
        public long? CustomerId { get; set; }
        public long EnquiryId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string Remarks { get; set; }
        public string? Image { get; set; }

    }

}
