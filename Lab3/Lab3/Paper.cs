using System;
namespace Lab3
{
    public class Paper
    {
        public string PublicationName { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }


        public Paper()
        {
            this.PublicationName = "defaultName";
            this.Author = new Person();
            this.PublicationDate = DateTime.MinValue;
        }

        public Paper(string publicationName, Person author, DateTime publicationDate)
        {
            this.PublicationName = publicationName;
            this.Author = author;
            this.PublicationDate = publicationDate;
        }

        public override string ToString()
        {
            return string.Format("[Paper: PublicationName={0}, Author={1}, PublicationDate={2} ]", PublicationName, Author, PublicationDate);
        }
    }
}
