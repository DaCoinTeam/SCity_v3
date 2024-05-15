public static class AddressUtility
{
    public static string ShortenAddress(string address)
    {
        return $"{address[..4]}...{address[^2..]}";
    }
}