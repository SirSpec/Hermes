namespace Hermes.Client.Web.Options;

public class PaymentApiOptions
{
    public required string BaseAddress { get; init; }
    public required string PaymentRequestsEndpointPath { get; init; }
}