using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Models
{
    public class TeamListItems
    {
        public int TeamId { get; set; }
        public Guid OwnerId { get; set; }
        public string TeamName { get; set; }
    }
}
