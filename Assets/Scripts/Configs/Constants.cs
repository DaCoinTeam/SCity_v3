public static class Constants
{
    public static class PlayerPrefs
    {
        public static readonly string SUI_MNEMONICS = "SuiMnemonics";
    }
    public static class Resources
    {
        private static readonly string SECRETS = "Secrets";
        public static class Secrets
        {
            public static readonly string CERT = $"{SECRETS}/Cert";
            public static readonly string PRIVATE_KEY = $"{SECRETS}/PrivateKey";
        }
    }
    public static class VPS
    {
        public static string MAPPING_URL = "wssscity.longphu.dev";
        public static string IPV4 = "103.162.14.225";
        public static ushort PORT = 1803;
    }
}