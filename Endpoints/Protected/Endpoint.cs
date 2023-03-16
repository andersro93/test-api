namespace TestApi.Endpoints.Protected;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("/api/protected");
        Description(e => e
            .WithName("Protected")
            .WithSummary("Protected endpoint")
            .WithDescription("This endpoint is only accessible with a valid access token")
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = new Response()
        {
            Message = "Dette er en beskyttet beskjed som kun er synlig om du har et gyldig access token"
        };

        await SendAsync(response, StatusCodes.Status200OK, ct);
    }
}