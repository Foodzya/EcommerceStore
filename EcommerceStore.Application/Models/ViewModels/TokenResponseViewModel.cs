﻿namespace EcommerceStore.Application.Models.ViewModels
{
    public class TokenResponseViewModel
    {
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
