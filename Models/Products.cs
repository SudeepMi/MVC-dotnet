namespace MVC.Models;
using System.ComponentModel.DataAnnotations;
public class Products
{
   [Required]
   public string Name {get; set; }

   [StringLength(200,ErrorMessage="sss")]
   public string Code {get; set;}

   public string ID {get; set;}

   [Range(100,5000,ErrorMessage ="Price must be less than 5000")]
   public double Price {get; set;}


}
