using System;

namespace AntiMailApp
{
    public class SimpleClass
    {
        /// <exception cref="ArgumentException">command</exception>
        /// <exception cref="InvalidOperationException">Condition.</exception>
        public bool StringIsEmpty(string texy)
        {
            if (texy == string.Empty)
            {
                throw new ArgumentException("command");
            }
            else if (texy == "reset")
            {
                throw new InvalidOperationException();
            }
            
            else if (string.IsNullOrWhiteSpace(texy))
            {
                return true;
            }
            return false;
        }
    }
}