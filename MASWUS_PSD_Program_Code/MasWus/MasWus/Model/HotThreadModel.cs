using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Model
{
    public class HotThreadModel
    {
        public HotThreadModel(int threadId, int threadUpVote, int threadView, string username, string category, string title, string description, string imageUrl)
        {
            this.threadId = threadId;
            this.threadUpVote = threadUpVote;
            this.threadView = threadView;
            this.username = username;
            this.category = category;
            threadTitle = title;
            threadDescription = description;
            this.imageUrl = imageUrl;
        }
        public int threadId { get; set; }
        public int threadUpVote { get; set; }
        public int threadView { get; set; }
        public string username { get; set; }
        public string category { get; set; }
        public string imageUrl { get; set; }
        public string threadTitle { get; set; }
        public string threadDescription { get; set; }
    }
}