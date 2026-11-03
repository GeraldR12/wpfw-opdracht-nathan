public interface IBlogpostService
{
    Task<IEnumerable<BlogpostResponse>> GetAllBlogpostsAsync();
    Task<BlogpostResponse?> GetBlogpostByIdAsync(int id);
    Task<BlogpostResponse> CreateBlogpostAsync(CreateBlogpostRequest request);
    Task<bool> UpdateBlogpostAsync(int id, UpdateBlogpostRequest request);
    Task<bool> DeleteBlogpostAsync(int id);
}