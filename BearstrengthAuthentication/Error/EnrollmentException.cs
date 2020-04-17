using System;
using System.Collections.Generic;

namespace BearstrengthAuthentication.Error
{
    public class AuthenticationAppException : Exception
    {
        private static List<string> _messages;
        public List<string> Messages { get { return _messages; } }
        public AuthenticationAppException(List<string> messages)
            : base(string.Join(";", messages))
        {
            _messages = messages;
        }
        public AuthenticationAppException(List<string> messages, Exception exception)
            : base(string.Join(";", messages, exception)) { }
    }

    public class ConflictException : AuthenticationAppException
    {
        public ConflictException(List<string> messages)
            : base(messages) { }
        public ConflictException(List<string> messages, Exception exeption)
            : base(messages, exeption) { }
    }

}