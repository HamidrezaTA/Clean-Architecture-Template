namespace API.Extensions.Response;

public class JsonResponse<T>
{
    public JsonResponse(bool success = false)
    {
        Success = success;

        if (!success)
        {
            Error = new ErrorModel();
        }
    }

    public bool Success { get; set; }
    public T? Result { get; set; }
    public ErrorModel? Error { get; set; }
}
