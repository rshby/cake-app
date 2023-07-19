using cake_app.Models.DTO;
using cake_app.Services;

namespace cake_app.Handlers
{
   public class CakeQuery
   {
      // method untuk get all data cake
      [GraphQLName("cakes")]
      public async Task<List<CakesResponse>?> GetAllAsync([Service] ICakeService cakeService)
      {
         return await cakeService.GetAllCakesAsync();
      }

      // method untuk get data cakes by Id
      [GraphQLName("cake")]
      public async Task<CakesResponse?> GetByIdAsync([Service] ICakeService cakeService, int? id)
      {
         return await cakeService.GetCakeByIdAsync(id);
      }
   }
}
