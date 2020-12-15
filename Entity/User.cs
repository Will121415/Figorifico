  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User
    {
        
        [Key]
        [Column(TypeName= "nvarchar(30)")]
        public string UserName { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string Password { get; set; }
        [Column(TypeName= "nvarchar(15)")]
        public string Status { get; set; }
        [Column(TypeName= "nvarchar(15)")]
        public string Role { get; set; }
    }
}