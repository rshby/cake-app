using cake_app.Models.DTO;
using cake_app.Models.Entity;
using cake_app.Repositories;

namespace cake_app.Services
{
   public class CakeService : ICakeService
   {
      // global variable
      private readonly CakeRepository _cakeRepo;

      // create constructor
      public CakeService(CakeRepository cakeRepo)
      {
         this._cakeRepo = cakeRepo;
      }

      public async Task<CakesResponse?> DeleteCakeAsync(int? id)
      {
         // call procedure delete from repository
         Cake? oldCake = await _cakeRepo.DeleteCakeByIdAsync(id);

         // jika data tidak ditemukan
         if (oldCake == null)
         {
            return null;
         }

         // success delete data -> mapping to DTO
         CakesResponse? response = new CakesResponse()
         {
            Id = oldCake.Id,
            Name = oldCake.Name,
            Price = oldCake.Price,
            Description = oldCake.Description
         };

         return response;
      }

      // method get all data cakes
      public async Task<List<CakesResponse>?> GetAllCakesAsync()
      {
         // call and receive response from repository
         List<Cake>? cakes = await _cakeRepo.GetAllCakeAsync();

         // jika data tidak ditemukan
         if (cakes == null)
         {
            return null;
         }

         List<CakesResponse>? responses = cakes.Select(x => new CakesResponse()
         {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
         }).ToList();

         // success get all data cakes
         return responses;
      }

      // method get data cakes by id
      public async Task<CakesResponse?> GetCakeByIdAsync(int? id)
      {
         // call procedure getbyid in repository
         Cake? cake = await _cakeRepo.GetCakeByIdAsync(id);

         // jika data yang diminta tidak ada
         if (cake == null)
         {
            throw new GraphQLException(ErrorBuilder.New().SetMessage("record not found").Build());
         }

         // success get data by id
         CakesResponse? response = new CakesResponse()
         {
            Id = cake.Id,
            Name = cake.Name,
            Price = cake.Price,
            Description = cake.Description,
         };

         return response;
      }

      // method insert new data cakes to database
      public async Task<CakesResponse?> InsertCakeAsync(InsertCakesRequest? request)
      {
         // create entity
         Cake cake = new Cake()
         {
            Name = request?.Name,
            Price = request?.Price,
            Description = request?.Description,
         };

         // call procedure insert in repository
         Cake? newCake = await _cakeRepo.InsertCakeAsync(cake);

         // jika gagal insert
         if (newCake == null)
         {
            return null;
         }

         // success insert
         CakesResponse? response = new CakesResponse()
         {
            Id = newCake.Id,
            Name = newCake.Name,
            Price = newCake.Price,
            Description = newCake.Description,
         };

         return response;
      }

      // method untuk update data cakes by id
      public async Task<CakesResponse?> UpdateCakeAsync(UpdateCakesRequest? request)
      {
         // cek data apakah ada di database
         Cake? oldCake = await _cakeRepo.GetCakeByIdAsync(request?.Id);

         // jika data tidak ditemukan di database
         if (oldCake == null)
         {
            return null;
         }

         // success get data yang akan diupdate -> create entity
         Cake? newCake = new Cake()
         {
            Id = request?.Id,
            Name = request?.Name,
            Price = request?.Price,
            Description = request?.Description,
         };

         // call procedure Update from repository
         Cake? updatedCake = await _cakeRepo.UpdateCakeAsync(newCake);

         // jika update gagal
         if (updatedCake == null)
         {
            return null;
         }

         // success update -> mapping to DTO
         CakesResponse? response = new CakesResponse()
         {
            Id = updatedCake.Id,
            Name = updatedCake.Name,
            Price = updatedCake.Price,
            Description = updatedCake.Description
         };

         return response;
      }
   }
}
