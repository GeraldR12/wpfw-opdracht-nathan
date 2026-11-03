using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BlogpostsController : ControllerBase
{
    private readonly IBlogpostService _blogpostService;

    public BlogpostsController(IBlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogpostResponse>>> GetAllBlogposts()
    {
        var blogposts = await _blogpostService.GetAllBlogpostsAsync();
        return Ok(blogposts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostResponse>> GetBlogpostById(int id)
    {
        var blogpost = await _blogpostService.GetBlogpostByIdAsync(id);
        if (blogpost == null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostResponse>> CreateBlogpost(CreateBlogpostRequest request)
    {
        var blogpost = await _blogpostService.CreateBlogpostAsync(request);
        return CreatedAtAction(nameof(GetBlogpostById), new { id = blogpost.Id }, blogpost);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBlogpost(int id, UpdateBlogpostRequest request)
    {
        var updated = await _blogpostService.UpdateBlogpostAsync(id, request);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBlogpost(int id)
    {
        var deleted = await _blogpostService.DeleteBlogpostAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}