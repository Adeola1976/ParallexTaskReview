using System.ComponentModel.DataAnnotations;

namespace ParallexTask1.Dto
{
    public record UserForAuthenticationDto
    {
        [Required]
        public string? UserName { get; init; }
        [Required]
        public string? Password { get; init; }
    }
}
