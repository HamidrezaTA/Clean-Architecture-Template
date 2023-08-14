namespace API.Extensions.Response;

public class ErrorModel
{
    public string? Message { get; set; }
    public Dictionary<string, List<string>>? BulkMessages { get; set; } = null;
    public string? Code { get; set; }
}
