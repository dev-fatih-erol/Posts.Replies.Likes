using System.Linq;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Posts.Replies.Likes.Application.Exceptions;

namespace Posts.Replies.Likes.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GlobalExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            if (exception is ValidationException validationException)
            {
                var errors = validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(e => e.Key, e => e
                    .Select(e => e.ErrorMessage)
                    .ToList());

                context.Result = new JsonResult(errors);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is NotFoundException)
            {
                context.Result = new JsonResult(exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                if (_webHostEnvironment.IsDevelopment())
                    return;

                context.Result = new JsonResult("An error occurred, Please try again.");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}