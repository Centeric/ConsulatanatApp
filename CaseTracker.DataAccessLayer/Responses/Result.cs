using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseTracker.DataAccessLayer.Responses
{
    public class Result
    {
        private Result(bool isSuccess, string message, object? data = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        private Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public static Result Success(string message)
        {
            return new Result(true, message);
        }

        public static Result Success(string message, object data)
        {
            return new Result(true, message, data);
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }

        public static Result Failure(string message, object data)
        {
            return new Result(false, message, data);
        }
    }
    public class Consonants
    {
        public static readonly HashSet<string> AllowedExtensions = new HashSet<string> { ".pdf", ".doc", ".png", ".jpg", ".docx" };

    }
}
