using MasWus.Handler;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasWus.View.Main.ManageThread.EditThread
{
    public partial class EditThread : System.Web.UI.Page
    {
        protected System.Collections.ArrayList threadList = null;
        protected string[] imageUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                Response.Redirect("/View/Login/Login.aspx");
            }
            retrieveAllThread();
            thread_repeater.DataSource = threadList;
            thread_repeater.DataBind();
            if (!Page.IsPostBack)
            {
                repeaterImage.DataSource = imageUrl;
                repeaterImage.DataBind();
            }
        }

        private void retrieveAllThread()
        {
            User user = (User) Session["User"];
            List<Thread> threads = ThreadHandler.RetrieveAllThread(user.UserId);
            threadList = new System.Collections.ArrayList(threads);
            
        }

        private void createImageUrl(int threadId)
        {
            List<ThreadImage> images = ThreadHandler.RetrieveAllThreadImage(threadId);
            imageUrl = new string[images.Count];
            int i = 0;
            foreach (ThreadImage image in images)
            {
                imageUrl[i] = ImageUtility.getInstance().ConvertToImage(image.ImageData);
                i++;
            }
            repeaterImage.DataSource = imageUrl;
            repeaterImage.DataBind();
        }

        protected void BtnThread_Click(object sender, EventArgs e)
        {
            int threadId = int.Parse(threadEditValue.Value);
            TheadSingelton.GetInsntance().SaveThreadID(threadId);
            System.Diagnostics.Debug.WriteLine(threadId);
            System.Diagnostics.Debug.WriteLine(TheadSingelton.GetInsntance().GetThreadID());
            Thread thread = ThreadHandler.RetrieveThread(threadId);
            threadTitle.Text = thread.ThreadTitle;
            threadDescription.Text = thread.ThreadDescription;
            threadCategory.SelectedIndex = thread.CategoryId - 1;
            createImageUrl(thread.ThreadId);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string title = threadTitle.Text;
            string description = threadDescription.Text;
            int category = threadCategory.SelectedIndex + 1;
            int threadId = int.Parse(threadEditValue.Value);
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                Response.Write("<script>alert('Update Failed !');</script>");
                Response.Redirect("/View/Main/ManageThread/EditThread/EditThread.aspx");
                return;
            }
            TheadSingelton.GetInsntance().SaveThreadID(0);
            ThreadHandler.UpdateThread(threadId, title, description, category);

            Response.Write("<script>alert('Update Success !');</script>");
            Response.Redirect("/View/Main/ManageThread/EditThread/EditThread.aspx");
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int index = int.Parse(e.CommandName);
            int x = 0;
            User user = (User)Session["User"];
            List<Thread> threads = ThreadHandler.RetrieveAllThread(user.UserId);
            threadList = new System.Collections.ArrayList(threads);

            foreach (Thread thread in threadList)
            {
                if(thread.ThreadId == int.Parse(threadEditValue.Value))
                {
                    int i = 0;
                    x = thread.ThreadId;
                    foreach(ThreadImage image in thread.ThreadImages)
                    {
                        if(i == index)
                        {
                            ThreadHandler.deleteThreadImage(image.ImageId, thread.ThreadId);
                            break;
                        }
                        i++;
                    }
                }
            }
            createImageUrl(x);
            repeaterImage.DataSource = imageUrl;
            repeaterImage.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(TheadSingelton.GetInsntance().GetThreadID());
            if (TheadSingelton.GetInsntance().GetThreadID() != 0)
            {
                ThreadHandler.DeleteThread(TheadSingelton.GetInsntance().GetThreadID());
                Response.Redirect("/View/Main/ManageThread/EditThread/EditThread.aspx");
            }
            else
            {
                Response.Write("<script>alert('Delete Failed !');</script>");
            }
        }
    }
}