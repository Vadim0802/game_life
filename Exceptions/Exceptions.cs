using System;

namespace GameLife.Exceptions
{
    [Serializable]
    public class InvalidGameMapException : Exception
    {
        public InvalidGameMapException() : base("Невалидное игровое поле!") { }
        public InvalidGameMapException(string message) : base(message) { }
        public InvalidGameMapException(string message, Exception inner) : base(message, inner) { }
        protected InvalidGameMapException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidConfigException : Exception
    {
        public InvalidConfigException() : base("Неверный формат файла конфигурации!") { }
        public InvalidConfigException(string message) : base(message) { }
        public InvalidConfigException(string message, Exception inner) : base(message, inner) { }
        protected InvalidConfigException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
