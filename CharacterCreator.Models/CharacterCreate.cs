using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Models
{
    public class CharacterCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
