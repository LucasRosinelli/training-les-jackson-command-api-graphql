using System.Linq;
using Commander.Gql.Data;
using Commander.Gql.Models;
using HotChocolate;
using HotChocolate.Types;

namespace Commander.Gql.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the platform.");
            descriptor
                .Field(p => p.Name)
                .Description("Represents the name for the platform.");
            descriptor
                .Field(p => p.LicenseKey)
                .Ignore();
            descriptor
                .Field(p => p.Commands)
                .Description("Represents the list of available commands for this platform.")
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>();

            base.Configure(descriptor);
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext dbContext)
            {
                return dbContext.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}
