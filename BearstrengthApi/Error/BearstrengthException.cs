using System;
using System.Collections.Generic;

namespace BearstrengthApi.Error
{
    public class BearstrengthException : Exception
    {
        private static List<string> _messages;
        public List<string> Messages { get { return _messages; } }
        public BearstrengthException(List<string> messages)
            : base(string.Join(";", messages))
        {
            _messages = messages;
        }
        public BearstrengthException(List<string> messages, Exception exception)
            : base(string.Join(";", messages, exception)) { }
    }

    public class ConflictException : BearstrengthException
    {
        public ConflictException(List<string> messages)
            : base(messages) { }
        public ConflictException(List<string> messages, Exception exeption)
            : base(messages, exeption) { }
    }

}