﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Education : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public  string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Color { get; set; }

        public  List<Group>  Group { get; set; }

    }
}
