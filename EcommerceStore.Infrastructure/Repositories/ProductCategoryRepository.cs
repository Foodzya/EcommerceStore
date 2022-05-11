﻿using EcommerceStore.Domain.Entities;
using EcommerceStore.Domain.Interfaces;
using EcommerceStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStore.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EcommerceContext _context;

        public ProductCategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ProductCategory productCategory)
        {
            await _context.ProductCategories.AddAsync(productCategory);
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            var productCategories = await _context.ProductCategories
                .Include(p => p.Products)
                .ToListAsync();

            return productCategories;
        }

        public async Task<ProductCategory> GetByIdAsync(int productCategoryId)
        {
            return await _context.ProductCategories
                .Include(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == productCategoryId);
        }

        public void Remove(ProductCategory productCategory)
        {
            _context.ProductCategories.Remove(productCategory);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ProductCategory productCategory)
        {
            _context.ProductCategories.Update(productCategory);
        }
    }
}