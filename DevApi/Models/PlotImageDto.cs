using MyApp.Models.Common;

namespace DevApi.Models
{
    public class PlotImageDto:BaseDto
    {
        public Guid PlotImageGuid { get; set; }
        public int PlotId { get; set; }
        public string Image { get; set; }
       
    }
    public class PlotImageReqDto
    {
        public int PlotId { get; set; }
    }
    public class PlotImageResponseDto:BaseDto
    {
        public Guid PlotImageGuid { get; set; }
        public long ImageId { get; set; }
        public int PlotId { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public bool DelMark { get; set; }
       
    }

    public class  PlotImageDeleteDto
    {
        public long PlotId { get; set; }    
        public Guid PlotImageGuid { get; set; }
    }
}
