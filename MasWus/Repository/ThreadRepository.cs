using MasWus.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Repository
{
    public class ThreadRepository
    {
        public static void InsertDraft(Draft draft)
        {
            using(MasWusEntities db = new MasWusEntities())
            {
                db.Drafts.Add(draft);
                db.SaveChanges();
            }
        }

        public static List<Draft> GetAllDraft(int userId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.Drafts join cat in db.Categories on x.CategoryId equals cat.CategoryId where x.UserId == userId select x;
            List<Draft> drafts = (query).ToList();
            return drafts;
        }

        public static List<Thread> retrieveAllThread()
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.Threads join c in db.Categories on x.CategoryId equals c.CategoryId join u in db.Users on x.UserId equals u.UserId select x;
            List<Thread> threads = (query).ToList();
            return threads;
        }

        public static void deleteDraft(int draftId)
        {
            using(MasWusEntities db = new MasWusEntities())
            {
                var query = from x in db.Drafts where x.DraftId == draftId select x;
                Draft draft = (query).FirstOrDefault();
                if(draft == null)
                {
                    return;
                }
                db.Drafts.Remove(draft);
                db.SaveChanges();
            }
        }

        public static List<Thread> RetrieveAllThread(string category)
        {
                MasWusEntities db = new MasWusEntities();
                var query = from x in db.Threads join c in db.Categories on x.CategoryId equals c.CategoryId join u in db.Users on x.UserId equals u.UserId where c.CategoryName == category select x;
                List < Thread > threads = (query).ToList();
                return threads;
        }

        public static List<Thread> GetAllThread(int userId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.Threads where x.UserId == userId select x;
            List<Thread> threads = (query).ToList();
            return threads;
        }

        public static List<Thread> RetrieveAllHotThread()
        {
            MasWusEntities db = new MasWusEntities();
            var query = (from x in db.Threads join c in db.Categories on x.CategoryId equals c.CategoryId join u in db.Users on x.UserId equals u.UserId orderby x.ThreadView descending select x).Take(5);
            List<Thread> threads = query.ToList();
            return threads;
        }

        public static List<ThreadImage> getAllThreadImage(int threadId)
        {
            using (MasWusEntities db = new MasWusEntities())
            {
                var query = from x in db.ThreadImages where x.ThreadId == threadId select x;
                List<ThreadImage> threads = (query).ToList();
                return threads;
            }
        }

        public static Thread GetThread(int threadId)
        {
            MasWusEntities db = new MasWusEntities();
                var query = from x in db.Threads where x.ThreadId == threadId select x;
                Thread thread = (query).FirstOrDefault();
                return thread;
        }

        public static void UpdateThread(int threadId, string title, string description, int category)
        {
            using(MasWusEntities db = new MasWusEntities())
            {
                var query = from x in db.Threads where x.ThreadId == threadId select x;
                Thread thread = (query).FirstOrDefault();
                thread.ThreadTitle = title;
                thread.ThreadDescription = description;
                thread.CategoryId = category;
                db.SaveChanges();
            }
        }

        public static Thread InsertThread(Thread thread)
        {
            using(MasWusEntities db = new MasWusEntities())
            {
                Thread thr = db.Threads.Add(thread);
                db.SaveChanges();
                return thr;
            }
        }

        public static void InsertThreadImage(ThreadImage image)
        {
            using(MasWusEntities db = new MasWusEntities())
            {
                db.ThreadImages.Add(image);
                db.SaveChanges();
            }
        }

        public static void DeleteThreadImage(int threadImageId, int threadId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.ThreadImages where x.ImageId == threadImageId && x.ThreadId == threadId  select x;
            ThreadImage image = (query).FirstOrDefault();
            if(image != null)
            {
                db.ThreadImages.Remove(image);
                db.SaveChanges();
            }
        }

        public static void DeleteThread(int threadId) 
        {
            MasWusEntities db = new MasWusEntities();
            var reply = from t in db.Replies where t.threadID == threadId select t;
            List<Reply> replies = (reply).ToList();
            if(replies != null)
            {
                db.Replies.RemoveRange(replies);
                db.SaveChanges();
            }
            var image = from z in db.ThreadImages where z.ThreadId == threadId select z;
            List<ThreadImage> threadImages = (image).ToList();
            if(threadImages != null)
            {
                db.ThreadImages.RemoveRange(threadImages);
                db.SaveChanges();
            }
            var like = from y in db.UpVoteValidations where y.ThreadID == threadId select y;
            List<UpVoteValidation> validations = (like).ToList();
            if(validations != null)
            {
                db.UpVoteValidations.RemoveRange(validations);
                db.SaveChanges();
            }
            var query = from x in db.Threads where x.ThreadId == threadId select x;
            Thread thread = (query).FirstOrDefault();
            if(thread != null)
            {
                db.Threads.Remove(thread);
                db.SaveChanges();
            }
        }

        public static void UpdateView(int threadId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.Threads where x.ThreadId == threadId select x;
            Thread thread = (query).FirstOrDefault();
            if(thread != null)
            {
                thread.ThreadView += 1;
                db.SaveChanges();
            }
        }

        public static void UpdateThreadLike(int userId, int threadId)
        {
            MasWusEntities db = new MasWusEntities();
            var query = from x in db.UpVoteValidations where x.ThreadID == threadId && x.userID == userId select x;
            UpVoteValidation validation = (query).FirstOrDefault();
            if(validation == null)
            {
                UpVoteValidation val = ThreadFactory.CreateUpVoteValidation(userId, threadId);
                db.UpVoteValidations.Add(val);
                var queryThread = from y in db.Threads where y.ThreadId == threadId select y;
                Thread thread = (queryThread).FirstOrDefault();
                thread.ThreadUpVote += 1;
                db.SaveChanges();
            }
            else
            {
                if(validation.status == 1)
                {
                    validation.status = 0;
                    db.SaveChanges();
                    var queryThread = from y in db.Threads where y.ThreadId == threadId select y;
                    Thread thread = (queryThread).FirstOrDefault();
                    thread.ThreadUpVote -= 1;
                    db.SaveChanges();
                }
                else
                {
                    validation.status = 1;
                    db.SaveChanges();
                    var queryThread = from y in db.Threads where y.ThreadId == threadId select y;
                    Thread thread = (queryThread).FirstOrDefault();
                    thread.ThreadUpVote += 1;
                    db.SaveChanges();
                }
            }
        }
    }
}