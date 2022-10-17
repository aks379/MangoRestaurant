namespace Mango.Web
{
    public static class StaticDetails
    {
        public static string ProductAPIBaseUrl { get; set; }

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
