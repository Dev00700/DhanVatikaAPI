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
    [Authorize]
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
        public async Task<ActionResult<CommonResponseDto<List<CustomerResDto>>>> GetCustomerList(CommonRequestDto commonRequest)
        {
            var result = await customerService.GetListService(commonRequest);
            return result;
        }
    }
}