public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> GetAllProjectsAsync();
    Task<ProjectResponse?> GetProjectByIdAsync(int id);
    Task<ProjectResponse> CreateProjectAsync(CreateProjectRequest request);
    Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request);
    Task<bool> DeleteProjectAsync(int id);
}