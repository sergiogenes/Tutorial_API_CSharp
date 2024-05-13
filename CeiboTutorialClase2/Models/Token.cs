namespace CeiboTutorialClase2.Models
{
    public class Token
    {
        public required string AccessToken { get; set; }

        public required DateTime ExpireIn { get; set; }
    }
}
