using PayFlow.API.Endpoints;

namespace PayFlow.API.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            app.MapPaymentEndpoints();
            // Additional endpoint mappings can be added here
        }
    }
}
