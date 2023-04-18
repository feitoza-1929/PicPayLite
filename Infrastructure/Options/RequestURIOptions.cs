namespace PicPayLite.Infrastructure.Options
{
    public class RequestURIOptions
    {
        public static readonly string RequestURI = "RequestURI";
        public IDictionary<string, string> URIs { get; set; } = new Dictionary<string, string>();
    }
}