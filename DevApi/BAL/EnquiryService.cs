using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class EnquiryService
    {
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<EnquiryReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_PlotEnquiry";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1); // 1 for insert
            queryParameter.Add("@PlotId", commonRequest.Data.PlotId);
            queryParameter.Add("@Name", commonRequest.Data.Name);
            queryParameter.Add("@Email", commonRequest.Data.Email);
            queryParameter.Add("@Mobile", commonRequest.Data.Mobile);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> CloseService(CommonRequestDto<EnquiryClosedDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_PlotEnquiry";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3); // 3 for close
            queryParameter.Add("@EnquiryGuid", commonRequest.Data.EnquiryGuid);
            queryParameter.Add("@Remarks", commonRequest.Data.Remarks);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<EnquiryResDto>>> GetListService(CommonRequestDto<EnquirySerchDto> commonRequest)
        {
            var response = new CommonResponseDto<List<EnquiryResDto>>();
            string proc = "Proc_PlotEnquiry";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 4); // 4 for list
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            if (commonRequest.Data != null)
            {
                queryParameter.Add("@Name", commonRequest.Data.Name);
                queryParameter.Add("@Email", commonRequest.Data.Email);
                queryParameter.Add("@Mobile", commonRequest.Data.Mobile);
                queryParameter.Add("@Date", commonRequest.Data.Date);
                queryParameter.Add("@PlotCode", commonRequest.Data.PlotCode);
                queryParameter.Add("@PlotName", commonRequest.Data.PlotName);
                queryParameter.Add("@LocationName", commonRequest.Data.LocationName);
                queryParameter.Add("@Status", commonRequest.Data.Status);
            }

            var res = await DBHelperDapper.GetPagedModelList<EnquiryResDto>(proc, queryParameter);
            return res;
        }
    }
}