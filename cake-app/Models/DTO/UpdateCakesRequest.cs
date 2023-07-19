using System.ComponentModel.DataAnnotations;

namespace cake_app.Models.DTO
{
   // object untuk request update
   [GraphQLName("update_cakes_request")]
   public class UpdateCakesRequest
   {
      [Required]
      [GraphQLName("id")]
      [GraphQLNonNullType]
      public int? Id { get; set; }

      [Required]
      [GraphQLName("name")]
      [GraphQLNonNullType]
      public string? Name { get; set; }

      [Required]
      [GraphQLName("price")]
      [GraphQLNonNullType]
      public int? Price { get; set; }

      [GraphQLName("description")]
      public string? Description { get; set; }
   }
}
