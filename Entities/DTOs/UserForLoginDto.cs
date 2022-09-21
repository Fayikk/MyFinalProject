namespace Entities.DTOs
{
    //Sisteme login olmak isteyen kişilerden istenen verilerin tutulduğu sınıftır.
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
