namespace MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class User
{
   [Required]
   public string username {get; set; }
   [Required]
   [Key]
   [Column("user_id",Order =0)]
   public string Id {get; set; }


   [StringLength(200,ErrorMessage="sss")]
   public string email {get; set;}

    public string role {get; set;}

   
}
