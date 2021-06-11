namespace ECOMMERCE.CORE.Models
{
    public class ResponseModel<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Model { get; set; }
    }
}
