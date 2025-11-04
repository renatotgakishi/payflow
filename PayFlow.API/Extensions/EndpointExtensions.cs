using PayFlow.API.Endpoints;

namespace PayFlow.API.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapApiEndpoints(this WebApplication app)
        {
            app.MapPaymentEndpoints();

            // pode adicionar outros endpoints aqui no futuro
        }
    }
}
