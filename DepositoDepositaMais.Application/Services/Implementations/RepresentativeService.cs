using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Application.ViewModels;
using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepositoDepositaMais.Application.Services.Implementations
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public RepresentativeService(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateNewRepresentative(NewRepresentativeInputModel inputModel)
        {
            var representative = new Representative(
                inputModel.ProviderId,
                inputModel.RepresentativeName,
                inputModel.Birthday,
                inputModel.CPF,
                inputModel.PhoneNumber,
                inputModel.Email,
                inputModel.Description
                );
            _dbContext.Representatives.Add(representative);

            _dbContext.SaveChanges();

            return representative.Id;
        }

        public void UpdateRepresentative(UpdateRepresentativeInputModel inputModel)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == inputModel.Id);
            representative.Update(
                inputModel.ProviderId,
                inputModel.RepresentativeName,
                inputModel.Birthday,
                inputModel.CPF,
                inputModel.PhoneNumber,
                inputModel.Email,
                inputModel.Description
                );

            _dbContext.SaveChanges();
        }

        public List<RepresentativeViewModel> GetAll(string query)
        {
            var representative = _dbContext.Representatives;
            var representativeViewModel = representative
                .Select(r => new RepresentativeViewModel(
                    r.ProviderId,
                    r.RepresentativeName,
                    r.PhoneNumber,
                    r.Email,
                    r.Description)
                ).ToList();

            return representativeViewModel;
        }

        public RepresentativeDetailsViewModel GetById(int id)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == id);
            var representativeDetailsViewModel = new RepresentativeDetailsViewModel(
                representative.Id,
                representative.ProviderId,
                representative.RepresentativeName,
                representative.Birthday,
                representative.CPF,
                representative.PhoneNumber,
                representative.Email,
                representative.Description,
                representative.Status,
                representative.CreatedAt
                );
            
            return representativeDetailsViewModel;
        }

        public void ActivateRepresentative(int id)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == id);
            representative.Activate();

            _dbContext.SaveChanges();
        }

        public void DeleteRepresentative(int id)
        {
            var representative = _dbContext.Representatives.SingleOrDefault(r => r.Id == id);
            representative.Inactivate();

            _dbContext.SaveChanges();
        }
    }
}
