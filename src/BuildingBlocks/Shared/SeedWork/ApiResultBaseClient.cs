namespace Shared.SeedWork
{
    public class ApiResultBaseClient<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
    }
}
