using BitirmeProjesi.Data;
using BitirmeProjesi.ViewModels.Common;
using BitirmeProjesi.ViewModels.User;
using Dapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Services.User
{
    public class AnimalsService
    {
        private readonly BitirmeProjesiEntities _context;
        public AnimalsService(BitirmeProjesiEntities context)
        {
            _context = context;
        }
        public List<AnimalsViewModel> AnimalsList(AnimalsViewModel model, UserModel user)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["BitirmeProjesiConnectionString"].ConnectionString))
            {
                string _sql = @"  
                                SELECT [Id]
                                      ,[Name]
                                      ,[Type]
                                      ,[Birthdate]
                                      ,[Gender]
                                      ,[UserId]
                                  FROM [BitirmeProjesi].[dbo].[Animals] where UserId=@userId";
                var animalsList = (db.Query<AnimalsViewModel>(_sql, new { userId = user.Id })).ToList();
                return animalsList;
            }
        }

        public async Task<ServiceCallResult> AddAnimalsAsync(AnimalsViewModel model, UserModel user)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var animal = new Animals()
            {
                Name = model.Name,
                Type = model.Type,
                Birthdate = model.Birthdate,
                Gender = model.Gender,
                UserId = user.Id,
            };

            _context.Animals.Add(animal);

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbTransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = animal.Id;
                    callResult.SuccessMessages.Add("Hayvan Başarılı Şekilde Eklendi");
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }

        public async Task<List<VaccineListViewModel>> GetVaccineListViewModel(int animalId)
        {
            var vaccineList = await (from b in _context.AnimalsVaccinations.AsExpandable()
                                     where b.AnimalId == animalId

                                     select new VaccineListViewModel()
                                     {

                                         Id = (int?)b.Id,
                                         AnimalId = animalId,
                                         VaccineName = b.VaccineName,
                                         VaccinationDate = (DateTime)b.VaccinationDate,
                                         RecurrenceDate = (DateTime)b.RecurrenceDate
                                     }).ToListAsync();
            return vaccineList;
        }

        public async Task<ServiceCallResult> AddVaccineAsync(VaccineListViewModel model, UserModel user)
        {
            var callResult = new ServiceCallResult() { Success = false };

            var vaccine = new AnimalsVaccinations()
            {
                VaccineName = model.VaccineName,
                VaccinationDate = model.VaccinationDate,
                RecurrenceDate = model.RecurrenceDate,
                AnimalId = model.AnimalId,
            };

            _context.AnimalsVaccinations.Add(vaccine);

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    dbTransaction.Commit();
                    callResult.Success = true;
                    callResult.Item = vaccine.Id;
                    callResult.SuccessMessages.Add("Aşı Başarılı Şekilde Eklendi");
                    return callResult;
                }
                catch (Exception exc)
                {
                    callResult.ErrorMessages.Add(exc.GetBaseException().Message);
                    return callResult;
                }
            }
        }
    }
}
