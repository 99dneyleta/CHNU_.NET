using System;
namespace Lab1
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

        public virtual string ToShorttring()
        {
            return this._name + " " + this._surname;
        }
    }
}
