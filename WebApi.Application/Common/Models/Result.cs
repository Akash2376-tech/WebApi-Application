using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Common.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public Error? Error { get; set; }

        protected Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(Error error) => new Result(false,error);

    }

    public class Result<T> : Result
    {
        public T? Data { get; set; }
        private Result(bool isSuccess, T? data, Error? error):base(isSuccess,error)
        {
            Data = data;
        }

        public static Result<T> Success(T data) => new Result<T>(true,data,null);
        public static Result<T> Failure(Error error) => new Result<T>(false, default, error);
    }
}
