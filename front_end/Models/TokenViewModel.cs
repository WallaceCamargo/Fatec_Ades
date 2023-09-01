namespace front_end.Models
{
    public class TokenViewModel
    {
        public bool Authenticated { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
        public string? Message { get; set;}

    }
}
