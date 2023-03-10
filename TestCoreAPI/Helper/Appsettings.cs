namespace TestCoreAPI.Helper
{
    public class Appsettings
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public double accessExpiration { get; set; }
        public double refreshExpiration { get; set; }
    }
}
