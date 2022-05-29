using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, MaxLength(256)]  
        public string Name { get; set; }
    }
}
