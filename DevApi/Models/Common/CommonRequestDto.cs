namespace DevApi.Models.Common
{
    public class CommonRequestDto
    {
        public int? CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageRecordCount { get; set; }
        public long UserId { get; set; }
        public Guid MCompanyGuid { get; set; }
        public Guid CompanyGuid { get; set; }
    }
    public class CommonRequestDto<T> : CommonRequestDto where T : class
    {
        public T? Data { get; set; }
    }
}