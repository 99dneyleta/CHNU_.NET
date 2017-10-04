using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Lab2
{
    public class Person
    {
        private string _name;
        private string _surname;
        private System.DateTime _birthday;

        public Person()
        {
            this._name = "defaultName";
            this._surname = "defaultSurname";
            this._birthday = DateTime.MinValue;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            this._name = name;
            this._surname = surname;
            this._birthday = birthday;
        }

        public String Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public string Surname
        {
            get
            {
                return this._surname;
            }
            set
            {
                this._surname = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this._birthday;
            }
            set
            {
                this._birthday = value;
            }
        }

        public int YearOfBirthday
        {
            get
            {
                return this._birthday.Year;
            }
            set
            {
                _birthday.AddYears(value);
            }
        }

        public override string ToString()
        {
            return string.Format("[Person: Name={0}, Surname={1}, Birthday={2}, YearOfBirthday={3}]", Name, Surname, Birthday, YearOfBirthday);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person p = obj as Person;
            if((System.Object)p == null)
            {
                return false;
            }

            return (_name == p._name) && (_surname == p._surname) && (_birthday == p._birthday);
        }

        public bool Equals(Person p)
        {
            if((object)p == null)
            {
                return false;
            }

            return (_name == p._name) && (_surname == p._surname) && (_birthday == p._birthday);

        }

        public static bool operator ==(Person first, Person second)
        {
            if(System.Object.ReferenceEquals(first,second))
            {
                return true;
            }

            if (((object)first == null || (object)second == null))
            {
                return false;
            }

            return (first._name == second._name) && (first._surname == second._surname) && (first._birthday == second._birthday);

        }

        public static bool operator !=(Person first, Person second)
        {
            return !(first == second);
        }


        public override int GetHashCode()
        {
            int hashCode = Name.GetHashCode();
            hashCode = 31 * hashCode + Surname.GetHashCode();
            hashCode = 31 * hashCode + Birthday.GetHashCode();

            return hashCode;
        }


		public object DeepCopy()
		{
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
				ms.Position = 0;

                return (Person)formatter.Deserialize(ms);
			}
		}


        public virtual string ToShorttring()
        {
            return this._name + " " + this._surname;
        }
    }
}
