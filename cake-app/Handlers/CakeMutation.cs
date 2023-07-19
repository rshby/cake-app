using cake_app.Models.DTO;
using cake_app.Services;

namespace cake_app.Handlers
{
   public class CakeMutation
   {
      // method insert data cakes to database
      [GraphQLName("insert_cakes")]
      public async Task<CakesResponse?> InsertCakeAsync([Service] ICakeService cakeService, InsertCakesRequest? request)
      {
         return await cakeService.InsertCakeAsync(request);
      }

      // method untuk update data cakes
      [GraphQLName("update_cakes")]
      public async Task<CakesResponse?> UpdateCakeAsync([Service] ICakeService cakeService, UpdateCakesRequest? request)
      {
         return await cakeService.UpdateCakeAsync(request);
      }

      // method untuk delete data cakes
      [GraphQLName("delete_cakes")]
      public async Task<CakesResponse?> DeleteCakeAsync([Service] ICakeService cakeService, int? id)
      {
         return await cakeService.DeleteCakeAsync(id);
      }
   }
}
