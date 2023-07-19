using System.ComponentModel.DataAnnotations;

namespace cake_app.Models.DTO
{
   [GraphQLName("insert_cakes_request")]
   public class InsertCakesRequest
   {
      [Required]
      [StringLength(255)]
      [GraphQLName("name")]
      [GraphQLNonNullType]
      public string? Name { get; set; }

      [Required]
      [GraphQLName("price")]
      [GraphQLNonNullType]
      public int? Price { get; set; }

      [GraphQLName("description")]
      [StringLength(255)]
      public string? Description { get; set; }

   }
}
