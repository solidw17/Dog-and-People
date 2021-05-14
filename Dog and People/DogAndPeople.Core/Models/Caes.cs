using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeople.Core.Models
{
    public class Caes : BaseEntity
    {
        [Required]
        [DisplayName("Nome do cão")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Raça do cão")]
        public string Race { get; set; }
    }
}
