using MasWus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Handler
{
    public class ReplyHandler
    {
        public static List<Reply> RetrieveAllThreadReplies(int threadId)
        {
            return ReplyRepository.RetrieveAllThreadReplies(threadId);
        }

        public static void InsertReply(Reply reply)
        {
            ReplyRepository.InsertThreadReply(reply);
        }
    }
}