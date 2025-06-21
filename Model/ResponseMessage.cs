namespace Model
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public int Status { get; set; }
    }

    public class Response<T> : ResponseMessage
    {
        public List<T> DataList { get; set; }
        
        public T Data { get; set; }
    }
}
