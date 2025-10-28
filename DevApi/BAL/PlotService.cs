using Dapper;
using DevApi.Models;
using DevApi.Models.Common;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using MyApp.Models.Common;
using System.Threading.Tasks;

namespace MyApp.BAL
{
    public class PlotService
    {
        private readonly IConfiguration _configuration;
        public PlotService(IConfiguration aconfiguration)
        {
            _configuration = aconfiguration;
        }
        public async Task<CommonResponseDto<plotAddResDto>> AddService(CommonRequestDto<PlotDto> commonRequest)
        {
            var response = new CommonResponseDto<plotAddResDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var data = commonRequest.Data;
          
            queryParameter.Add("@PlotName", data.PlotName);
            queryParameter.Add("@Description", data.Description);
            queryParameter.Add("@LocationId", data.LocationId);
            queryParameter.Add("@Address", data.Address);
            queryParameter.Add("@Latitude", data.Latitude);
            queryParameter.Add("@Longitude", data.Longitude);
            queryParameter.Add("@AreaSize", data.AreaSize);
            queryParameter.Add("@UnitTypeId", data.UnitTypeId);
            queryParameter.Add("@Price", data.Price);
            queryParameter.Add("@Status", data.Status);
            queryParameter.Add("@Facing", data.Facing);
            queryParameter.Add("@PlotType", data.PlotType);
            queryParameter.Add("@NearbyLandmarks", data.NearbyLandmarks);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@IsShowONWeb", data.IsShowONWeb);
            queryParameter.Add("@Amenities", data.Amenities);

            var res =await DBHelperDapper.GetAddResponseModel<plotAddResDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<ValidationMessageDto>>> AddImagesService(CommonRequestDto<List<PlotImageDto>> commonRequest)
        {
            var response = new CommonResponseDto<List<ValidationMessageDto>>
            {
                Data = new List<ValidationMessageDto>()
            };

            string proc = "Proc_PlotImage";

            foreach (var image in commonRequest.Data)
            {
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@ProcId", 1); // 1 for insert
                queryParameter.Add("@PlotId", image.PlotId);
                queryParameter.Add("@Image", image.Image);
                queryParameter.Add("@IsActive", image.IsActive);
                queryParameter.Add("@DelMark", image.DelMark);
                queryParameter.Add("@Remarks", image.Remarks);

                var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
                response.Data.Add(res);
            }

            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<plotAddResDto>> UpdateService(CommonRequestDto<PlotDto> commonRequest)
        {
            var response = new CommonResponseDto<plotAddResDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;

            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@CreatedBy", commonRequest.UserId);
            queryParameter.Add("@PlotGuid", data.PlotGuid);
            queryParameter.Add("@PlotName", data.PlotName);
            queryParameter.Add("@Description", data.Description);
            queryParameter.Add("@LocationId", data.LocationId);
            queryParameter.Add("@Address", data.Address);
            queryParameter.Add("@Latitude", data.Latitude);
            queryParameter.Add("@Longitude", data.Longitude);
            queryParameter.Add("@AreaSize", data.AreaSize);
            queryParameter.Add("@UnitTypeId", data.UnitTypeId);
            queryParameter.Add("@Price", data.Price);
            queryParameter.Add("@Status", data.Status);
            queryParameter.Add("@Facing", data.Facing);
            queryParameter.Add("@PlotType", data.PlotType);
            queryParameter.Add("@NearbyLandmarks", data.NearbyLandmarks);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@IsShowONWeb", data.IsShowONWeb);
            queryParameter.Add("@Amenities", data.Amenities);

            var res = await DBHelperDapper.GetAddResponseModel<plotAddResDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<PlotResponseDto>>> GetListService(CommonRequestDto commonRequest)
        {
          
            var response = new CommonResponseDto<List<PlotResponseDto>>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@PageNumber", commonRequest.PageSize);
            queryParameter.Add("@PageRecordCount", commonRequest.PageRecordCount);
            var res = await DBHelperDapper.GetPagedModelList<PlotResponseDto>(proc, queryParameter);
          
            return res;
        }
        public  CommonResponseDto<PlotResponseDto> GetPlotService(CommonRequestDto<PlotReqDto> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<PlotResponseDto>();
            string proc = "Proc_Plot";
            var queryParameter = new DynamicParameters();
            var data = commonRequest.Data;
            queryParameter.Add("@ProcId", 4);
            queryParameter.Add("@PlotGuid", data.PlotGuid);
            //var res = DBHelperDapper.GetResponseModel<PlotResponseDto>(proc, queryParameter);
            var res = DBHelperDapper.GetModelFromJson<PlotResponseDto>(proc, queryParameter);
            res.PlotImage.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> AddPlotBookingService(CommonRequestDto<PlotBookingReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_PlotBooking";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1); // 1 for insert
            queryParameter.Add("@CreatedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@CustomerId", data.CustomerId);
            queryParameter.Add("@PlotId", data.PlotId);
            queryParameter.Add("@CustomerName", data.CustomerName);
            queryParameter.Add("@Occupation", data.Occupation);
            queryParameter.Add("@DateOfBirth", data.DateOfBirth);
            queryParameter.Add("@Anniversary", data.Anniversary);
            queryParameter.Add("@ContactNo1", data.ContactNo1);
            queryParameter.Add("@ContactNo2", data.ContactNo2);
            queryParameter.Add("@PostalAddress", data.PostalAddress);
            queryParameter.Add("@EmailAddress", data.EmailAddress);
            queryParameter.Add("@ReferenceName1", data.ReferenceName1);
            queryParameter.Add("@ReferenceContact1", data.ReferenceContact1);
            queryParameter.Add("@ReferenceName2", data.ReferenceName2);
            queryParameter.Add("@ReferenceContact2", data.ReferenceContact2);
            queryParameter.Add("@City", data.City);
            queryParameter.Add("@PinCode", data.PinCode);
            queryParameter.Add("@State", data.State);
            queryParameter.Add("@NomineeName", data.NomineeName);
            queryParameter.Add("@NomineeAddress", data.NomineeAddress);
            queryParameter.Add("@NomineePhoneNo", data.NomineePhoneNo);
            queryParameter.Add("@NomineeRelation", data.NomineeRelation);
            queryParameter.Add("@NomineeAge", data.NomineeAge);
            queryParameter.Add("@ProjectName", data.ProjectName);
            queryParameter.Add("@Block", data.Block);
            queryParameter.Add("@PlotCity", data.PlotCity);
            queryParameter.Add("@KhasraNo", data.KhasraNo);
            queryParameter.Add("@PlotNo", data.PlotNo);
            queryParameter.Add("@PlotSize", data.PlotSize);
            queryParameter.Add("@AreaSqFt", data.AreaSqFt);
            queryParameter.Add("@RatePerSqFt", data.RatePerSqFt);
            queryParameter.Add("@TotalCost", data.TotalCost);
            queryParameter.Add("@BookingDate", data.BookingDate);
            queryParameter.Add("@TokenAmount", data.TokenAmount);
            queryParameter.Add("@DownPaymentDate", data.DownPaymentDate);
            queryParameter.Add("@DownPaymentAmount", data.DownPaymentAmount);
            queryParameter.Add("@NumberOfInstallments", data.NumberOfInstallments);
            queryParameter.Add("@EMIAmount", data.EMIAmount);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@ExecutiveId", data.ExecutiveId);
            queryParameter.Add("@ExecutiveName", data.ExecutiveName);
            queryParameter.Add("@ExecutiveSignature", data.ExecutiveSignature);
            queryParameter.Add("@PurchaserName", data.PurchaserName);
            queryParameter.Add("@PurchaserSign", data.PurchaserSign);
            queryParameter.Add("@AuthorizedSignatory", data.AuthorizedSignatory);
            queryParameter.Add("@DirectorSalesDate", data.DirectorSalesDate);
            queryParameter.Add("@DirectorName", data.DirectorName);
            queryParameter.Add("@DirectorSign", data.DirectorSign);
            queryParameter.Add("@PANCardNumber", data.PANCardNumber);
            queryParameter.Add("@DrivingLicenseNumber", data.DrivingLicenseNumber);
            queryParameter.Add("@PassportNumber", data.PassportNumber);
            queryParameter.Add("@VoterIdNumber", data.VoterIdNumber);
            queryParameter.Add("@AadhaarNumber", data.AadhaarNumber);
            queryParameter.Add("@RationCardNumber", data.RationCardNumber);
            queryParameter.Add("@PANCardImage", data.PANCardImage);
            queryParameter.Add("@DrivingLicenseImage", data.DrivingLicenseImage);
            queryParameter.Add("@PassportImage", data.PassportImage);
            queryParameter.Add("@VoterIdImage", data.VoterIdImage);
            queryParameter.Add("@AadhaarImage", data.AadhaarImage);
            queryParameter.Add("@RationCardImage", data.RationCardImage);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> UpdatePlotBookingService(CommonRequestDto<PlotBookingReqDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>();
            string proc = "Proc_PlotBooking";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2); // 2 for update
            queryParameter.Add("@ModifiedBy", commonRequest.UserId);

            var data = commonRequest.Data;
            queryParameter.Add("@BookingId", data.BookingId);
            // Add all other fields as above for update
            queryParameter.Add("@BookingGuid", data.BookingGuid);
            queryParameter.Add("@CustomerId", data.CustomerId);
            queryParameter.Add("@PlotId", data.PlotId);
            queryParameter.Add("@CustomerName", data.CustomerName);
            queryParameter.Add("@Occupation", data.Occupation);
            queryParameter.Add("@DateOfBirth", data.DateOfBirth);
            queryParameter.Add("@Anniversary", data.Anniversary);
            queryParameter.Add("@ContactNo1", data.ContactNo1);
            queryParameter.Add("@ContactNo2", data.ContactNo2);
            queryParameter.Add("@PostalAddress", data.PostalAddress);
            queryParameter.Add("@EmailAddress", data.EmailAddress);
            queryParameter.Add("@ReferenceName1", data.ReferenceName1);
            queryParameter.Add("@ReferenceContact1", data.ReferenceContact1);
            queryParameter.Add("@ReferenceName2", data.ReferenceName2);
            queryParameter.Add("@ReferenceContact2", data.ReferenceContact2);
            queryParameter.Add("@City", data.City);
            queryParameter.Add("@PinCode", data.PinCode);
            queryParameter.Add("@State", data.State);
            queryParameter.Add("@NomineeName", data.NomineeName);
            queryParameter.Add("@NomineeAddress", data.NomineeAddress);
            queryParameter.Add("@NomineePhoneNo", data.NomineePhoneNo);
            queryParameter.Add("@NomineeRelation", data.NomineeRelation);
            queryParameter.Add("@NomineeAge", data.NomineeAge);
            queryParameter.Add("@ProjectName", data.ProjectName);
            queryParameter.Add("@Block", data.Block);
            queryParameter.Add("@PlotCity", data.PlotCity);
            queryParameter.Add("@KhasraNo", data.KhasraNo);
            queryParameter.Add("@PlotNo", data.PlotNo);
            queryParameter.Add("@PlotSize", data.PlotSize);
            queryParameter.Add("@AreaSqFt", data.AreaSqFt);
            queryParameter.Add("@RatePerSqFt", data.RatePerSqFt);
            queryParameter.Add("@TotalCost", data.TotalCost);
            queryParameter.Add("@BookingDate", data.BookingDate);
            queryParameter.Add("@TokenAmount", data.TokenAmount);
            queryParameter.Add("@DownPaymentDate", data.DownPaymentDate);
            queryParameter.Add("@DownPaymentAmount", data.DownPaymentAmount);
            queryParameter.Add("@NumberOfInstallments", data.NumberOfInstallments);
            queryParameter.Add("@EMIAmount", data.EMIAmount);
            queryParameter.Add("@Remarks", data.Remarks);
            queryParameter.Add("@ExecutiveId", data.ExecutiveId);
            queryParameter.Add("@ExecutiveName", data.ExecutiveName);
            queryParameter.Add("@ExecutiveSignature", data.ExecutiveSignature);
            queryParameter.Add("@PurchaserName", data.PurchaserName);
            queryParameter.Add("@PurchaserSign", data.PurchaserSign);
            queryParameter.Add("@AuthorizedSignatory", data.AuthorizedSignatory);
            queryParameter.Add("@DirectorSalesDate", data.DirectorSalesDate);
            queryParameter.Add("@DirectorName", data.DirectorName);
            queryParameter.Add("@DirectorSign", data.DirectorSign);
            queryParameter.Add("@PANCardNumber", data.PANCardNumber);
            queryParameter.Add("@DrivingLicenseNumber", data.DrivingLicenseNumber);
            queryParameter.Add("@PassportNumber", data.PassportNumber);
            queryParameter.Add("@VoterIdNumber", data.VoterIdNumber);
            queryParameter.Add("@AadhaarNumber", data.AadhaarNumber);
            queryParameter.Add("@RationCardNumber", data.RationCardNumber);
            queryParameter.Add("@PANCardImage", data.PANCardImage);
            queryParameter.Add("@DrivingLicenseImage", data.DrivingLicenseImage);
            queryParameter.Add("@PassportImage", data.PassportImage);
            queryParameter.Add("@VoterIdImage", data.VoterIdImage);
            queryParameter.Add("@AadhaarImage", data.AadhaarImage);
            queryParameter.Add("@RationCardImage", data.RationCardImage);
            queryParameter.Add("@IsActive", data.IsActive);
            queryParameter.Add("@DelMark", data.DelMark);

            var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
            response.Data = res;
            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<ValidationMessageDto>> DeletePLotImagesService(CommonRequestDto<PlotImageDeleteDto> commonRequest)
        {
            var response = new CommonResponseDto<ValidationMessageDto>
            {
                Data = new ValidationMessageDto()
            };

            string proc = "Proc_PlotImage";

             var queryParameter = new DynamicParameters();
                queryParameter.Add("@ProcId", 2); // 1 for insert
                queryParameter.Add("@PlotImageGuid", commonRequest.Data.PlotImageGuid); // 1 for insert
                

                var res = await DBHelperDapper.GetAddResponseModel<ValidationMessageDto>(proc, queryParameter);
                response.Data = res;


            response.Flag = 1;
            response.Message = "Success";
            return response;
        }

        public async Task<CommonResponseDto<List<LocationDto>>> GetLocationListService(CommonRequestDto commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<LocationDto>>();
            string proc = "Proc_GetPlot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 1);
            var res = await DBHelperDapper.GetResponseModelList<LocationDto>(proc, queryParameter);
            res.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
            response.Data = res;
            return response;
        }

        public async Task<CommonResponseDto<List<PlotWebResponseDto>>> GetPlotWebListService(CommonRequestDto<PtotWebReq> commonRequest)
        {

            var response = new CommonResponseDto<List<PlotWebResponseDto>>();
            string proc = "Proc_GetPlot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 2);
            queryParameter.Add("@LocationId", commonRequest.Data.LocationId);
            var res = await DBHelperDapper.GetResponseModelList<PlotWebResponseDto>(proc, queryParameter);
            response.Data = res;
            return response;
        }
        public  CommonResponseDto<PlotResponseDto> GetPlotWebService(CommonRequestDto<PtotWebReq> commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<PlotResponseDto>();
            string proc = "Proc_GetPlot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 3);
            queryParameter.Add("@PlotId", commonRequest.Data.PLotId);
            var res =  DBHelperDapper.GetModelFromJson<PlotResponseDto>(proc, queryParameter);
            res.PlotImage.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
            response.Data = res;
            return response;
        }
        public async Task<CommonResponseDto<List<PlotResponseDto>>> GetPlotWebHomeService(CommonRequestDto commonRequest)
        {
            var imageurl = _configuration.GetValue<string>("ImageURL");
            var response = new CommonResponseDto<List<PlotResponseDto>>();
            string proc = "Proc_GetPlot";
            var queryParameter = new DynamicParameters();

            queryParameter.Add("@ProcId", 4);
            var res =await DBHelperDapper.GetResponseModelList<PlotResponseDto>(proc, queryParameter);
            if (res != null)
            {
                res.ForEach(x => x.Image = x.Image != "" ? imageurl + x.Image : "");
            }
            response.Data = res;
            return response;
        }
    }
}