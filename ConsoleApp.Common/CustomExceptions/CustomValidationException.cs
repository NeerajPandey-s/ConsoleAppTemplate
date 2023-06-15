using System;

namespace ConsoleApp.Common.CustomExceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message)
        {

        }
    }
}