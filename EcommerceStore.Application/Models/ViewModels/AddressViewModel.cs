﻿namespace EcommerceStore.Application.Models.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string UserFullName { get; set; }
    }
}