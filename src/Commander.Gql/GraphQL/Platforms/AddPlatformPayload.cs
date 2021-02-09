using Commander.Gql.Models;

namespace Commander.Gql.GraphQL.Platforms
{
    /// <summary>
    /// Represents the payload to return for an added <see cref="Commander.Gql.Models.Platform"/>.
    /// </summary>
    public record AddPlatformPayload(Platform platform);
}
