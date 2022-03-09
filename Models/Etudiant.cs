using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Models
{
    [Table("etudiant")]
    public class Etudiant
    {
        [Key]

        public int Id { get; set; }


        [Required, StringLength(25)]
        public String Nom { get; set; }

        public int Age { get; set; }

   
    
    
    }
}
