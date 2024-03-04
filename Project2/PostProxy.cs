using System;

namespace Assi2
{
    class PostProxy : Content
    {
        private Post _post; // The Post object that is loaded on demand
        private bool _isDownloaded = false; // Check if the post has been downloaded or not. 

        // Clone method for Prototype pattern, returns a new PostProxy or cloned post.
        public override Content Clone()
        {
            if (_isDownloaded)
            {
                return _post.Clone();
            }
            else
            {
                return new PostProxy();
            }
        }

        // Simulates post download by creating a FancyPost object.
        public void Download(string title, string body)
        {
            _post = new FancyPost(title, body);
            _isDownloaded = true;
        }

        // Return the title
        protected override string GetPrintableTitle()
        {
            if (_isDownloaded)
            {
                return _post.GetPrintableTitle();
            }
            return "Loading post...";
        }

        // Return the body
        protected override string GetPrintableBody()
        {
            if (_isDownloaded)
            {
                return _post.GetPrintableBody();
            }
            return "Please wait, content is downloading.";
        }
    }
}
