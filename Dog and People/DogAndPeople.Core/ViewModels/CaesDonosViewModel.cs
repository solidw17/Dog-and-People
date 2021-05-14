using DogAndPeople.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeople.Core.ViewModels
{
    public class CaesDonosViewModel
    {
        public int Id { get; set; }
        public string Dono { get; set; }
        public string Cao { get; set; }
        [DisplayName("Nome do dono")]
        public IEnumerable<Donos> Donos { get; set; }
        [DisplayName("Nome do cão")]
        public IEnumerable<Caes> Caes { get; set; }
    }
}
