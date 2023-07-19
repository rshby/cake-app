using cake_app.Data;
using cake_app.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace cake_app.Repositories
{
   public class CakeRepository : ICakeRepository
   {
      // global variable
      private readonly CakeContext _ctx;

      // create constructor
      public CakeRepository(CakeContext ctx)
      {
         this._ctx = ctx;
      }

      // method delete cakes by id
      public async Task<Cake?> DeleteCakeByIdAsync(int? id)
      {
         Cake? oldData = await _ctx.Cakes.Where(x => x.Id == id).FirstOrDefaultAsync<Cake>();

         // jika data yang akan dihapus tidak ditemukan di database
         if (oldData == null)
         {
            return null;
         }

         _ctx.Cakes.Remove(oldData);
         await _ctx.SaveChangesAsync();

         // success delete data cakes
         return oldData;
      }

      // method get all data cakes
      public async Task<List<Cake>?> GetAllCakeAsync()
      {
         List<Cake>? cakes = await _ctx.Cakes.AsQueryable().ToListAsync();

         // jika cake tidak ada isinya
         if(cakes == null || cakes.Count == 0)
         {
            return null;
         }

         // success get all data cakes
         return cakes;
      }

      // method get cake by id
      public async Task<Cake?> GetCakeByIdAsync(int? id)
      {
         Cake? cake = await _ctx.Cakes.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync<Cake>();

         // jika data tidak ditemukan
         if (cake == null)
         {
            return null;
         }

         // success get data cakes by id
         return cake;
      }

      // method insert data cake to database
      public async Task<Cake?> InsertCakeAsync(Cake? newCake)
      {
         // insert to database
         await _ctx.Cakes.AddAsync(newCake);

         int? resultInsert = await _ctx.SaveChangesAsync();

         // jika gagal update
         if (resultInsert < 1)
         {
            return null;
         }

         // success insert data cakes to database
         return newCake;
      }

      // method update data cake by id
      public async Task<Cake?> UpdateCakeAsync(Cake? newCake)
      {
         // get old_data cakes
         Cake? oldCake = _ctx.Cakes.AsQueryable().Where(x => x.Id == newCake.Id).FirstOrDefault<Cake>();     

         //_ctx.Update(newCake);
         _ctx.Cakes.Entry(oldCake).CurrentValues.SetValues(newCake);

         await _ctx.SaveChangesAsync();

         // succes update record
         return newCake;
      }
   }
}
