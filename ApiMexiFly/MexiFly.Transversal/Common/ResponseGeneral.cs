using System;

namespace MexiFly.Transversal.Common;

public class ResponseGeneral<T>
{
    public string Message { get; set; } = string.Empty;

    public string Requestid { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public T? Data { get; set; }
}
