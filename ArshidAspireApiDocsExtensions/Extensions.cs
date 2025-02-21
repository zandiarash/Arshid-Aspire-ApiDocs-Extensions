namespace Arshid.Aspire.ApiDocs.Extensions;
public static class Extensions
{
    public static IResourceBuilder<ProjectResource> WithRoute(
       this IResourceBuilder<ProjectResource> builder, string CustomRoute)
    {
        builder.WithCommand(
            name: CustomRoute,
            displayName: CustomRoute,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomRoute),
            iconName: "Accessibility",
            iconVariant: IconVariant.Filled);

        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithCustomUrl(
        this IResourceBuilder<ProjectResource> builder, string CustomUrl)
    {
        builder.WithCommand(
            name: "CustomUrl",
            displayName: CustomUrl,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomUrl: CustomUrl),
            iconName: "Accessibility",
            iconVariant: IconVariant.Filled);

        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithOpenApi(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "OpenApi",
            displayName: "OpenApi",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/OpenApi/v1.json"),
            iconName: "Accessibility",
            iconVariant: IconVariant.Filled);

        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithScalar(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Scalar",
            displayName: "Scalar",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Scalar/v1"),
            iconName: "Accessibility",
            iconVariant: IconVariant.Filled);

        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithSwagger(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Swagger",
            displayName: "Swagger",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Swagger/index.html"),
            iconName: "Accessibility",
            iconVariant: IconVariant.Filled);

        return builder;
    }

    private static async Task<ExecuteCommandResult> OnLinkOpenerCommandAsync(
        IResourceBuilder<ProjectResource> builder,
        ExecuteCommandContext context,
        string Route = null,
        string CustomUrl = null,
        bool IsHttps = false
        )
    {
        var url = string.Empty;
        if (!string.IsNullOrEmpty(CustomUrl))
            url = CustomUrl;
        else
            url = $"{builder.GetEndpoint(IsHttps ? "https" : "http").Url}{Route}";
        var ps = new System.Diagnostics.ProcessStartInfo(url)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        System.Diagnostics.Process.Start(ps);
        return CommandResults.Success();
    }
}