using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore_3_0.Entities
{
    public class Creator
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
