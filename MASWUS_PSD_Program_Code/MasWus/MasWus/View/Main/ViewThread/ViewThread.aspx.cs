using MasWus.Factory;
using MasWus.Handler;
using MasWus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasWus.View.Main.ViewThread
{
    public partial class ViewThread : System.Web.UI.Page
    {
        protected Thread thread;
        protected List<string> imageUrl = new List<string>();
        private int threadId;
        protected int totalReplies;
        protected void Page_Load(object sender, EventArgs e)
        {
            TheadSingelton.GetInsntance().SaveThreadID(0);
            RetrieveThread();

            if (!IsPostBack)
            {
                RetrieveReply();
                UpdateView();
            }
        }

        private void UpdateView()
        {
            threadId = int.Parse(Request["thread"]);
            ThreadHandler.AddView(threadId);
        }

        private void RetrieveThread()
        {
            threadId = int.Parse(Request["thread"]);
            thread = ThreadHandler.RetrieveThread(threadId);
            thread.ThreadView += 1;
            CastImageUrl();

        }

        private void CastImageUrl()
        {
            if(thread.ThreadImages != null)
            {
                foreach(ThreadImage image in thread.ThreadImages)
                {
                    imageUrl.Add(ImageUtility.getInstance().ConvertToImage(image.ImageData));
                    System.Diagnostics.Debug.WriteLine(ImageUtility.getInstance().ConvertToImage(image.ImageData));
                }

                repeaterImage.DataSource = imageUrl;
                repeaterImage.DataBind();
            }
        }

        private void RetrieveReply()
        {
            List<Reply> replies;
            replies = ReplyHandler.RetrieveAllThreadReplies(threadId);
            totalReplies = replies.Count;
            replyRepeater.DataSource = replies;
            replyRepeater.DataBind();
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            string input = replyInput.Text;
            if(string.IsNullOrEmpty(input))
            {
                Response.Write("<script>alert('Reply Failed !');</script>");
            }
            else
            {
                User user = (User) Session["User"];
                Reply reply = ReplyFactory.createReply(threadId, user.UserId, input);
                ReplyHandler.InsertReply(reply);
                replyInput.Text = "";
                RetrieveReply();
            }
        }

        protected void buttonLike_Click(object sender, EventArgs e)
        {
            threadId = int.Parse(Request["thread"]);
            int userId = ((User)Session["User"]).UserId;
            ThreadHandler.UpVoteValidation(userId, threadId);
            thread = ThreadHandler.RetrieveThread(threadId);
        }
    }
}