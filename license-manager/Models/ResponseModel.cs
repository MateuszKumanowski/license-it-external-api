namespace licenseItExternal.Models
{
    public class ResponseModel<T>
    {
        public int Status { get; set; }

        public string Description { get; set; }

        public T Data { get; set; }
    }
}