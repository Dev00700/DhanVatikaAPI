using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class CustomerService
    {
        private readonly IConfiguration _configuration;
        public CustomerService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<ValidationMessageDto>> AddService(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@Name", data.Name);
            queryParameter.Add("@EmailId", data.EmailId);
            queryParameter.Add("@Mobile", data.Mobile);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@Image", data.Image);
            queryParameter.Add("@PlotId", data.PlotId);
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
            string proc = "Proc_CustomerLogin";
            var queryParameter = new DynamicParameters();


            // optional paging
            queryParameter.Add("@Username", commonRequest.Data.UserName);
            queryParameter.Add("@Password", commonRequest.Data.Password);

            var res = DBHelperDapper.GetResponseModel<CustomerResDto>(proc, queryParameter);
            response.Data = res;

            return response;
        }

        public CommonResponseDto<ValidationMessageDto> UpdatePasswordService(CommonRequestDto<UpdatePasswordReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_Customer";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 6);
            // optional paging
            queryParameter.Add("@CustomerGuid", commonRequest.Data.CustomerGuid);
            queryParameter.Add("@Password", commonRequest.Data.NewPassword);
            queryParameter.Add("@OldPassword", commonRequest.Data.OldPassword);

            var res = DBHelperDapper.GetResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<PlotForCustomerResponseDto>>> CustomerPlotService(CommonRequestDto<PlotForCustomerRequestDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<PlotForCustomerResponseDto>>();
            string proc = "Proc_CustomerPlot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@CustomerId", commonRequest.Data.CustomerId);
            var res = await DBHelperDapper.GetResponseModelList<PlotForCustomerResponseDto>(proc, queryParameter);

           
            // res.ForEach(x => x.Image = !string.IsNullOrEmpty(x.Image) ? imageurl + x.Image  : string.Empty );

            var result = res
            .GroupBy(x => x.PlotCode)
            .Select(g => new PlotForCustomerResponseDto
            {
                PlotCode = g.First().PlotCode,
                PlotName = g.First().PlotName,
                Address = g.First().Address,
                Price = g.First().Price,
                Amenities=g.First().Amenities,
                AreaSize = g.First().AreaSize,
                Description = g.First().Description,    
                Facing = g.First().Facing,
                Latitude = g.First().Latitude,
                Longitude = g.First().Longitude,
                LocationName = g.First().LocationName,
                NearbyLandmarks = g.First().NearbyLandmarks,
                UnitTypeName    = g.First().UnitTypeName,
                Amount = g.First().Amount,
                Remarks = g.First().Remarks,
                PlotId=g.First().PlotId,
                PlotGuid=g.First().PlotGuid,
                PaymentDate = g.First().PaymentDate,
                PaymentDetails=g.First().PaymentDetails,

                PlotImage = g
                     .Where(z => z.PlotImageGuid != Guid.Empty)   // << fix here
    .Select(z => new PlotImageDto
    {
        PlotImageGuid = (Guid)z.PlotImageGuid,
        PlotId = (int)z.PlotId,
        Image = !string.IsNullOrEmpty((string)z.Image) ? imageurl + z.Image : ""
    })
                    .Distinct()
                    .ToList()
            })
            .ToList();

            result.ForEach(x =>
            {
                x.CustomerPlotPaymentList = JsonConvert.DeserializeObject<List<CustomerPlotPaymentDto>>(x.PaymentDetails);
                x.PaymentDetails = null;
            });

            response.Data = result;
            return response;
        }

        public async Task<CommonResponseDto<List<PLotWiseCustomerPaymentResDto>>> PlotWiseCustomerPaymentSerice(CommonRequestDto<PLotWiseCustomerPaymentReqDto> commonRequest)
        {
            var response = new CommonResponseDto<List<PLotWiseCustomerPaymentResDto>>();
            string proc = "Proc_PLotWiseCustomerPayment";
            var queryParameter = new DynamicParameters();
           
            queryParameter.Add("@CustomerId", commonRequest.Data.CustomerId);
            queryParameter.Add("@PlotId", commonRequest.Data.PlotId);
            var res = await DBHelperDapper.GetResponseModelList<PLotWiseCustomerPaymentResDto>(proc, queryParameter);
            response.Data = res;
            return response;
        }
        public async Task<CommonResponseDto<List<PlotAndCustomerEmiResDto>>> PlotAndCustomerWiseEmiService(CommonRequestDto<PlotAndCustomerEmiReqDto> commonRequest)
        {
            var response = new CommonResponseDto<List<PlotAndCustomerEmiResDto>>();
            string proc = "Proc_PlotAndCustomerWiseEmi";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@CustomerId", commonRequest.Data.CustomerId);
            queryParameter.Add("@PlotId", commonRequest.Data.PlotId);
            var res = await DBHelperDapper.GetResponseModelList<PlotAndCustomerEmiResDto>(proc, queryParameter);
            response.Data = res;
            return response;
        }


        public CommonResponseDto<CustomerReceiptResDto> CustomerPaymentReceiptService(CommonRequestDto<CustomerReceiptReqDto> commonRequest)
        {
            var response = new CommonResponseDto<CustomerReceiptResDto>();
            string proc = "Proc_CustomerPlotPaymentReceipt";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@CustomerId", commonRequest.Data.CustomerId);
            queryParameter.Add("@PlotId", commonRequest.Data.PlotId);
            queryParameter.Add("@CustomerPaymentId", commonRequest.Data.CustomerPaymentId);
            var res =  DBHelperDapper.GetResponseModel<CustomerReceiptResDto>(proc, queryParameter);
            response.Data = res;
            return response;
        }
    }
}