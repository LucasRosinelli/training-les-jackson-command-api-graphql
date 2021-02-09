using Commander.Gql.Models;

namespace Commander.Gql.GraphQL.Commands
{
    /// <summary>
    /// Represents the payload to return for an added <see cref="Commander.Gql.Models.Command"/>.
    /// </summary>
    public record AddCommandPayload(Command command);
}
