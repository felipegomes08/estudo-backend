using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackendPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]

        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(80)]

        public string Email { get; set; }
        [Required]

        public string Senha { get; set; }
    }
}
