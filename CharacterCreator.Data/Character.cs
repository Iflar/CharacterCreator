using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Data
{
    public class Character
    {
        /*
         requiered models:
        - detail = everything
        - create = all but id
        - edit = all but id
        - ListItem = Id + Title/Name
         */

        [Key]
        public Guid CharacterId { get; set; } //implement relationship to team
        public string Name { get; set; }
        public int Height { get; set; }
        public string Race { get; set; }
        public int Age { get; set; } 

        
    }
}
