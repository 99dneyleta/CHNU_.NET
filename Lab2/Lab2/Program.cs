using System;

namespace Lab2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Team firstTeam = new Team();
            Team secondTeam = new Team();

            Console.WriteLine("Equals? - {0}", firstTeam.Equals(secondTeam));
            Console.WriteLine("Ref Equals? - {0}", Object.ReferenceEquals(firstTeam,secondTeam));
            Console.WriteLine("Hash for first - {0}, Hash for second - {1}", firstTeam.GetHashCode(), secondTeam.GetHashCode());

            try
            {
                firstTeam.RegistrationNumber = -1;
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine("Exception caugh - {0}.", ex.Message);
            }

            ResearchTeam animals = new ResearchTeam();
            Person richard = new Person("Richard", "Black", new DateTime(1989, 12, 12));
            Person den = new Person("Den", "Simpson", new DateTime(1993, 1, 24));
            Person nelly = new Person("Nelly", "Smile", new DateTime(1981, 4, 22));

            Paper cobra = new Paper();
            Paper sparrow = new Paper("Sparrows", nelly, new DateTime(2015, 4, 21));



            cobra.PublicationName = "Black Mamba";
            cobra.Author = richard;
            cobra.PublicationDate = new DateTime(2012, 8, 12);

            animals.PublicationList.Add(cobra);
            animals.PublicationList.Add(sparrow);

            animals.ProjectsMember.Add(richard);
			animals.ProjectsMember.Add(den);
            animals.ProjectsMember.Add(nelly);

            Console.WriteLine(animals);
            Console.WriteLine(animals.Team);


            ResearchTeam copy = (ResearchTeam)animals.DeepCopy();
            Console.WriteLine(copy);
            animals.Name = "aimals";
            Console.WriteLine(animals);

            foreach (Paper element in animals.GetPublicationsForTheLastYears(2))
            {
                Console.WriteLine(element);
            }



        }
    }
}
