namespace ParallexTask1.Dto
{
    public class PostRequest<T>
    {
        public string Url { get; set; }
        public T Data { get; set; }
    }

    public class PostRequest2<T>
    {
        public string Url { get; set; }
        public string authorization { get; set; }
        public T Data { get; set; }
    }
}
