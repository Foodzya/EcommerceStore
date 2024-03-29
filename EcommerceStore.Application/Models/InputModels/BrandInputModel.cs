﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceStore.Application.Models.InputModels
{
    public class BrandInputModel
    {
        [Required]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Brand's name must be between 1 and 300 characters")]
        public string Name { get; set; }
        [Required]
        [Range(1, 2022, ErrorMessage = "Specify the correct foundation year")]
        public int FoundationYear { get; set; }
    }
}