﻿namespace CiberWeb.Common
{
    public class ErrorResult<T>:Result<T>
    {
        public string[] ValidationErrors { get; set; }

        public ErrorResult()
        {
        }

        public ErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
