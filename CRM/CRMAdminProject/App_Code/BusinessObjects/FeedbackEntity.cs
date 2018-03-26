using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for FeedbackEntity
    /// </summary>
    public class FeedbackEntity
    {
        public int FeedBackID { get; set; }
        public int? AdvisorID { get; set; }
        public string ClientSAID { get; set; }
        public string ClientFeedBack { get; set; }
        public string AdvisorFeedBack { get; set; }
        public string TimeStamp { get; set; }
    }
}