using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class SupportTicket
    {
        private readonly PriorityClassifier _classifier;

        public string Id { get; }
        public string Subject { get; }
        public string Body { get; private set; }
        public DateTimeOffset OpenedAt { get; }
        public string Priority { get; private set; }

        public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt, PriorityClassifier classifier)
        {
            Id = id;
            Subject = subject;
            Body = body;
            OpenedAt = openedAt;
            _classifier = classifier;
            Priority = _classifier.Classify(this);
        }

        public void AppendCustomerMessage(string text)
        {
            Body += "\n---\n" + text;
            Priority = _classifier.Classify(this);
        }

    }
}
