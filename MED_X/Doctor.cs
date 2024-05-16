using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_X
{
    internal class Doctor
    {
        private string name, secondName, surname, login, password, specialization, time;
        private List<string> shedule;
        public Doctor(string name, string secondName, string surname, string login, string password, string specialization)
        {
            this.name = name;
            this.secondName = secondName;
            this.surname = surname;
            this.login = login;
            this.password = password;
            this.specialization = specialization;
        }

        public Doctor()
        {

        }


        public void ChangeName(string name)
        {
            this.name = name;
        }
        public void ChangeSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        public void ChangeSurname(string surname)
        {
            this.surname = surname;
        }
        public void ChangeLogin(string login)
        {
            this.login = login;
        }
        public void ChangePassword(string password)
        {
            this.password = password;
        }
        public void ChangeSpecialization(string specialization)
        {
            this.specialization = specialization;
        }

        public string GetName()
        {
            return name;
        }
        public string GetSecondName()
        {
            return secondName;
        }
        public string GetSurname()
        {
            return surname;
        }
        public string GetLogin()
        {
            return login;
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetSpecialization()
        {
            return specialization;
        }

        private List<string> AddTime(string time, List<string> shedule)
        {
            shedule.Add(time);
            return shedule;
        }
        private List<string> RemoveTime(string time, List<string> shedule)
        {
            shedule.Remove(time);
            return shedule;
        }
        private List<string> CreateNewShedule(List<string> shedule)
        {
            shedule.Clear();
            return shedule;
        }
    }
}

