using Microsoft.AspNetCore.Mvc;
using ProfissionaisService.api.Dto;

namespace ProfissionaisService.api.Controllers;

public class ApiController : ControllerBase
{
    protected SuccessResponse<T> Success<T>(T data)
    {
        return new SuccessResponse<T>(data);
    }

    protected ErrorResponse<T> Error<T>(T error)
    {
        return new ErrorResponse<T>(error);
    }
}