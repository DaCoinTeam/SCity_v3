public static class Constants
{
    public static class PlayerPrefs
    {
        public static readonly string SuiMnemonics = "SuiMnemonics";
    }
    public static class Resources
    {
        private static readonly string SecretsPath = "Secrets";
        public static class Secrets
        {
            public static readonly string CertPath = $"{SecretsPath}/Cert";
            public static readonly string PrivateKeyPath = $"{SecretsPath}/PrivateKey";
        }
    }

    public static class Environment
    {
        public static class Production
        {
            public static string MappingUrl = "wssscity.longphu.dev";
            public static string IpV4 = "103.162.14.225";
            public static ushort Port = 1803;
        }
    }
    
}