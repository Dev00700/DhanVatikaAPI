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

        public async Task<CommonResponseDto<List<CustomerResDto>>> GetListService(CommonRequestDto commonRequest)
        {
            var response = new CommonResponseDto<List<CustomerResDto>>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            // optional paging
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);

            var res = await DBHelperDapper.GetResponseModelList<CustomerResDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }
    }
}