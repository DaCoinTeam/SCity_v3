public static class AddressUtility
{
    public static string ShortenAddress(string address)
    {
        if (string.IsNullOrEmpty(address)) return "";
        return $"{address[..4]}...{address[^2..]}";
    }
}