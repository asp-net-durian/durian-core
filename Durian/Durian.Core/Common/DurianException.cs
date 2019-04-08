using System;
using System.Runtime.Serialization;

namespace Durian.Core.Common
{
    [Serializable]
    public class DurianException : Exception
    {
        public DurianException()
        {
        }

        public DurianException(string message)
            : base(message)
        {
        }

        public DurianException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }

        protected DurianException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DurianException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}