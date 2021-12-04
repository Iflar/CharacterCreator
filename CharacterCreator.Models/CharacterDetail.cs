using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Models
{
    public class CharacterDetail
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
    }
}