namespace ParallexTask1.Dto
{
    public class LoginResponse
    {
        public string?responseCode { get; set; }

        public string?responseMessage { get; set;}

        public string? token { get; set; }

        public string? expiration  { get; set; }
    }
}
