using System;

namespace MexiFly.Transversal.ExceptionCustom;

    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message) { }
    }
