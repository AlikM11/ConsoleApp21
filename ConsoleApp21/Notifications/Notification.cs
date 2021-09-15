using System;

namespace ConsoleApp21.Notifications
{
    public class Notification
    {
        public Notification() {}
        public Notification(string senderName,string sendersurname, DateTime sendingTime, string content,int postindex)
        {
            Content = content;
            PostIndex = postindex;
            SenderName = senderName;
            SendingTime = sendingTime;
            SenderSurname = sendersurname;
        }
        public DateTime SendingTime { get; set; }

        public string SenderSurname { get; set; }

        public string SenderName { get; set; }

        public string Content { get; set; }

        public int PostIndex { get; set; }
    }
}
