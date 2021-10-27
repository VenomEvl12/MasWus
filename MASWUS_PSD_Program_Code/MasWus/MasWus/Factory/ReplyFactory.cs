using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Factory
{
    public class ReplyFactory
    {
        public static Reply createReply(int threadId, int userId, string description)
        {
            Reply reply = new Reply();
            reply.threadID = threadId;
            reply.userID = userId;
            reply.replyDescription = description;

            return reply;
        }
    }
}