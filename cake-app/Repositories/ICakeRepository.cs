using cake_app.Models.Entity;

namespace cake_app.Repositories
{
   public interface ICakeRepository
   {
      // method read all data cakes
      public Task<List<Cake>?> GetAllCakeAsync();

      // method read data cakes by id
      public Task<Cake?> GetCakeByIdAsync(int? id);

      // method cread new data cakes
      public Task<Cake?> InsertCakeAsync(Cake? newCake);

      // method update data cakes
      public Task<Cake?> UpdateCakeAsync(Cake? newCake);

      // method Delete data cakes by Id
      public Task<Cake?> DeleteCakeByIdAsync(int? id);
   }
}
