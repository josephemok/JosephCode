namespace JosephCode.Models
{
    public class ServiceResponds<T>
    {
        public T Data {get;set;}

        public bool Success {get;set;} = true;

        public string Message{get;set;} = null;
    }
}