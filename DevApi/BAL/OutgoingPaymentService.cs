using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class OutgoingPaymentService
    {
        private readonly IConfiguration _configuration;
        public OutgoingPaymentService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<OutgoingPaymentDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_OutgoingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
           

            var data = commonRequest.Data;
            queryParameter.Add("@ExpenseTitle", data.ExpenseTitle);
            queryParameter.Add("@ExpenseDate", data.ExpenseDate);
            queryParameter.Add("@ExpenseCategoryId", data.ExpenseCategoryId);
            queryParameter.Add("@Amount", data.Amount);
            queryParameter.Add("@PaymentMode", data.PaymentModeId);
            queryParameter.Add("@ReferenceNo", data.ReferenceNo);
            queryParameter.Add("@PartyName", data.PartyName);
            queryParameter.Add("@UserId", data.UserId);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@PlotId", commonRequest.Data.PlotId);
            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<OutgoingPaymentDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_OutgoingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2);

            var data = commonRequest.Data;
            queryParameter.Add("@OPaymentGuid", data.OPaymentGuid);
            queryParameter.Add("@ExpenseCategoryId", data.ExpenseCategoryId);
            queryParameter.Add("@ExpenseTitle", data.ExpenseTitle);
            queryParameter.Add("@ExpenseDate", data.ExpenseDate);
            queryParameter.Add("@Amount", data.Amount);
            queryParameter.Add("@PaymentMode", data.PaymentModeId);
            queryParameter.Add("@ReferenceNo", data.ReferenceNo);
            queryParameter.Add("@PartyName", data.PartyName);
            queryParameter.Add("@UserId", data.UserId);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var res =await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<IOutgoingResponseDto>>> GetListService(CommonRequestDto<IOutgoingReqDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<IOutgoingResponseDto>>();
            string proc = "Proc_OutgoingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@Year", commonRequest.Data.Year);
            queryParameter.Add("@Month", commonRequest.Data.Month);
            queryParameter.Add("@ExpenseTitle", commonRequest.Data.ExpenseTitle);
            queryParameter.Add("@PaymentMode", commonRequest.Data.PaymentModeId);
            queryParameter.Add("@ReferenceNo", commonRequest.Data.ReferenceNo);
            queryParameter.Add("@PlotCode", commonRequest.Data.PlotCode);

            var res =await DBHelperDapper.GetPagedModelList<IOutgoingResponseDto>(proc, queryParameter);
            res.Data.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
            return res;
        }

        public  CommonResponseDto<IOutgoingResponseDto> GetPayment(CommonRequestDto<IOutgoingReqDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<IOutgoingResponseDto>();
            string proc = "Proc_OutgoingPaymentForEdit";
          
            var data = commonRequest.Data;
            var queryParameter = new DynamicParameters();
            //queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@OPaymentGuid",data.OPaymentGuid);

            var res =  DBHelperDapper.GetResponseModel<IOutgoingResponseDto>(proc , queryParameter);
            if (res != null && !string.IsNullOrEmpty(res.Image))
            {
                res.Image = $"{imageurl}{res.Image}";
            }
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
        public CommonResponseDto<ValidationMessageDto> GetPaymentCancel(CommonRequestDto<IOutgoingReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_OutgoingPayment";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;

            queryParameter.Add("@ProcId", 5);
            queryParameter.Add("@OPaymentGuid", data.OPaymentGuid);

            var res =  DBHelperDapper.GetResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdatePaymentService(CommonRequestDto<OPaymentApproveDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_ApproveOutgoingPayment";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@OPaymentguid", commonRequest.Data.OPaymentGuid);
            queryParameter.Add("@ApproveFlag", commonRequest.Data.ApproveStatus);
            queryParameter.Add("@Remarks", commonRequest.Data.ApproveRemarks);
            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}