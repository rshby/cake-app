using cake_app.Models.DTO;
using cake_app.Models.Entity;

namespace cake_app.Services
{
   public interface ICakeService
   {
      // method get all data cakes
      public Task<List<CakesResponse>?> GetAllCakesAsync();

      // method get cakes by id
      public Task<CakesResponse?> GetCakeByIdAsync(int? id);

      // method insert new cakes data
      public Task<CakesResponse?> InsertCakeAsync(InsertCakesRequest? request);

      // method update cakes data
      public Task<CakesResponse?> UpdateCakeAsync(UpdateCakesRequest? request);

      // method untuk delete data cakes
      public Task<CakesResponse?> DeleteCakeAsync(int? id);
   }
}
