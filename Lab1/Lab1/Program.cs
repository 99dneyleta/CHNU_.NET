using System;

namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ResearchTeam obj = new ResearchTeam();
             

            Console.WriteLine(obj.ToShortString());
            Console.WriteLine(obj[TimeFrame.Year]);
            Console.WriteLine(obj[TimeFrame.TwoYears]);
            Console.WriteLine(obj[TimeFrame.Long]);

            obj.DurationOfResearch = TimeFrame.TwoYears;
            obj.OrganizationName = "Bionic";
            obj.RegistrationNumber = 0;
            obj.ResearchTopic = "Snakes";

            Console.WriteLine(obj);

            Paper[] papers = new Paper[2];

            for (int i = 0; i < papers.Length; i++)
            {
                papers[i] = new Paper();
            }

            papers[0].Author = new Person("Richard", "Markov", new DateTime(1897, 12, 11));
            papers[0].PublicationDate = new DateTime(2012, 12, 12);
            papers[0].PublicationName = "Cobra";

            papers[1].Author = new Person("Nelly", "Stenly", new DateTime(1991, 4, 25));
			papers[1].PublicationDate = new DateTime(2015, 8, 22);
			papers[1].PublicationName = "Black Mamba";

            obj.AddPapers(papers);
            Console.WriteLine(obj);

            Console.WriteLine(obj.LastPublication);
        }
    }
}
