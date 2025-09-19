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
        public async Task<ActionResult<CommonResponseDto<List<IPaymentResponseDto>>>> GetListPayments(CommonRequestDto<IPaymentReqDto> commonRequest)
        {
            var payments = await paymentService.GetListService(commonRequest);
            return payments;
        }

        [HttpPost("GetPaymentService")]
        public async Task<ActionResult<CommonResponseDto<IPaymentResponseDto>>> GetPayment([FromBody] CommonRequestDto<IPaymentReqDto> request)
        {
            var payment =  paymentService.GetPayment(request);
            return payment;
        }

        [HttpPost("UploadPaymentImages")]
        public async Task<ActionResult<CommonResponseDto<List<string>>>> UploadPaymentImages([FromForm] List<IFormFile> images)
        {
            var imageNames = new List<string>();
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(imageFolder);

            CommonResponseDto<List<string>> commonResponseDto =new DevApi.Models.Common.CommonResponseDto<List<string>>();

            foreach (var imageFile in images)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var imageName = $"{Guid.NewGuid()}{extension}";
                    var imagePath = Path.Combine(imageFolder, imageName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    imageNames.Add(imageName);
                }
            }
            commonResponseDto.Data = imageNames;
            return commonResponseDto;
        }

        [HttpPost("ApprovePaymentService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> ApprovedPayment([FromBody] CommonRequestDto<IPaymentApproveDto> request)
        {
            var result = await paymentService.UpdatePaymentService(request);
            return result;
        }

        [HttpPost("IncommingPaymentCancelService")]
        public async Task<ActionResult<CommonResponseDto<ValidationMessageDto>>> IncommingPaymentCancel([FromBody] CommonRequestDto<IPaymentReqDto> request)
        {
            var payment =  paymentService.GetPaymentCancel(request);
            return payment;
        }
    }
}