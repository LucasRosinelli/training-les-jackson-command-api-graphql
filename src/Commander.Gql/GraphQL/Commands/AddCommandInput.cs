using System;

namespace Commander.Gql.GraphQL.Commands
{
    /// <summary>
    /// Represents the input to add for a <see cref="Commander.Gql.Models.Command"/>.
    /// </summary>
    public record AddCommandInput(string HowTo, string CommandLine, Guid PlatformId);
}
