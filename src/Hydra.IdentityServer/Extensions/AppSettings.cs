namespace Hydra.IdentityServer.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int TimeExpiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}