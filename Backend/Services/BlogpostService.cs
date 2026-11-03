using Microsoft.EntityFrameworkCore;

public class BlogpostService : IBlogpostService
{
    private readonly PortfolioDB _db;
    
    public BlogpostService(PortfolioDB db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<BlogpostResponse>> GetAllBlogpostsAsync()
    {
        return await _db.Blogposts
            .Select(b => ToResponse(b))
            .ToListAsync();
    }
    
    public async Task<BlogpostResponse?> GetBlogpostByIdAsync(int id)
    {
        var blogpost = await _db.Blogposts.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        if (blogpost == null) 
        {
            return null;
        }

        return ToResponse(blogpost);
    }
    
    public async Task<BlogpostResponse> CreateBlogpostAsync(CreateBlogpostRequest request)
    {
        var blogpost = new Blogpost
        {
            Titel = request.Titel,
            Inhoud = request.Inhoud,
            Publicatiedatum = DateTime.Now
        };

        _db.Blogposts.Add(blogpost);
        await _db.SaveChangesAsync();

        return ToResponse(blogpost);
    }
    
    public async Task<bool> UpdateBlogpostAsync(int id, UpdateBlogpostRequest request)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        if (blogpost == null) 
        {
            return false;
        }

        blogpost.Titel = request.Titel;
        blogpost.Inhoud = request.Inhoud;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBlogpostAsync(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        if (blogpost == null)
        {
            return false;
        }

        _db.Blogposts.Remove(blogpost);
        await _db.SaveChangesAsync();
        return true;
    }
    
    private static BlogpostResponse ToResponse(Blogpost blogpost)
    {
        return new BlogpostResponse
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud,
            Publicatiedatum = blogpost.Publicatiedatum
        };
    }
}