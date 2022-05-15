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


        private IQueryable<AnimalListViewModel> _getAnimalListIQueryable(Expression<Func<Data.Animals, bool>> expr, UserModel user)
        {
            return (from a in _context.Animals.AsExpandable().Where(expr)
                    select new AnimalListViewModel()
                    {
                        Id = (int)a.Id,
                        Name = a.Name,
                        Type = a.Type,
                        Birthdate = (DateTime)a.Birthdate,
                        Gender = (bool)a.Gender,
                        UserId = (int)a.UserId,
                    });
        }

        public IQueryable<AnimalListViewModel> GetAnimalListIQueryable(AnimalSearchViewModel animalSearchViewModel, UserModel user)
        {
            var predicate = PredicateBuilder.New<Data.Animals>(true);/*AND*/
            predicate.And(a => a.UserId == user.Id);
            if (!string.IsNullOrWhiteSpace(animalSearchViewModel.Name))
            {
                predicate.And(a => a.Name.Contains(animalSearchViewModel.Name));
            }

            return _getAnimalListIQueryable(predicate, user);
        }

        public async Task<AnimalListViewModel> GetAnimalListViewAsync(int animalId, UserModel user)
        {
            var predicate = PredicateBuilder.New<Animals>(true);/*AND*/
            predicate.And(a => a.Id == animalId);
            var product = await _getAnimalListIQueryable(predicate, user).SingleOrDefaultAsync().ConfigureAwait(false);
            return product;
        }


        public async Task<ServiceCallResult> AddAnimalsAsync(AnimalListViewModel model, UserModel user)
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
