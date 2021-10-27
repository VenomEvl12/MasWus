using MasWus.Handler;
using MasWus.Model;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasWus.View.Main.Home
{
    public partial class HomePage : System.Web.UI.Page
    {
        List<Thread> threads = null;
        List<HotThreadModel> hotThreads = new List<HotThreadModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            TheadSingelton.GetInsntance().SaveThreadID(0);
            if (!IsPostBack)
            {
                RetrieveAllThread();
                RetrieveAllHotThread();
            }
        }

        private void RetrieveAllThread()
        {
            if (Request["category"] == null ||Request["category"].Equals("All"))
            {
                threads = ThreadHandler.GetAllThread();
            }
            else
            {
                threads = ThreadHandler.RetrieveAllThread(Request["Category"]);
            }
            threads = threads.OrderByDescending(o => o.ThreadUpVote).ToList();
            repeaterThread.DataSource = threads;
            repeaterThread.DataBind();
        }

        private void RetrieveAllHotThread()
        {
            List<Thread> hThreads = ThreadHandler.RetrieveAllHotThread();
            foreach(Thread thread in hThreads)
            {
                string username = thread.User.AccountName;
                string imageUrl = "";
                if(thread.ThreadImages.Count > 0)
                {
                    imageUrl = ImageUtility.getInstance().ConvertToImage(thread.ThreadImages.FirstOrDefault().ImageData);
                }
                hotThreads.Add(new HotThreadModel(thread.ThreadId, thread.ThreadUpVote, thread.ThreadView, username, thread.Category.CategoryName, thread.ThreadTitle, thread.ThreadDescription, imageUrl));
            }
            repeaterHotThread.DataSource = hotThreads;
            repeaterHotThread.DataBind();
        }
    }
}