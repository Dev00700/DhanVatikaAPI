using MyApp.Models.Common;

namespace DevApi.Models
{
    public class DashboardResponseDto
    {
        public string Inflow { get; set; }    
        public decimal InflowAmt { get; set; }
        public string Outflow { get; set; }
        public decimal OutflowAmt { get; set; }
        public decimal BalanceAmt { get; set; }
    }
    public class DashboardReqDto:BaseDto
    {
       
    }
}
