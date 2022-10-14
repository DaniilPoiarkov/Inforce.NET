using Inforce.NET.BLL.Services.Static;
using Xunit;

namespace Inforce.NET.BLL.UnitTests
{
    public class UrlShortenerServiceTests
    {
        private static string _url = "https://www.google.com/search?q=images&oq=images&aqs=chrome.0.69i59l2j0i512l4j69i60l2.1468j0j7&sourceid=chrome&ie=UTF-8#imgrc=GTOsfXGJyz8O-M";

        [Fact]
        public void UrlShortener_WhenPassingLink_ShoulReturnShortedVersion()
        {
            var url = UrlShortenerService.GenerateShortUrl(UrlShortenerService.GenerateKey(_url));

            Assert.True(_url.Length > url.Length);
        }
    }
}