
using MasWus.Factory;
using MasWus.Handler;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasWus.View.Main.ManageThread.CreateThread
{
    public partial class CreateThread : System.Web.UI.Page
    {
        public User user;
        public bool errorMessage = false;
        public bool errorFile = false;
        public List<Draft> drafts;

        protected void Page_Load(object sender, EventArgs e)
        {
            TheadSingelton.GetInsntance().SaveThreadID(0);
            if (Session["User"] == null)
            {
                Response.Redirect("/View/Login/Login.aspx");
            }
            user = (User)Session["User"];
            GetListDraft(user.UserId);
        }

        private void GetListDraft(int userId)
        {
            drafts = ThreadHandler.RetrieveAllDraft(userId);
            draftRepeater.DataSource = drafts;
            draftRepeater.DataBind();
        }

        private bool ValidationInput(string title, string description)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                return false;
            }

            return true;
        }

        protected void SaveDraft_Click(object sender, EventArgs e)
        {
            errorMessage = false;
            if(!ValidationInput(threadTitle.Text, threadDescription.Text))
            {
                errorMessage = true;
                return;
            }
            ThreadHandler.InsertDraft(ThreadFactory.CreateDraft(threadTitle.Text, threadDescription.Text, category.SelectedIndex + 1, user.UserId));
            Response.Redirect(Request.RawUrl);
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            errorMessage = false;
            System.Diagnostics.Debug.WriteLine(threadTitle.Text, threadDescription.Text);
            if (!ValidationInput(threadTitle.Text, threadDescription.Text))
            {
                errorMessage = true;
                return;
            }
            if (!uploadImage.HasFiles)
            {
                System.Diagnostics.Debug.WriteLine("masuk");
                Thread thread = ThreadHandler.InsertThread(ThreadFactory.CreateThread(threadTitle.Text, threadDescription.Text, category.SelectedIndex + 1, user.UserId));
            }
            if (uploadImage.HasFiles)
            {
                foreach(HttpPostedFile file in uploadImage.PostedFiles)
                {
                    string path = Path.GetExtension(file.FileName);
                    if(path.ToLower() != ".jpg" && path.ToLower() != ".png" && path.ToLower() != ".jpeg")
                    {
                        errorFile = true;
                        return;
                    }
                }
                Thread thread = ThreadHandler.InsertThread(ThreadFactory.CreateThread(threadTitle.Text, threadDescription.Text, category.SelectedIndex + 1, user.UserId));
                foreach (HttpPostedFile file in uploadImage.PostedFiles)
                {
                    string path = Path.GetExtension(file.FileName);

                    if(path.ToLower() == ".jpg" || path.ToLower() == ".png" || path.ToLower() == ".jpeg")
                    {
                        Stream stream = file.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        
                        ThreadHandler.InsertImage(ThreadFactory.CreateThreadImage(thread.ThreadId, bytes));
                    }
                }
            }
            if(hiddenValue.Value != "")
            {
                foreach(Draft draft in drafts)
                {
                    if(draft.DraftId == int.Parse(hiddenValue.Value))
                    {
                        ThreadHandler.DeleteDraft(draft.DraftId);
                        break;
                    }
                }
            }
            Response.Redirect("/View/Main/Home/HomePage.aspx");
        }

        protected void Draft_Click(object sender, EventArgs e)
        {
            foreach(Draft draft in drafts)
            {
                if(draft.DraftId == int.Parse(hiddenValue.Value))
                {
                    threadTitle.Text = draft.ThreadTitle;
                    threadDescription.Text = draft.ThreadDescription;
                    category.SelectedIndex = draft.CategoryId - 1;
                    return;
                }
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            Draft draft = drafts.ElementAt(int.Parse(e.CommandName));
            drafts.RemoveAt(int.Parse(e.CommandName));
            ThreadHandler.DeleteDraft(draft.DraftId);
            GetListDraft(user.UserId);
        }
    }
}