using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceStore.Application.Models.InputModels;
using EcommerceStore.Application.Models.ViewModels;
using EcommerceStore.Domain.Entities;

namespace EcommerceStore.Application.Interfaces
{
    public interface ISectionService
    {
        public Task<List<SectionViewModel>> GetAllSectionsAsync();
        public Task<SectionViewModel> GetSectionByIdAsync(int sectionId);
        public Task RenameSectionAsync(int sectionId, SectionInputModel sectionInputModel);
        public Task RemoveSectionAsync(int sectionId);
        public Task CreateSectionAsync(SectionInputModel sectionInputModel);
        public Task LinkCategoryToSectionAsync(int productCategoryId, int sectionId);
    }
}