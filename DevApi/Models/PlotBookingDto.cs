using MyApp.Models.Common;

namespace DevApi.Models
{
    public class PlotBookingReqDto:BaseDto
    {
        public Guid BookingGuid { get; set; }
        public long BookingId { get; set; }
        public long CustomerId { get; set; }
        public long PlotId { get; set; }
        public string? CustomerName { get; set; }
        public string? Occupation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? Anniversary { get; set; }
        public string? ContactNo1 { get; set; }
        public string? ContactNo2 { get; set; }
        public string? PostalAddress { get; set; }
        public string? EmailAddress { get; set; }

        public string? ReferenceName1 { get; set; }
        public string? ReferenceContact1 { get; set; }
        public string? ReferenceName2 { get; set; }
        public string? ReferenceContact2 { get; set; }

        public string? City { get; set; }
        public string? PinCode { get; set; }
        public string? State { get; set; }
        public string? NomineeName { get; set; }
        public string? NomineeAddress { get; set; }
        public string? NomineePhoneNo { get; set; }
        public string? NomineeRelation { get; set; }
        public int? NomineeAge { get; set; }
        public string? ProjectName { get; set; }
        public string? Block { get; set; }
        public string? PlotCity { get; set; }
        public string? KhasraNo { get; set; }
        public string? PlotNo { get; set; }
        public string? PlotSize { get; set; }
        public decimal? AreaSqFt { get; set; }
        public decimal? RatePerSqFt { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TokenAmount { get; set; }
        public DateTime? DownPaymentDate { get; set; }
        public decimal? DownPaymentAmount { get; set; }
        public int? NumberOfInstallments { get; set; }
        public decimal? EMIAmount { get; set; }
        public string? Remarks { get; set; }
        public string? ExecutiveId { get; set; }
        public string? ExecutiveName { get; set; }
        public string? ExecutiveSignature { get; set; }
        public string? PurchaserName { get; set; }
        public string? PurchaserSign { get; set; }
        public string? AuthorizedSignatory { get; set; }
        public DateTime? DirectorSalesDate { get; set; }
        public string? DirectorName { get; set; }
        public string? DirectorSign { get; set; }
        public string? PANCardNumber { get; set; }
        public string? DrivingLicenseNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VoterIdNumber { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? RationCardNumber { get; set; }
        public string? PANCardImage { get; set; }
        public string? DrivingLicenseImage { get; set; }
        public string? PassportImage { get; set; }
        public string? VoterIdImage { get; set; }
        public string? AadhaarImage { get; set; }
        public string? RationCardImage { get; set; }
    }

    public class PlotBookingResponseDto : BaseDto
    {
        public Guid BookingGuid { get; set; }
        public long BookingId { get; set; }
        public long CustomerId { get; set; }
        public long PlotId { get; set; }
        public string? CustomerName { get; set; }
        public string? Occupation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? Anniversary { get; set; }
        public string? ContactNo1 { get; set; }
        public string? ContactNo2 { get; set; }
        public string? PostalAddress { get; set; }
        public string? EmailAddress { get; set; }

        public string? ReferenceName1 { get; set; }
        public string? ReferenceContact1 { get; set; }
        public string? ReferenceName2 { get; set; }
        public string? ReferenceContact2 { get; set; }

        public string? City { get; set; }
        public string? PinCode { get; set; }
        public string? State { get; set; }
        public string? NomineeName { get; set; }
        public string? NomineeAddress { get; set; }
        public string? NomineePhoneNo { get; set; }
        public string? NomineeRelation { get; set; }
        public int? NomineeAge { get; set; }
        public string? ProjectName { get; set; }
        public string? Block { get; set; }
        public string? PlotCity { get; set; }
        public string? KhasraNo { get; set; }
        public string? PlotNo { get; set; }
        public string? PlotSize { get; set; }
        public decimal? AreaSqFt { get; set; }
        public decimal? RatePerSqFt { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TokenAmount { get; set; }
        public DateTime? DownPaymentDate { get; set; }
        public decimal? DownPaymentAmount { get; set; }
        public int? NumberOfInstallments { get; set; }
        public decimal? EMIAmount { get; set; }
        public string? Remarks { get; set; }
        public string? ExecutiveId { get; set; }
        public string? ExecutiveName { get; set; }
        public string? ExecutiveSignature { get; set; }
        public string? PurchaserName { get; set; }
        public string? PurchaserSign { get; set; }
        public string? AuthorizedSignatory { get; set; }
        public DateTime? DirectorSalesDate { get; set; }
        public string? DirectorName { get; set; }
        public string? DirectorSign { get; set; }
        public string? PANCardNumber { get; set; }
        public string? DrivingLicenseNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VoterIdNumber { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? RationCardNumber { get; set; }
        public string? PANCardImage { get; set; } = "";
        public string? DrivingLicenseImage { get; set; } = "";
        public string? PassportImage { get; set; } = "";
        public string? VoterIdImage { get; set; } = "";
        public string? AadhaarImage { get; set; } = "";
        public string? RationCardImage { get; set; } = "";
        public string? PaymentDetails { get; set; } 
        public List<CustomerPlotPaymentDto>? CustomerPlotPaymentList { get; set; }

    }
    public class PlotBookingListReqDto
    {
        public long? CustomerId { get; set; }
        public long? PlotId { get; set; }
        public string? CustomerName { get; set; }
        public string? PlotCode { get; set; }
        public string? PlotName { get; set; }
        public string? Mobile { get; set; }

    }
    public class PlotBookingListRespDto {
        public long CustomerId { get; set; }
        public long PlotId { get; set; }
        public string CustomerName { get; set; }
        public string PlotCode { get; set; }
        public string PlotName { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal PaidAmt { get; set; }
        public decimal BalanceAmt
        {
            get
            {
                return TotalAmt - PaidAmt;
            }
        }
    }

    public class CustomerPlotPaymentDto
    {
        public long customerpaymentid { get; set; }
        public int EmiNo { get; set; }
        public decimal amount { get; set; }
        public decimal paidamount { get; set; }
        public DateTime emidate { get; set; }
        public bool ispaid { get; set; }
        public string remarks { get; set; }
    }



}
