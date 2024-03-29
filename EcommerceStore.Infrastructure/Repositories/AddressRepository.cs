﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceStore.Domain.Entities;
using EcommerceStore.Domain.Interfaces;
using EcommerceStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStore.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EcommerceContext _context;

        public AddressRepository(EcommerceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public async Task<List<Address>> GetAllForUserAsync(int userId)
        {
            return await _context.Addresses
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int addressId)
        {
            return await _context.Addresses
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == addressId);
        }

        public void Remove(Address address)
        {
            _context.Addresses.Remove(address);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
        }
    }
}