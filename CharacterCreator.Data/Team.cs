using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public Guid OwnerId { get; set; }

        public string TeamName { get; set; }

        public string Description { get; set; }
    }
}
