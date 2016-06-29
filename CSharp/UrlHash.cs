string sourceString = "";
// "X" or "x" - Hexadecimal
string hashCode = String.Format("{0:X}", sourceString.GetHashCode());
Console.WriteLine(hashCode);