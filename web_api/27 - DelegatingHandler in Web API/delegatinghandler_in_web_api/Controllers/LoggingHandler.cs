
namespace delegatinghandler_in_web_api.Controllers
{
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the Request
            Console.WriteLine("Request:");
            Console.WriteLine(request.ToString());
            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            // Process the request
            var response = await base.SendAsync(request, cancellationToken);

            // Log the response
            Console.WriteLine("Response:");
            Console.WriteLine(response.ToString());
            if(response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}
