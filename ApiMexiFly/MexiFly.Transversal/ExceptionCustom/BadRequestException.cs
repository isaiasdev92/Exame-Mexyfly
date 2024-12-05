using System;

namespace MexiFly.Transversal.ExceptionCustom;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message) {}

    public BadRequestException () : base("Solicitud incorrecta") {}
}
