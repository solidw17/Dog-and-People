﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeople.Core.Models
{
    public class CaesDonos : BaseEntity
    {
        [Required]
        public int Id_dono { get; set; }
        [Required]
        public int Id_cao { get; set; }
    }
}
