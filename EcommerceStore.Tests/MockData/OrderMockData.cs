﻿using EcommerceStore.Application.Models.InputModels;
using EcommerceStore.Application.Models.ViewModels;
using EcommerceStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EcommerceStore.Application.Enums.OrderStatusEnum;

namespace EcommerceStore.Tests.MockData
{
    public static class OrderMockData
    {
        public static Order GetOrder(int id, StatusesEnum status, bool isDeleted)
        {
            var order = new Order
            {
                Id = id,
                ModifiedDate = DateTime.UtcNow,
                Status = status.ToString(),
                IsDeleted = isDeleted,
                UserId = 1,
                User = new User
                {
                    Email = "somemail@gmail.com",
                    PhoneNumber = "123123123"
                }
            };

            return order;
        }

        public static OrderInputModel GetOrderInputModelWithExceedProductAmount()
        {
            var orderInputModel = new OrderInputModel
            {
                ProductsDetails = new List<ProductDetailsForOrderInputModel>
                {
                    new ProductDetailsForOrderInputModel
                    {
                        ProductAmount = 1000,
                        ProductId = 1
                    }
                }
            };

            return orderInputModel;
        }

        public static OrderInputModel GetOrderInputModelForCreating()
        {
            var orderInputModel = new OrderInputModel
            {
                ProductsDetails = new List<ProductDetailsForOrderInputModel>
                {
                    new ProductDetailsForOrderInputModel
                    {
                        ProductAmount = 1,
                        ProductId = 1
                    },
                    new ProductDetailsForOrderInputModel
                    {
                        ProductAmount = 1,
                        ProductId = 2
                    }
                }
            };

            return orderInputModel;
        }
    }
}
