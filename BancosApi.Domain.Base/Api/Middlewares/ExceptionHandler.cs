﻿using BancosApi.Domain.Base.Api.Models;
using BancosApi.Domain.Base.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace BancosApi.Domain.Base.Api.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(InvalidDomainStateException ex)
            {
                await SetErrorResponse(ResponseErrorBody.BadRequest(ex.Message, ex.Notifications), ex, context);
            }
            catch(NoResultsException ex)
            {
                await SetErrorResponse(ResponseErrorBody.NotFound(ex.Message, ex.Notifications), ex, context);
            }
            catch (InfrastructureFailedException ex)
            {
                await SetErrorResponse(ResponseErrorBody.ServerError(ex.Message, ex.Notifications), ex, context);
            }
            catch (SqlException ex)
            {
                await SetErrorResponse(ResponseErrorBody.ServerError(ex.Message), ex, context);
            }
            catch (Exception ex)
            {
                await SetErrorResponse(ResponseErrorBody.ServerError(ex.Message), ex, context);
            }
        }

        private async Task SetErrorResponse(ResponseErrorBody body, Exception ex, HttpContext context)
        {
            _logger.LogError(ex, "ERROR {httpMethod} {path}{queryString}",
                context.Request.Method,
                context.Request.Path.HasValue ? context.Request.Path : "",
                context.Request.QueryString.HasValue ? $"?{context.Request.QueryString}" : ""
                );
            context.Response.StatusCode = body.StatusCode;
            await context.Response.WriteAsJsonAsync(body);
        }
    }
}
