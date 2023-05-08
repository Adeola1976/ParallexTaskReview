namespace ParallexTask1.Dto
{
    public class TokenDtos
    {
        public record TokenDto (string AccessToken, string RefreshToken);
    }
}
