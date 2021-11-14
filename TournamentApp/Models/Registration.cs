using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentApp.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DiscordId { get; set; }
        public string TeamCheck { get; set; }
        [AllowNull]
        public string TeamName { get; set; }
        public string Game { get; set; }
        public string RulesCheck { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
