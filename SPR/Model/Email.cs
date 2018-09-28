

namespace SPR.Model
{
    class Email : Receiver
    {
        public string EmailAddress { get; }
        public string Subject { get; }
        public string Body { get; }

        public Email(string emailAddress, string subject, string body,
            string name, string surname1, string surname2, string cPU, string rAM, 
            string iO_DISK, string iSS_Sessions)
            : base(name, surname1, surname2, cPU, rAM, iO_DISK, iSS_Sessions)
        {
            this.EmailAddress = emailAddress;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
