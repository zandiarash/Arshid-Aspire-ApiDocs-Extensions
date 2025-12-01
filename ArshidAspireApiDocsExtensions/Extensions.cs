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
            commandOptions: new CommandOptions
            {
                IconName = "Link",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithCustomUrl(
        this IResourceBuilder<ProjectResource> builder, string CustomUrl)
    {
        builder.WithCommand(
            name: "CustomUrl",
            displayName: CustomUrl,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomUrl: CustomUrl),
            commandOptions: new CommandOptions
            {
                IconName = "Globe",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithOpenApi(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "OpenApi",
            displayName: "OpenApi",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/OpenApi/v1.json"),
            commandOptions: new CommandOptions
            {
                IconName = "Document",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithScalar(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Scalar",
            displayName: "Scalar",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Scalar/v1"),
            commandOptions: new CommandOptions
            {
                IconName = "BookOpen",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    public static IResourceBuilder<ProjectResource> WithSwagger(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Swagger",
            displayName: "Swagger",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Swagger/index.html"),
            commandOptions: new CommandOptions
            {
                IconName = "Code",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    private static Task<ExecuteCommandResult> OnLinkOpenerCommandAsync(
        IResourceBuilder<ProjectResource> builder,
        ExecuteCommandContext context,
        string? Route = null,
        string? CustomUrl = null,
        bool IsHttps = false
        )
    {
        string? url;
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
        return Task.FromResult(CommandResults.Success());
    }
}