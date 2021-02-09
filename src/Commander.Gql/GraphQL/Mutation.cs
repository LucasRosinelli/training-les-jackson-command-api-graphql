using System.Threading;
using System.Threading.Tasks;
using Commander.Gql.Data;
using Commander.Gql.GraphQL.Commands;
using Commander.Gql.GraphQL.Platforms;
using Commander.Gql.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace Commander.Gql.GraphQL
{
    /// <summary>
    /// Represents the mutations available.
    /// </summary>
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        /// <summary>
        /// Adds a <see cref="Platform"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddPlatformInput"/>.</param>
        /// <param name="dbContext">The <see cref="AppDbContext"/>.</param>
        /// <param name="eventSender">The <see cref="ITopicEventSender"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The added <see cref="Platform"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a platform.")]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext dbContext, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var platform = new Platform()
            {
                Name = input.Name,
            };

            dbContext.Platforms.Add(platform);
            await dbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        /// <summary>
        /// Adds a <see cref="Command"/> based on <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="AddCommandInput"/>.</param>
        /// <param name="dbContext">The <see cref="AppDbContext"/>.</param>
        /// <returns>The added <see cref="Command"/>.</returns>
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a command.")]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext dbContext)
        {
            var command = new Command()
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId,
            };

            dbContext.Commands.Add(command);
            await dbContext.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}
