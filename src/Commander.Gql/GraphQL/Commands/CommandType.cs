using System.Linq;
using Commander.Gql.Data;
using Commander.Gql.Models;
using HotChocolate;
using HotChocolate.Types;

namespace Commander.Gql.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command in the platform's command line interface.");

            descriptor
                .Field(c => c.Id)
                .Description("Represents the unique ID for the command.");
            descriptor
                .Field(c => c.HowTo)
                .Description("Represents the how-to for the command.");
            descriptor
                .Field(c => c.CommandLine)
                .Description("Represents the command line.");
            descriptor
                .Field(c => c.PlatformId)
                .Description("Represents the unique ID of the platform which this command belongs to.");
            descriptor
                .Field(c => c.Platform)
                .Description("Represents the platform which this command belongs to.")
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>();

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext dbContext)
            {
                return dbContext.Platforms.FirstOrDefault(c => c.Id == command.PlatformId);
            }
        }
    }
}
