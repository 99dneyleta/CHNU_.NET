using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab3
{
    public class ResearchTeamCollections
    {
        private List<ResearchTeam> _teams;

		public ResearchTeamCollections()
		{
		}

        void AddDefaults()
        {
            
        }

        void AddResearchTeams(params ResearchTeam[] addTeams)
        {
            List<ResearchTeam> newTeams = new List<ResearchTeam>(addTeams);
            var allElements = _teams.Concat(newTeams);
            _teams = allElements.ToList();
        }

        public override string ToString()
        {
            string result = "";
            foreach (ResearchTeam team in _teams)
            {
                result += team + "\n";
            }

            return result;
        }

        public virtual string ToShorrtList()
        {
            string result = "";

            foreach (ResearchTeam team in _teams)
            {
                result += team.ToShortString() + "\n";
            }

            return result;
        }

        public void SortByRegistrationNumber()
        {
            _teams.Sort((x,y) => x.CompareTo(y));
        }

        public void SortByResearchTopic()
        {
            _teams.Sort((x, y) => x.Compare(x,y));
        }

        public void SortByCountOfPublication()
        {
            CompareCountOfPublication test = new CompareCountOfPublication();
            _teams.Sort((x,y) => test.Compare(x,y));

        }

        public int MinRegestrationNumber
        {
            get
            {
                if(_teams.Count() == 0)
                {
                    return -1;
                }
                else
                {
                    return _teams.Min().RegistrationNumber;
                }
            }
        }

        public IEnumerable<ResearchTeam> WhichResearchingTwoYears
        {
            get
            {
                return _teams.Where((ResearchTeam arg) => arg.DurationResearch == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            var list = _teams.GroupBy(arg => arg.ProjectsMember.Count() == value)
                             .ToList();
            List<ResearchTeam> result = new List<ResearchTeam>();
            foreach (ResearchTeam element in list)
            {
                result.Add(element);
            }


            return result;
        }



    }
}
