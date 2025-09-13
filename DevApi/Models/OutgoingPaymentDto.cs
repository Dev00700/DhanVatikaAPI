using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;

namespace DevApi.Models
{
    public class OutgoingPaymentDto : BaseDto
    {
        public Guid? OPaymentGuid { get; set; }
        public long? OPaymentId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string ExpenseTitle { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentModeId { get; set; }
        public string ReferenceNo { get; set; }
        public string PartyName { get; set; }
        public int UserId { get; set; }
        public string? Image { get; set; }
        public string? PaymentMode { get; set; }
    }
    public class IOutgoingReqDto
    {
        public Guid? OPaymentGuid { get; set; }
    }
    public class IOutgoingResponseDto : ValidationMessageDto
    {
        public long? AuditId { get; set; }
        public Guid? OPaymentGuid { get; set; }
        public long OPaymentId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string ExpenseTitle { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNo { get; set; }
        public string PartyName { get; set; }
        public int UserId { get; set; }
        public string? Image { get; set; }
        public int ApproveStatus { get; set; }
        public int ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int ApproveStatusF { get; set; }
        public int ApproveByF { get; set; }
        public DateTime? ApproveDateF { get; set; }
        public string? Remarks { get; set; }
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

    }

    public class OPaymentApproveDto
    {
        public Guid? OPaymentGuid { get; set; }
        public int? ApproveStatus { get; set; }
        public int? ApproveBy { get; set; }
        public string? ApproveRemarks { get; set; }
    }
}
