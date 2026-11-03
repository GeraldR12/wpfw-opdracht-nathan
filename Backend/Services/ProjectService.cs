using Microsoft.EntityFrameworkCore;

public class ProjectService : IProjectService
{
    private readonly PortfolioDB _db;
    
    public ProjectService(PortfolioDB db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<ProjectResponse>> GetAllProjectsAsync()
    {
        return await _db.Projects
            .Select(p => ToResponse(p))
            .ToListAsync();
    }
    
    public async Task<ProjectResponse?> GetProjectByIdAsync(int id)
    {
        var project = await _db.Projects.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (project == null) 
        {
            return null;
        }

        return ToResponse(project);
    }
    
    public async Task<ProjectResponse> CreateProjectAsync(CreateProjectRequest request)
    {
        var project = new Project
        {
            Titel = request.Titel,
            Beschrijving = request.Beschrijving,
            Categorie = request.Categorie,
            GitHubUrl = request.GitHubUrl,
            Datum = DateTime.Now
        };

        _db.Projects.Add(project);
        await _db.SaveChangesAsync();

        return ToResponse(project);
    }
    
    public async Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null) 
        {
            return false;
        }

        project.Titel = request.Titel;
        project.Beschrijving = request.Beschrijving;
        project.Categorie = request.Categorie;
        project.GitHubUrl = request.GitHubUrl;

        await _db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteProjectAsync(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null) 
        {
            return false;
        }

        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();
        return true;
    }
    
    private static ProjectResponse ToResponse(Project project)
    {
        return new ProjectResponse
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        };
    }
}