using System;

namespace Assi2
{
    class Post : Content
    {
        //Get or set the title and body of the post
        public string Title { get; set; }
        public string Body { get; set; }

        // The constructor initializes a post instance with a title and body.
        // If not specified, set title and body as default.
        public Post(string title = "Default Title", string body = "Default Body")
        {
            this.Title = title;
            this.Body = body;
        }

        // Clone method for creating a duplicate Post instance with same title and body.
        public override Content Clone()
        {
            return new Post(Title, Body);
        }

        // Return the title.
        public override string GetPrintableTitle() => $"Title: {Title}";

        // Return the body.
        public override string GetPrintableBody() => $"Body: {Body}";
    }
}
