
using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;
namespace DevApi.Models
{
    public class EnquiryReqDto:BaseDto
    {
       
        public long PlotId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? Remarks { get; set; }
      
    }
    public class EnquiryResDto : BaseDto
    {
        public Guid EnquiryGuid { get; set; }
        public long EnquiryId { get; set; }
        public long PlotId { get; set; }
        public string Name { get; set; }
        public string Plot_Code { get; set; }
        public string SubPlotCode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? Remarks { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public bool Closed { get; set; }
        public Guid PlotGuid { get; set; }
        public string? LocationName { get; set; }
        public string? PlotName { get; set; }
        public string? PlotCode { get; set; }
        public string? Status { get; set; }
        public int? IsCustomer { get; set; }
    }

    public class EnquiryClosedDto
    {
        public Guid EnquiryGuid { get; set; }
        public string Remarks { get; set; }
    }

    public class EnquirySerchDto
    {
        public string? LocationName { get; set; }
        public string? PlotName { get; set; }
        public string? PlotCode { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public bool? Status { get; set; }

        public DateTime? Date { get; set; }
    }
}
