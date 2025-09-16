using System;
using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;

namespace MyApp.Models
{
    public class IPaymentDto : BaseDto
    {
        public Guid? IPaymentGuid { get; set; }
        public long? IPaymentId { get; set; }
        public string PaymentType { get; set; }
        public int PaymentModeId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentSource { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReferenceNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int? CustomerId { get; set; }
        public int? ApproveStatus { get; set; }
        public int? ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? ApproveStatusF { get; set; }
        public int? ApproveByF { get; set; }
        public DateTime? ApproveDateF { get; set; }
        public string? Image { get; set; }
        public string? Remarks { get; set; }
        public string? ApproveRemarks { get; set; }
        public string? ApproveRemarksF { get; set; }
       
    }

    public class IPaymentReqDto
    {
        public Guid? IPaymentGuid { get; set; }
    }

    public class IPaymentResponseDto : ValidationMessageDto
    {
        public Guid IPaymentGuid { get; set; }
        public long IPaymentId { get; set; }
        public string PaymentType { get; set; }
        public int PaymentModeId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentSource { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReferenceNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int CustomerId { get; set; }
        public int ApproveStatus { get; set; }
        public int ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int ApproveStatusF { get; set; }
        public int ApproveByF { get; set; }
        public DateTime? ApproveDateF { get; set; }
        public string Image { get; set; }
        public string? Remarks { get; set; }
        public string? PaymentMode { get; set; }
        public string? PaymentSourceName { get; set; }
        public string AdminApprover
        {
            get
            {
                return Enum.IsDefined(typeof(ApprovalStatus), ApproveStatus)
                    ? ((ApprovalStatus)ApproveStatus).ToString()
                    : string.Empty;
            }
        }
        public string? AdminName { get; set; }
        public string? AdminApproveDate { get; set; }
        public string? AdminApproveRemarks { get; set; }
        public string SuperAdminApprover
        {
            get
            {
                return Enum.IsDefined(typeof(ApprovalStatus), ApproveStatusF)
                    ? ((ApprovalStatus)ApproveStatusF).ToString()
                    : string.Empty;
            }
        }
        public string? SuperAdminName { get; set; }
        public string? SuperAdminApproveDate { get; set; }
        public string? SuperAdminApproveRemarks { get; set; }
        public bool? IsDisabled { get; set; }
    }

    public class IPaymentApproveDto
    {
        public Guid? IPaymentGuid { get; set; }
        public int? ApproveStatus { get; set; }
        public int? ApproveBy { get; set; }
        public string? ApproveRemarks { get; set; }
    }
}