public sealed class BlogpostResponse
{
    public int Id { get; init; }
    public string Titel { get; init; } = string.Empty;
    public string Inhoud { get; init; } = string.Empty;
    public DateTime Publicatiedatum { get; init; }
}