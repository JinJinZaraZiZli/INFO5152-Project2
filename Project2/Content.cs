using System;

namespace Assi2
{
    abstract class Content
    {
        public abstract Content Clone();

        //Print the content's title and body
        public void Print()
        {
            Console.WriteLine(GetPrintableTitle());
            Console.WriteLine(GetPrintableBody());
        }

        protected abstract string GetPrintableTitle();
        protected abstract string GetPrintableBody();
    }
}
