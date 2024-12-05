using System;

namespace MexiFly.Transversal.ExceptionCustom;

public class InternalErrorException : ApplicationException
{
    public InternalErrorException(string message) : base(message) { }

    public InternalErrorException() : base("Error interno, por favor contacte al administrador.") { }
}