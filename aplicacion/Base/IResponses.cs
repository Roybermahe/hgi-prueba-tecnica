namespace aplicacion.Base;

public interface IResponses
{
    int code { get; set; }
    object data { get; set; }
    string message { get; set; }
}

public class Response: IResponses
{
    public int code { get; set; }
    public object data { get; set; }
    public string message { get; set; }
}