using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Gql.Models
{
    /// <summary>
    /// Represents any command in the platform's command line interface.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Represents the unique ID for the command.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Represents the how-to for the command.
        /// </summary>
        [Required]
        public string HowTo { get; set; }

        /// <summary>
        /// Represents the command line.
        /// </summary>
        [Required]
        public string CommandLine { get; set; }

        /// <summary>
        /// Represents the unique ID of the platform which this command belongs to.
        /// </summary>
        [Required]
        public Guid PlatformId { get; set; }

        /// <summary>
        /// Represents the platform which this command belongs to.
        /// </summary>
        public Platform Platform { get; set; }
    }
}
