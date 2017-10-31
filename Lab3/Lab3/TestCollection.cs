using System;
using System.Collections.Generic;
namespace Lab3
{
    public class TestCollection
    {
        List<Team> _teams;
        List<string> _str;
        Dictionary<Team, ResearchTeam> _teamsWithRT;
        Dictionary<string, ResearchTeam> _strRS;

        static ResearchTeam(int count)
        {
            
        }



        public TestCollection(int count)
        {
            _teams = new List<Team>(count);
            _str = new List<string>(count);
            _teamsWithRT = new Dictionary<Team, ResearchTeam>(count);
            _strRS = new Dictionary<string, ResearchTeam>(count);
        }
    }
}
