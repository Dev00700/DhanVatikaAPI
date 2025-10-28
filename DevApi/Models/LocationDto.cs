using MyApp.Models.Common;

namespace DevApi.Models
{
    public class LocationReqDto: BaseDto
    {
        public Guid? LocationGuid { get; set; }
        public long? LocationId { get; set; }
        public string LocationName { get; set; }
        public string Image { get; set; }
    }
    public class LocationResDto : BaseDto
    {
        public Guid? LocationGuid { get; set; }
        public long? LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? Image { get; set; }
    }
}
