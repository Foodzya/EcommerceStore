﻿using EcommerceStore.Domain.Entities;

namespace EcommerceStore.Domain.Interfaces
{
    public interface IBrandRepository
    {
        public Task<Brand> GetByIdAsync(int brandId);
        public Task<IEnumerable<Brand>> GetAllAsync();
        public Task CreateAsync(Brand brand);
        public Task RemoveAsync(Brand brand);
        public Task UpdateAsync(Brand brand);
        public Task SaveChangesAsync();
    }
}