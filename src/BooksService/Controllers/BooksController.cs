using BooksService.DTO;
using BooksService.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace BooksService.Controllers;

public class BooksController : ControllerBase
{
    [HttpGet("/books/{id}")]
    public async Task<ActionResult<GetBookResponse>> Get([FromServices] GetBookHandler handler, long id)
    {
        var result = await handler.Find(id);
        return Ok(result);
    }

    [HttpDelete("/books/{id}")]
    public async Task<ActionResult<GetBookResponse>> Delete([FromServices] GetBookHandler handler, long id)
    {
        var result = await handler.Find(id);
        return Ok(result);
    }

    [HttpPost("/books/{id}")]
    public async Task<ActionResult<GetBookResponse>> Create([FromServices] GetBookHandler handler, long id)
    {
        var result = await handler.Find(id);
        return Ok(result);
    }

    [HttpPut("/books/{id}")]
    public async Task<ActionResult<GetBookResponse>> Change([FromServices] GetBookHandler handler, long id)
    {
        var result = await handler.Find(id);
        return Ok(result);
    }
}