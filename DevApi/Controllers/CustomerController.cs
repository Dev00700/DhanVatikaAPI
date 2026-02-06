using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using DevApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService aCustomerService)
        {
            customerService = aCustomerService;
        }

        [HttpPost("AddCustomerService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> AddCustomer([FromBody] CommonRequestDto<CustomerReqDto> request)
        {
            var result = await customerService.AddService(request);
            return result;
        }

        [HttpPost("UpdateCustomerService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdateCustomer([FromBody] CommonRequestDto<CustomerReqDto> request)
        {
            var result = await customerService.UpdateService(request);
            return result;
        }

        [HttpPost("GetCustomerListService")]
        public async Task<ActionResult<CommonResponseDto<List<CustomerResDto>>>> GetCustomerList(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var result = await customerService.GetListService(commonRequest);
            return result;
        }
        [HttpPost("CustomerLoginService")]
        public async Task<ActionResult<CommonResponseDto<CustomerResDto>>> CustomerLogin(CommonRequestDto<CustomerLoginReqDto> commonRequest)
        {
            var result = await customerService.CustomerLoginService(commonRequest);
            return result;
        }
        [HttpPost("UpdateCustomerPasswordService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> CustomerUpdatePassword(CommonRequestDto<UpdatePasswordReqDto> commonRequest)
        {
            var result =  customerService.UpdatePasswordService(commonRequest);
            return result;
        }
        [HttpPost("CustomerWisePlotService")]
        public async Task< ActionResult<CommonResponseDto<List<PlotForCustomerResponseDto>>>> CustomerPLot(CommonRequestDto<PlotForCustomerRequestDto> commonRequest)
        {
            var result =await customerService.CustomerPlotService(commonRequest);
            return result;
        }

        [HttpPost("PlotWiseCustomerPaymentListService")]
        public async Task<ActionResult<CommonResponseDto<List<PLotWiseCustomerPaymentResDto>>>> PlotWisePaymentCustomerService(CommonRequestDto<PLotWiseCustomerPaymentReqDto> commonRequest)
        {
            var result = await customerService.PlotWiseCustomerPaymentSerice(commonRequest);
            return result;
        }

        [HttpPost("GetPlotAndCustomerWiseEmiService")]
        public async Task<ActionResult<CommonResponseDto<List<PlotAndCustomerEmiResDto>>>> PlotAndCustomerWiseGetEmiService(CommonRequestDto<PlotAndCustomerEmiReqDto> commonRequest)
        {
            var result = await customerService.PlotAndCustomerWiseEmiService(commonRequest);
            return result;
        }

        [HttpPost("GetCustomerPaymentReceiptService")]
        public ActionResult<CommonResponseDto<CustomerReceiptResDto>> CustomerPaymentGetReceiptService(CommonRequestDto<CustomerReceiptReqDto> commonRequest)
        {
            var result =  customerService.CustomerPaymentReceiptService(commonRequest);
            return result;
        }

        [HttpPost("GetCustomerService")]
        public ActionResult<CommonResponseDto<CustomerResDto>> GetCustomer(CommonRequestDto<CustomerReqDto> commonRequest)
        {
            var result =  customerService.GetCustomerService(commonRequest);
            return result;
        }

        [HttpPost("CustomerPlotCancelService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> CustomerCancelPlotService(CommonRequestDto<CustomerPlotCancelReqDto> commonRequest)
        {
            var result = customerService.CustomerPlotCancelService(commonRequest);
            return result;
        }
        [HttpPost("CustomerAddMultiplePlotService")]
        public ActionResult<CommonResponseDto<ValidationMessageDto>> CustomerMultiplePlotAddService(CommonRequestDto<CustomerAddMultiplePlot> commonRequest)
        {
            var result = customerService.CustomerAddMultiplePlotService(commonRequest);
            return result;
        }
    }
}