﻿using System.Runtime.Serialization;

namespace Inventory.Implementations
{
    [Serializable]
    internal class InsufficientInventoryException : Exception
    {
        public InsufficientInventoryException()
        {
        }

        public InsufficientInventoryException(string? message) : base(message)
        {
        }

        public InsufficientInventoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InsufficientInventoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}