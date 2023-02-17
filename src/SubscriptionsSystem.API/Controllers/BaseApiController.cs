﻿using Microsoft.AspNetCore.Mvc;
using SubscriptionsSystem.Domain.Shared;

namespace SubscriptionsSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected IActionResult HandleResult<T>(OperationResult<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Error);
    }
}