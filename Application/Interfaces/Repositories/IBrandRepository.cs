﻿using EcommerceStore.Infrastucture.Persistence.Models.InputModels;
using EcommerceStore.Infrastucture.Persistence.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceStore.Application.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        public Task<BrandViewModel> GetByIdAsync(int brandId);
        public Task<IEnumerable<BrandViewModel>> GetAllAsync();
        public Task AddAsync(BrandInputModel brandIm);
        public Task RemoveByIdAsync(int brandId);
        public Task ModifyAsync(int brandId, BrandInputModel brandIm);
    }
}