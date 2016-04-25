using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_StructLayout
{
    [StructLayout(LayoutKind.Explicit)]
    public struct FloatingPointExplorer
    {
        [FieldOffset(0)] public int F; // use float.

        [FieldOffset(0)] public bool B1; // byte for float.
        [FieldOffset(1)] public bool B2;
        [FieldOffset(2)] public bool B3;
        [FieldOffset(3)] public bool B4;
    }

    class Program
    {
        static void Main(string[] args)
        {
            FloatingPointExplorer str = new FloatingPointExplorer();
            str.F = 4;
            Console.WriteLine(str.B1);
        }
    }
}
