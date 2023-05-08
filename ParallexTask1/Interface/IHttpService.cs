using ParallexTask1.Dto;

namespace ParallexTask1.Interface
{
    public interface IHttpService
    {   
        Task<T> SendPostRequest<T, U>(PostRequest<U> request);

        Task<T> SendAuthPostRequest<T, U>(PostRequest2<U> request);
    }
}
