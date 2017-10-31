using System;
namespace Lab1
{
    public class ResearchTeam
    {
        private string _researchTopic;
        private string _organizationName;
        private int _registrationNumber;
        private TimeFrame _durationOfResearch;
        private Paper[] _publicationList;

        public ResearchTeam()
        {
            this._researchTopic = "defaultTopic";
            this._organizationName = "defaultOrganizationName";
            this._registrationNumber = -1;
            this._durationOfResearch = TimeFrame.Year;
            this._publicationList = new Paper[0];
        }

        public ResearchTeam(string researchTopic, string _organizationName, int registrationNmber, TimeFrame durationOfResearch)
        {
            this._researchTopic = researchTopic;
            this._organizationName = _organizationName;
            this._registrationNumber = registrationNmber;
            this._durationOfResearch = durationOfResearch;
        }

        public string ResearchTopic
        {
            get
            {
                return this._researchTopic;
            }
            set
            {
                this._researchTopic = value;
            }
        }

        public string OrganizationName
        {
            get
            {
                return this._organizationName;
            }
            set
            {
                this._organizationName = value;
            }
        }

        public int RegistrationNumber
        {
            get
            {
                return this._registrationNumber;
            }
            set
            {
                this._registrationNumber = value;
            }
        }

        public TimeFrame DurationOfResearch
        {
            get
            {
                return this._durationOfResearch;
            }
            set
            {
                this._durationOfResearch = value;
            }
        }

        public Paper[] PublicationList
        {
            get
            {
                return this._publicationList;
            }
            set
            {
                this._publicationList = value;
            }
        }

        public Paper LastPublication
        {
            get
            {
                if (this._publicationList != null || this._publicationList.Length != 0)
                {
                    return this._publicationList[this._publicationList.Length - 1]; 
                }
                else 
                {
                    return null;
                }
            }
        }

        public bool this[TimeFrame index]
        {
            get
            {
                return (this._durationOfResearch == index) ? true : false;
            }
        }

        public void AddPapers(params Paper[] newPublications)
        {
            Paper[] objects = new Paper[this._publicationList.Length + newPublications.Length];
            this._publicationList.CopyTo(objects,0);
            newPublications.CopyTo(objects,this._publicationList.Length);
            this.PublicationList = objects;
        }

        public override string ToString()
        {
            return string.Format("[ResearchTeam: ResearchTopic={0}, OrganizationName={1}, RegistrationNumber={2}, DurationOfResearch={3}, PublicationList={4}]", ResearchTopic, OrganizationName, RegistrationNumber, DurationOfResearch, PublicationList);
        }

        public virtual string ToShortString()
        {
           return string.Format("[ResearchTeam: ResearchTopic={0}, OrganizationName={1}, RegistrationNumber={2}, DurationOfResearch={3}, PublicationList={4}]", ResearchTopic, OrganizationName, RegistrationNumber, DurationOfResearch, PublicationList); 
        }
    }
}
