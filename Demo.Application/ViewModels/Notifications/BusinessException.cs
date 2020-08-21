using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ViewModels.Notifications
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(IEnumerable<ApiError> errors)
        {
            this.Errors = errors;
        }

        public IEnumerable<ApiError> Errors { get; set; }
    }
}
