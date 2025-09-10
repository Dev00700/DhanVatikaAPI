using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class IncommingPaymentService
    {
        private readonly IConfiguration _configuration;
        public  IncommingPaymentService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<IPaymentDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_IncommingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            // Pass all required fields from IncommingPaymentDto
            var data = commonRequest.Data;
            queryParameter.Add("@IPaymentGuid", data.IPaymentGuid);
            queryParameter.Add("@PaymentType", data.PaymentType);
            queryParameter.Add("@PaymentModeId", data.PaymentModeId);
            queryParameter.Add("@Amount", data.Amount);
            queryParameter.Add("@PaymentSource", data.PaymentSource);
            queryParameter.Add("@PaymentDate", data.PaymentDate);
            queryParameter.Add("@ReferenceNo", data.ReferenceNo);
            queryParameter.Add("@BankName", data.BankName);
            queryParameter.Add("@BranchName", data.BranchName);
            queryParameter.Add("@CustomerId", data.CustomerId);
            queryParameter.Add("@ApproveStatus", data.ApproveStatus);
            queryParameter.Add("@ApproveBy", data.ApproveBy);
            queryParameter.Add("@ApproveDate", data.ApproveDate);
            queryParameter.Add("@ApproveStatusF", data.ApproveStatusF);
            queryParameter.Add("@ApproveByF", data.ApproveByF);
            queryParameter.Add("@ApproveDateF", data.ApproveDateF);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<IPaymentDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_IncommingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@ModifiedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@IPaymentId", data.IPaymentId);
            queryParameter.Add("@IPaymentGuid", data.IPaymentGuid);
            queryParameter.Add("@PaymentType", data.PaymentType);
            queryParameter.Add("@PaymentModeId", data.PaymentModeId);
            queryParameter.Add("@Amount", data.Amount);
            queryParameter.Add("@PaymentSource", data.PaymentSource);
            queryParameter.Add("@PaymentDate", data.PaymentDate);
            queryParameter.Add("@ReferenceNo", data.ReferenceNo);
            queryParameter.Add("@BankName", data.BankName);
            queryParameter.Add("@BranchName", data.BranchName);
            queryParameter.Add("@CustomerId", data.CustomerId);
            queryParameter.Add("@ApproveStatus", data.ApproveStatus);
            queryParameter.Add("@ApproveBy", data.ApproveBy);
            queryParameter.Add("@ApproveDate", data.ApproveDate);
            queryParameter.Add("@ApproveStatusF", data.ApproveStatusF);
            queryParameter.Add("@ApproveByF", data.ApproveByF);
            queryParameter.Add("@ApproveDateF", data.ApproveDateF);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);

            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<IPaymentResponseDto>>> GetListService(CommonRequestDto commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<IPaymentResponseDto>>();
            string proc = "Proc_IncommingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);

            var res =await DBHelperDapper.GetPagedModelList<IPaymentResponseDto>(proc, queryParameter);
            res.Data.ForEach(x => x.Image = x.Image !=""? imageurl + x.Image:"");
            return res;
        }

        public async Task<CommonResponseDto<IPaymentResponseDto>> GetPayment(CommonRequestDto<IPaymentReqDto> commonRequest)
        {
            var response = new CommonResponseDto<IPaymentResponseDto>();
            string proc = "Proc_IncommingPayment";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@IPaymentGuid", data.IPaymentGuid);

            var res =await DBHelperDapper.GetResponseModel<IPaymentResponseDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public async Task<CommonResponseDto<ValidationMessageDto>> UpdatePaymentService(CommonRequestDto<IPaymentApproveDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_ApproveIncommingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@IPaymentguid", commonRequest.Data.IPaymentGuid);
            queryParameter.Add("@ApproveFlag", commonRequest.Data.ApproveStatus);
            queryParameter.Add("@Remarks", commonRequest.Data.ApproveRemarks);
            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> GetPaymentCancel(CommonRequestDto<IPaymentReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_IncommingPayment";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;

            queryParameter.Add("@ProcId", 5);
            queryParameter.Add("@IPaymentguid", commonRequest.Data.IPaymentGuid);

            var res = await DBHelperDapper.GetResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}