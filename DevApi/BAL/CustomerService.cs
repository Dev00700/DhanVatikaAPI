using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class CustomerService
    {
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@EnquiryId", data.EnquiryId);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdateService(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@ModifiedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@CustomerId", data.CustomerId);
            queryParameter.Add("@CustomerGuid", data.CustomerGuid);
            queryParameter.Add("@EnquiryId", data.EnquiryId);
            queryParameter.Add("@Name", data.Name);
            queryParameter.Add("@EmailId", data.EmailId);
            queryParameter.Add("@Mobile", data.Mobile);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<CustomerResDto>>> GetListService(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var response = new CommonResponseDto<List<CustomerResDto>>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            // optional paging
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            queryParameter.Add("@Name", commonRequest.Data.Name);
            queryParameter.Add("@EmailId", commonRequest.Data.EmailId);
            queryParameter.Add("@Mobile", commonRequest.Data.Mobile);

            var res = await DBHelperDapper.GetPagedModelList<CustomerResDto>(proc, queryParameter);
            
            return res;
        }

        public async Task<CommonResponseDto<CustomerResDto>> CustomerLoginService(CommonRequestDto<CustomerLoginReqDto> commonRequest)
        {
            var response = new CommonResponseDto<CustomerResDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 5);
            // optional paging
            queryParameter.Add("@Username", commonRequest.Data.UserName);
            queryParameter.Add("@Password", commonRequest.Data.Password);

            var res =  DBHelperDapper.GetResponseModel<CustomerResDto>(proc, queryParameter);
            response.Data = res;
           
            return response;
        }

        public  CommonResponseDto<ValidationMessageDto> UpdatePasswordService(CommonRequestDto<UpdatePasswordReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 6);
            // optional paging
            queryParameter.Add("@CustomerGuid", commonRequest.Data.CustomerGuid);
            queryParameter.Add("@Password", commonRequest.Data.NewPassword);

            var res = DBHelperDapper.GetResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}