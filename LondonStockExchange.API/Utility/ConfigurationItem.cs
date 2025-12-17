namespace LondonStockExchange.Utility
{
    public class ConfigurationItem
    {
        public string? ConnectionString { get; set; }
        public JwTAuthentication JwTAuthentication { get; set; } = new();
    }

    public class JwTAuthentication
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
