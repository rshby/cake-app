namespace cake_app.Models.DTO
{
   // dto response graphql
   [GraphQLName("cake_response")]
   public class CakesResponse
   {
      [GraphQLName("id")]
      [GraphQLNonNullType]
      public int? Id { get; set; }

      [GraphQLName("name")]
      [GraphQLNonNullType]
      public string? Name { get; set; }

      [GraphQLName("price")]
      [GraphQLNonNullType]
      public int? Price { get; set; }

      [GraphQLName("description")]
      public string? Description { get; set; }
   }
}
