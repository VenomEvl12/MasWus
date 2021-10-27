using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Repository
{
    public class ReplyRepository
    {
        public static List<Reply> RetrieveAllThreadReplies(int threadId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.Replies join u in db.Users on x.userID equals u.UserId where x.threadID == threadId select x;
            List<Reply> replies = (query).ToList();
            return replies;
        }

        public static void InsertThreadReply(Reply reply)
        {
            MasWusEntities db = new MasWusEntities();
            db.Replies.Add(reply);
            db.SaveChanges();
        }
    }
}