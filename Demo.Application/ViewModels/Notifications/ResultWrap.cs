using FluentValidation.Results;
using Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ViewModels.Notifications
{
    public class ResultWrap<T>
    {
        public bool IsSuccess;
        public EKnowErrors? Error = null;
        public IList<ValidationFailure> Errors;

        public T Data = default(T);

        public ResultWrap() { }
        public ResultWrap(T initialData) { Data = initialData; }
        public ResultWrap(bool sucess, string errorMessage, T result = default(T), IList<ValidationFailure> errors = null)
        {
            IsSuccess = sucess;
            Errors = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            Data = result;
            Errors = errors;
        }

        public ResultWrap(string message, EKnowErrors error = EKnowErrors.UnknowError)
        {
            Error = error;
            IsSuccess = false;
            Errors = new List<ValidationFailure> { new ValidationFailure(string.Empty, message) }; 
        }

        public ResultWrap<T> SetError(IList<ValidationFailure> errors, EKnowErrors error = EKnowErrors.UnknowError)
        {
            Error = error;
            IsSuccess = false;
            Errors = errors;
            return this;
        }

        public ResultWrap<T> SetError(string message, EKnowErrors error = EKnowErrors.UnknowError)
        {
            Errors = new List<ValidationFailure> { new ValidationFailure(string.Empty, message) };
            IsSuccess = false;
            return this;
        }

        public ResultWrap<T> SetError(IList<ValidationFailure> errors)
        {
            IsSuccess = false;
            Errors = errors;
            return this;
        }

        public ResultWrap<T> SetSuccess(T data)
        {
            IsSuccess = true;
            Data = data;
            return this;
        }

        public ResultWrap<T> SetSuccess()
        {
            IsSuccess = true;
            return this;
        }
    }
}
