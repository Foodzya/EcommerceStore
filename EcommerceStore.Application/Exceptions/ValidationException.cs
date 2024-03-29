﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EcommerceStore.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ErrorMessages { get; private set; }
        public Dictionary<string, List<string>> FieldSpecificMessages { get; private set; }
        public List<string> GeneralMessages { get; private set; }

        public ValidationException(string exception, int itemId)
            : base(exception)
        {
            ValidateException(exception, itemId);
        }

        public ValidationException(string exception)
            : base(exception)
        {
            ErrorMessages = new List<string> { exception };
        }

        public ValidationException(ModelStateDictionary modelState)
        {
            Dictionary<string, string[]> extractedErrors = new();

            FieldSpecificMessages = modelState.Keys.ToDictionary(k => k, k => modelState[k].Errors.Select(e => e.ErrorMessage).ToList());
        }
        private void ValidateException(string message, int itemId)
        {
            ErrorMessages = new List<string> { string.Format(message, itemId) };
        }
    }
}