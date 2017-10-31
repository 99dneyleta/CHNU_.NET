using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Team : IComparable<Team>
    {
        protected string _organizationName;
        protected int _registrationNumber;

		

        public Team()
        {
            _organizationName = "default_Organization_Name";
            _registrationNumber = -1;

        }

        public Team(string name, int number)
        {
            _organizationName = name;
            _registrationNumber = number;
        }

        public string Name
        {
            get
            {
                return _organizationName;
            }
            set
            {
                _organizationName = value;
            }
        }

        public int RegistrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                if(value <= 0)
                {
                    throw new System.ArgumentException("Parametr must be > 0", nameof(value));
                }
                else
                {
                    _registrationNumber = value;
                }
            }
        }

        public virtual object DeepCopy()
		{
            Team other = (Team)this.MemberwiseClone();
            other._organizationName = String.Copy(_organizationName);
			return other;
		}


		public bool Equals(Team t)
		{
			if ((object)t == null)
			{
				return false;
			}

            return (_organizationName == t._organizationName) && (_registrationNumber == t._registrationNumber);

		}

		public static bool operator ==(Team first, Team second)
		{
			if (System.Object.ReferenceEquals(first, second))
			{
				return true;
			}

			if (((object)first == null || (object)second == null))
			{
				return false;
			}

            return (first._organizationName == second._organizationName) && (first._registrationNumber == second._registrationNumber);
		}

		public static bool operator !=(Team first, Team second)
		{
			return !(first == second);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

            Team t = obj as Team;
			if ((System.Object)t == null)
			{
				return false;
			}

            return (_organizationName == t._organizationName) && (_registrationNumber == t._registrationNumber);
		}

		public override int GetHashCode()
		{
			int hashCode = Name.GetHashCode();
            hashCode = 31 * hashCode + Name.GetHashCode();

			return hashCode;
		}

        public override string ToString()
        {
            return string.Format("Team - {0}, RegistrationNumber = {1}]", Name, RegistrationNumber);
        }

		public int CompareTo(Team that)
		{
			if (this.RegistrationNumber > that.RegistrationNumber) return -1;
			if (this.RegistrationNumber == that.RegistrationNumber) return 0;
			return 1;
		}

		
       
    }
}
