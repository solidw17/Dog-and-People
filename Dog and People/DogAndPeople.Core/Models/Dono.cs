using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeople.Core.Models
{
    public class Dono
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome do dono")]
        public string Name { get; set; }
    }
}
