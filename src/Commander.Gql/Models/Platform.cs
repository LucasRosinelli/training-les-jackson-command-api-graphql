using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commander.Gql.Models
{
    /// <summary>
    /// Represents any software or service that has a command line interface.
    /// </summary>
    public class Platform
    {
        /// <summary>
        /// Represents the unique ID for the platform.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Represents the name for the platform.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Represents a purchased, valid license for the platform.
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Represents the list of available commands for this platform.
        /// </summary>
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
