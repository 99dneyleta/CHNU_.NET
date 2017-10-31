using System;
using System.Collections;

namespace Lab3
{
    public class ResearchTeam : Team, System.Collections.Generic.IComparer<ResearchTeam>
    {
        private string _topicOfResearch;
        private TimeFrame _durationResearch;
        private System.Collections.Generic.List<Person> _projectMembers;
        private System.Collections.Generic.List<Paper> _publicationList;

        public ResearchTeam(string organizationName, string researchTopic, int registrationNumber, TimeFrame duration)
        {
            _organizationName = organizationName;
            _registrationNumber = registrationNumber;
            _topicOfResearch = researchTopic;
            _durationResearch = duration;
            _projectMembers = new System.Collections.Generic.List<Person>();
            _publicationList = new System.Collections.Generic.List<Paper>();
        }

        public ResearchTeam()
        {

            _topicOfResearch = "research_topic";
            _durationResearch = TimeFrame.Year;
            _projectMembers = new System.Collections.Generic.List<Person>();
            _publicationList = new System.Collections.Generic.List<Paper>();
        }

        public System.Collections.Generic.List<Paper> PublicationList
        {
            get
            {
                return _publicationList;
            }
            set
            {
                _publicationList = value;
            }
        }

        public TimeFrame DurationResearch
        {
            get
            {
                return _durationResearch;
            }
        }

        public Paper LastPublication
        {
            get
            {
                if(_publicationList == null || _publicationList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return _publicationList[_publicationList.Count - 1];
                }
			}

        }

        void AddPapers(params Paper[] newPublications)
        {
            if(newPublications != null && newPublications.Length != 0)
            {
                for (int i = 0; i < newPublications.Length; i++)
                {
                    _publicationList.Add(newPublications[i]);
                }

            }
            else
            {
                throw new ArgumentException("Parametr length must be >0 and parametr must be not null", nameof(newPublications));
            }
        }



        public override string ToString()
        {
            string print = "";
			print =  _organizationName + " " + _registrationNumber + " " + _topicOfResearch + " " + _durationResearch;

            foreach (Person element in _projectMembers)
            {
                print += element;
            }

            print += "\n" + "Publications:" + "\n";

            foreach (Paper element in _publicationList)
            {
                print += element;
            }

            return print;

        }

        public string ToShortString()
        {
            return string.Format("Team - {0}, RegistrationNumber = {1}, Topic of Research - {3}, Research duration - {4}]", 
                                 _organizationName, _registrationNumber, _topicOfResearch, _durationResearch);
        }

        public override object DeepCopy()
		{
            ResearchTeam other = (ResearchTeam)this.MemberwiseClone();
            other._projectMembers = new System.Collections.Generic.List<Person>(_projectMembers);
            other._publicationList = new System.Collections.Generic.List<Paper>(_publicationList);
            other._topicOfResearch = String.Copy(_topicOfResearch);
            other._durationResearch = _durationResearch;
            other._organizationName = String.Copy(_organizationName);
			return other;

		}

        public System.Collections.Generic.List<Person> ProjectsMember
		{
			get
			{
                return _projectMembers;
			}
			set
			{
                _projectMembers = value;
			}
		}

        public Team Team
        {
            get
            {
                return new Team(_organizationName, _registrationNumber);
            }
            set
            {
                _organizationName = value.Name;
                _registrationNumber = value.RegistrationNumber;
            }
        }

		public System.Collections.IEnumerable GetPublicationsForTheLastYears(int countOfYears)
		{
            foreach (Paper element in _publicationList)
            {
                if(DateTime.Now.Year - element.PublicationDate.Year <= countOfYears)
                {
                    yield return element;
                }
            }
		}

		//public System.Collections.IEnumerator GetPersonsWithoutPapers()
		//{
		//System.Collections.ArrayList personWithPapers = new System.Collections.ArrayList();
		//foreach (Person person in ProjectsMember)
		//{
		//    if(!PublicationList.Find(person))
		//    {
		//        yield return person;
		//    }

		//    System.Collections.Generic.List<Person> result = _publicationList.FindAll(
		//    delegate (Paper p)
		//    {
		//        Person
		//    })
		//}    need to use .find with delegate
		//}


		

        public int Compare(ResearchTeam first, ResearchTeam second)
        {
            return StringComparer.CurrentCulture.Compare(first._topicOfResearch, second._topicOfResearch);
        }



    }
}
