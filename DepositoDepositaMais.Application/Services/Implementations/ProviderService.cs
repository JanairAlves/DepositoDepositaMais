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
    public class ProviderService : IProviderService
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;

        public ProviderService(DepositoDepositaMaisDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public int CreateNewProvider(NewProviderInputModel inputModel)
        {
            var provider = new Provider(
                inputModel.ProviderName,
                inputModel.Description,
                inputModel.CNPJ,
                inputModel.Site,
                inputModel.EmailAddress,
                inputModel.PhoneNumber,
                inputModel.ProviderType
                );
            _dbContext.Providers.Add(provider);
             
            return provider.Id;
        }

        public void UpdateProvider(UpdateProviderInputModel inputModel)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == inputModel.Id);
            provider.Update(
                inputModel.providerName,
                inputModel.Description,
                inputModel.CNPJ,
                inputModel.Site,
                inputModel.EmailAddress,
                inputModel.PhoneNumber,
                inputModel.ProviderType
                );
        }

        public List<ProviderViewModel> GetAll(string query)
        {
            var provider = _dbContext.Providers;
            var providerViewModel = provider
                .Select(p => new ProviderViewModel(
                    p.ProviderName,
                    p.CNPJ,
                    p.Site,
                    p.EmailAddress,
                    p.PhoneNumber)
                ).ToList();

            return providerViewModel;
        }

        public ProviderDetailsViewModel GetById(int id)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == id);
            var providerDetailsViewModel = new ProviderDetailsViewModel(
                provider.Id,
                provider.ProviderName,
                provider.Description,
                provider.CNPJ,
                provider.Site,
                provider.EmailAddress,
                provider.PhoneNumber,
                provider.ProviderType,
                provider.Status,
                provider.CreatedAt
                );
            
            return providerDetailsViewModel;
        }

        public void ActivateProvider(int id)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == id);
            provider.Activate();
        }
    
        public void DeleteProvider(int id)
        {
            var provider = _dbContext.Providers.SingleOrDefault(p => p.Id == id);
            provider.Inactivate();
        }
    }
}
