using System;
namespace BearstrengthApi.Error
{

    public class NotFoundException: Exception
    {
        public NotFoundException(string message, Exception exception)
            : base (message) { }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string message)
            : base(message) { }
    }

}