using System;
using DevApi.Models.Common;
using DevApi.Models.Enums;
using MyApp.Models.Common;

namespace DevApi.Models
{
    public class IPaymentReportDto
    {
            public string? CustomerName { get; set; }
            public string? PlotCode { get; set; }
            public string? PlotName { get; set; }
            public int? PlotStatus { get; set; }
            public decimal? Amount { get; set; }
            public string? PaymentType { get; set; }
            public string? PaymentMode { get; set; }
            public int? PaymentSource { get; set; }
            public string? PaymentSourceName { get; set; }
            public DateTime? PaymentDate { get; set; }
            public string? ReferenceNo { get; set; }
            public string? BankName { get; set; }
            public string? BranchName { get; set; }
            public int? CustomerId { get; set; }
            public int? ApproveStatus { get; set; }
            public int? ApproveBy { get; set; }
            public string? AdminApproveDate { get; set; }
            public string? AdminApproveRemarks { get; set; }
            public int? ApproveStatusF { get; set; }
            public string? SuperAdminName { get; set; }
            public string? SuperAdminApproveDate { get; set; }
            public string? SuperAdminApproveRemarks { get; set; }

            public string AdminApprover
            {
                get
                {
                    return Enum.IsDefined(typeof(ApprovalStatus), ApproveStatus)
                        ? ((ApprovalStatus)ApproveStatus).ToString()
                        : string.Empty;
                }
            }
            public string SuperAdminApprover
            {
                get
                {
                    return Enum.IsDefined(typeof(ApprovalStatus), ApproveStatusF)
                        ? ((ApprovalStatus)ApproveStatusF).ToString()
                        : string.Empty;
                }
            }

            public string PlotStatusName
            {
                get
                {
                    return Enum.IsDefined(typeof(PlotStatusEnum), PlotStatus)
                        ? ((PlotStatusEnum)PlotStatus).ToString()
                        : string.Empty;
                }
            }
        

    }
}
