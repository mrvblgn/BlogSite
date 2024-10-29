using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace blogSite.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery]Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CreateCommentRequest dto)
    {
        var result = _commentService.Add(dto);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCommentRequest dto)
    {
        var result = _commentService.Update(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _commentService.Remove(id);
        return Ok(result);
    }
}