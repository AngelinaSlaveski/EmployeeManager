using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EmployeeManager.RazorPages.Models
{
    public partial class Country
    {
        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}
