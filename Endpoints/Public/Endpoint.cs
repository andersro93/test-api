namespace TestApi.Endpoints.Public;

public class Endpoint : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/api/public");
        Description(e => e
            .WithName("Public")
            .WithSummary("Public endpoint")
            .WithDescription("This endpoint return some public info that does not require authentication"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = new Response()
        {
            Message = "Dette er en public beskjed"
        };

        await SendAsync(response, StatusCodes.Status200OK, ct);
    }
}