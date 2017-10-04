using System;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab2
{
    public class ResearchTeam : Team
    {
        private string _topicOfResearch;
        private TimeFrame _durationResearch;
        private System.Collections.ArrayList _projectMembers;
        private System.Collections.ArrayList _publicationList;

        public ResearchTeam(string organizationName,string researchTopic,int registrationNumber, TimeFrame duration)
        {
            _organizationName = organizationName;
            _registrationNumber = registrationNumber;
            _topicOfResearch = researchTopic;
            _durationResearch = duration;
            _projectMembers = new System.Collections.ArrayList();
            _publicationList = new System.Collections.ArrayList();
        }

		public ResearchTeam()
		{
			
			_topicOfResearch = "research_topic";
            _durationResearch = TimeFrame.Year;
			_projectMembers = new System.Collections.ArrayList();
			_publicationList = new System.Collections.ArrayList();
		}

        public System.Collections.ArrayList PublicationList
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
                    return (Paper)_publicationList[_publicationList.Count - 1];
                }

            }
        }

        void AddPapers(params Paper[] newPublications)
        {
            if(newPublications != null && newPublications.Length != 0)
            {
                for (int i = 0; i < newPublications.Length; i++)
                {
                    _projectMembers.Add(newPublications[i]);
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
            other._projectMembers = new System.Collections.ArrayList(_projectMembers);
            other._publicationList = new System.Collections.ArrayList(_publicationList);
            other._topicOfResearch = String.Copy(_topicOfResearch);
            other._durationResearch = _durationResearch;
            other._organizationName = String.Copy(_organizationName);
			return other;

		}

		public System.Collections.ArrayList ProjectsMember
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

		public System.Collections.IEnumerator GetPersonsWithoutPapers()
		{
            System.Collections.ArrayList personWithPapers = new System.Collections.ArrayList();
            foreach (Person person in ProjectsMember)
            {
                if(!PublicationList.Contains(person))
                {
                    yield return person;
                }
            }
		}

    }
}
