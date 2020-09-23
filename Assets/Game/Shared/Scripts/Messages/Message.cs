using System;

namespace Game.Shared
{
    public abstract class Message<T> where T : Enum
    {
        public T Type { get; protected set; }

        public Message(T type)
        {
            Type = type;
        }
    }
}
