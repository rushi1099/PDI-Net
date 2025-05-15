namespace PDI.Models
{
    public enum status
    {
        selected,
        rejected,
        pending
    }
    public class InterviewD
    {
        public string hrname {  get; set; }

        public string Companyname { get; set; }

        public string Position { get; set; }

        public int contactNo {  get; set; }
        public string email {  get; set; }

        public status status { get; set; }

    }
}
