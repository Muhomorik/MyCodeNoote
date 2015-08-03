using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sideways_overriding_with_partial_methods
{

    // Generated code
    partial class UglyHack1
    {
        partial void ToStringOverride(bool ignored, ref string value);

        public override string ToString()
        {
            string value = null;
            bool overridden = false;
            ToStringOverride(overridden = true, ref value);
            return overridden ? value : "Original";
        }
    }

    // Generated code
    partial class UglyHack2
    {
        partial void ToStringOverride(bool ignored, ref string value);

        public override string ToString()
        {
            string value = null;
            bool overridden = false;
            ToStringOverride(overridden = true, ref value);
            return overridden ? value : "Original";
        }
    }

    // Manual code
    partial class UglyHack2
    {
        partial void ToStringOverride(bool ignored, ref string value)
        {
            value = "Different!";
        }
    }

    /// <summary>
    /// Trying to play with Skeet's code. Original script.
    /// <a href="http://codeblog.jonskeet.uk/2015/07/27/sideways-overriding-with-partial-methods/">Original here</a>.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            var g1 = new UglyHack1();
            var g2 = new UglyHack2();

            Console.WriteLine(g1);
            Console.WriteLine(g2);

        }
    }
}
