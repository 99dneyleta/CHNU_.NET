using System;
using System.Collections;
namespace Lab3
{
    public class CompareCountOfPublication : System.Collections.Generic.IComparer<ResearchTeam>
    {
        public CompareCountOfPublication()
        {
        }

        public int Compare(ResearchTeam hfirst, ResearchTeam hsecond)
		{
            return ((new CaseInsensitiveComparer()).Compare(hfirst.PublicationList.Count, hsecond.PublicationList.Count));
		}

    }
}
