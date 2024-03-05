using System;

namespace Assi2
{
    class FancyPost : Post
    {
        class FancyPost : Post
        {
            public FancyPost(string t, string b) : base(t, b) { }

            public override string GetPrintableTitle() => $"==== {Title} ====";
            public override string GetPrintableBody() => $"--------------------\n{Body}";

            public override Post Clone() { return new FancyPost(Title, Body); }
        }
    }
}
