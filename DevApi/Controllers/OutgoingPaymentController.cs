using DevApi.Models;
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
    public class OutgoingPaymentController : ControllerBase
    {
        private readonly OutgoingPaymentService outgoingPaymentService;

        public OutgoingPaymentController(OutgoingPaymentService aOutgoingPaymentService)
        {
            outgoingPaymentService = aOutgoingPaymentService;
        }

        [HttpPost("AddOutgoingPaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> InsertOutgoingPayment([FromBody] CommonRequestDto<OutgoingPaymentDto> request)
        {
            var result = await outgoingPaymentService.AddService(request);
            return result;
        }

        [HttpPost("UpdateOutgoingPaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> UpdateOutgoingPayment([FromBody] CommonRequestDto<OutgoingPaymentDto> request)
        {
            var result = await outgoingPaymentService.UpdateService(request);
            return result;
        }

        [HttpPost("GetOutgoingPaymentListService")]
        public async Task<ActionResult<CommonResponseDto<List<IOutgoingResponseDto>>>> GetOutgoingPaymentList(CommonRequestDto <IOutgoingReqDto>commonRequest)
        {
            var payments = await outgoingPaymentService.GetListService(commonRequest);
            return payments;
        }

        [HttpPost("GetOutgoingPaymentService")]
        public ActionResult<CommonResponseDto<IOutgoingResponseDto>> GetOutgoingPayment([FromBody] CommonRequestDto<IOutgoingReqDto> request)
        {
            var payment =  outgoingPaymentService.GetPayment(request);
            return payment;
        }
        [HttpPost("OutgoingPaymentCancelService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> OutgoingPaymentCancel([FromBody] CommonRequestDto<IOutgoingReqDto> request)
        {
            var payment =  outgoingPaymentService.GetPaymentCancel(request);
            return payment;
        }
        [HttpPost("ApproveOutPaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> ApprovedPayment([FromBody] CommonRequestDto<OPaymentApproveDto> request)
        {
            var result = await outgoingPaymentService.UpdatePaymentService(request);
            return result;
        }
    }
}