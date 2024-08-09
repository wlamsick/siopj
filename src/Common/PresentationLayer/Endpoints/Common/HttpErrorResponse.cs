namespace Common.Presentation.Endpoints.Common;

public record HttpErrorResponse
{
    public HttpErrorResponse()
    {
        Errors = Array.Empty<object>();
    }

    public string Type { get; set; } = "Error";
    public string Title { get; set; } = "One or more errors occurred.";
    public int Status { get; set; }
    public object[] Errors { get; set; }    
}
