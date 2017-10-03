using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab2
{
    public class ResearchTeam : Team
    {
        private string _topicOfResearch;
        private TimeFrame _durationResearch;
        private System.Collections.ArrayList _projectMembers;
        private System.Collections.ArrayList _publicationList;

        ResearchTeam(string organizationName,string researchTopic,int registrationNumber, TimeFrame duration)
        {
            _organizationName = organizationName;
            _registrationNumber = registrationNumber;
            _topicOfResearch = researchTopic;
            _durationResearch = duration;
        }

		ResearchTeam()
		{
			_organizationName = "organization_name";
			_registrationNumber = -1;
			_topicOfResearch = "research_topic";
            _durationResearch = TimeFrame.Year;
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
			print = string.Format("Team - {0}, RegistrationNumber = {1}, Topic of Research - {3}, Research duration - {4} ]",
								 _organizationName, _registrationNumber, _topicOfResearch, _durationResearch);

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
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
				ms.Position = 0;

                return (ResearchTeam)formatter.Deserialize(ms);
			}
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



    }
}
