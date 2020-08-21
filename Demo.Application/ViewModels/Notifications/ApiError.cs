using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ViewModels.Notifications
{
    public class ApiError
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }
        public IList<ValidationFailure> errors { get; set; }

        public ApiError(string message, string detail = "")
        {
            this.message = message;
            isError = true;
            this.detail = detail;
        }

        public ApiError(IList<ValidationFailure> errors)
        {
            this.errors = errors;
            isError = true;
        }        
    }
}
