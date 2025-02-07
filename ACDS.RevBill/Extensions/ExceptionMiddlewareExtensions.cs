﻿using System;
using ACDS.RevBill.Contracts;
using ACDS.RevBill.Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using ACDS.RevBill.Entities.Exceptions;
using Serilog;

namespace ACDS.RevBill.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                       // logger.LogError($"Something went wrong: {contextFeature.Error.Message}, {contextFeature.Endpoint}, " + $"{contextFeature.Error.Source}");

                        Log.Error($"Something went wrong: {contextFeature.Error.Message}, {contextFeature.Endpoint}, " + $"{contextFeature.Error.Source}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}