using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Factory
{
    public class ThreadFactory
    {

        public static Draft CreateDraft(String title, String description, int category, int userId)
        {
            Draft draft = new Draft();
            draft.CategoryId = category;
            draft.UserId = userId;
            draft.ThreadTitle = title;
            draft.ThreadDescription = description;

            return draft;
        }

        public static ThreadImage CreateThreadImage(int threadId, byte[] data)
        {
            ThreadImage image = new ThreadImage();
            image.ThreadId = threadId;
            image.ImageData = data;

            return image;
        }

        public static Thread CreateThread(String title, String description, int category, int userId)
        {
            Thread thread = new Thread();
            thread.CategoryId = category;
            thread.UserId = userId;
            thread.ThreadTitle = title;
            thread.ThreadDescription = description;
            thread.ThreadUpVote = 0;
            thread.ThreadView = 0;
            thread.ThreadDateCreated = DateTime.Now;

            return thread;
        }
        
        public static UpVoteValidation CreateUpVoteValidation(int userId, int threadId)
        {
            UpVoteValidation validation = new UpVoteValidation();
            validation.userID = userId;
            validation.ThreadID = threadId;
            validation.status = 1;
            return validation;
        }
    }
}