namespace CeiboTutorialClase2.Domain.Entities.TokenModels
{
    public class Token
    {
        public required string AccessToken { get; set; }

        public required DateTime ExpireIn { get; set; }
    }
}
