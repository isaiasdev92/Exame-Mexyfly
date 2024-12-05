using System;

namespace WebMexiFly.Utils;

public class ResponseGeneral<T>
{
    public string Message { get; set; } = string.Empty;

    public string Requestid { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public T? Data { get; set; }
}

