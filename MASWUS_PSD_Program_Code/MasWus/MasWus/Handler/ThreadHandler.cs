using MasWus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Handler
{
    public class ThreadHandler
    {
        public static void InsertDraft(Draft draft)
        {
            ThreadRepository.InsertDraft(draft);
        }

        public static Thread InsertThread(Thread thread)
        {
            return ThreadRepository.InsertThread(thread);
        }

        public static List<Draft> RetrieveAllDraft(int userId)
        {
            return ThreadRepository.GetAllDraft(userId);
        }

        public static void DeleteDraft(int draftId)
        {
            ThreadRepository.deleteDraft(draftId);
        }

        public static void InsertImage(ThreadImage image)
        {
            ThreadRepository.InsertThreadImage(image);
        }

        public static List<Thread> RetrieveAllThread(int userId)
        {
            return ThreadRepository.GetAllThread(userId);
        }

        public static List<Thread> GetAllThread()
        {
            return ThreadRepository.retrieveAllThread();
        }

        public static Thread RetrieveThread(int threadId)
        {
            return ThreadRepository.GetThread(threadId);
        }

        public static List<Thread> RetrieveAllThread(string category)
        {
            return ThreadRepository.RetrieveAllThread(category);
        }

        public static List<ThreadImage> RetrieveAllThreadImage(int threadId)
        {
            return ThreadRepository.getAllThreadImage(threadId);
        }

        public static void UpdateThread(int threadId, string title, string description, int category)
        {
            ThreadRepository.UpdateThread(threadId, title, description, category);
        }

        public static List<Thread> RetrieveAllHotThread()
        {
            return ThreadRepository.RetrieveAllHotThread();
        }

        public static void deleteThreadImage(int imageId, int threadId)
        {
            ThreadRepository.DeleteThreadImage(imageId, threadId);
        }

        public static void DeleteThread(int threadId)
        {
            ThreadRepository.DeleteThread(threadId);
        }

        public static void AddView(int threadId)
        {
            ThreadRepository.UpdateView(threadId);
        }
        
        public static void UpVoteValidation(int userId, int threadId)
        {
            ThreadRepository.UpdateThreadLike(userId, threadId);
        }
    }
}