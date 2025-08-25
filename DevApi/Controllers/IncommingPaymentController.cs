using DevApi.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IncommingPaymentController : ControllerBase
    {
        private readonly IncommingPaymentService paymentService;

        public IncommingPaymentController(IncommingPaymentService apaymentService)
        {
            paymentService = apaymentService;
        }

        [HttpPost("AddPaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> InsertPayment([FromBody] CommonRequestDto<IPaymentDto> request)
        {
            var result = await paymentService.AddService(request);
            return result;
        }

        [HttpPost("UpdatePaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdatePayment([FromBody] CommonRequestDto<IPaymentDto> request)
        {
            var result = await paymentService.UpdateService(request);
            return result;
        }

        [HttpPost("GetPaymentListService")]
        public async Task<ActionResult<CommonResponseDto<List<IPaymentDto>>>> GetListPayments()
        {
            var payments = await paymentService.GetListService();
            return payments;
        }

        [HttpPost("GetPaymentService")]
        public async Task<ActionResult<CommonResponseDto<IPaymentDto>>> GetPayment([FromBody] CommonRequestDto<IPaymentReqDto> request)
        {
            var payment = await paymentService.GetPayment(request);
            return payment;
        }
    }
}