using System;

namespace MexiFly.Transversal.ExceptionCustom;

    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message) { }
    }

