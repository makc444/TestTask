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
    public async Task<ActionResult> Delete([FromServices] DeleteBookHandler handler, long id)
    {
        await handler.Delete(id);
        return Ok();
    }

    [HttpPost("/books/")]
    public async Task<ActionResult<CreateBookResponse>> Create([FromServices] CreateBookHandler handler,
        [FromBody] CreateBookRequest request)
    {
        var result = await handler.Create(request);
        return Ok(result);
    }

    [HttpPut("/books/")]
    public async Task<ActionResult<GetBookResponse>> Change([FromServices] PutBookHandler handler,
        [FromBody] ChangeBookRequest request)
    {
        var result = await handler.Change(request);
        return Ok(result);
    }
}