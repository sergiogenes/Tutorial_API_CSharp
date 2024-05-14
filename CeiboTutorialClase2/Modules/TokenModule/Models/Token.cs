namespace CeiboTutorialClase2.Modules.TokenModule.Models
{
    public class Token
    {
        public required string AccessToken { get; set; }

        public required DateTime ExpireIn { get; set; }
    }
}
