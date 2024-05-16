using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_X
{
    public class Patient
    {
        private string firstName, secondName, thirdName, password;
        private int age;
        private string snils;
        private string policyNumber;
        private List<Ticket> Tickets;

        public Patient(
            string firstName,
            string secondName,
            string thirdName,
            int age,
            string snils,
            string policyNumber,
            string password)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.age = age;
            this.snils = snils;
            this.policyNumber = policyNumber;
            this.password = password;
        }
        public Patient() { }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetSecondName()
        {
            return secondName;
        }

        public string GetThirdName()
        {
            return thirdName;
        }

        public int GetAge()
        {
            return age;
        }

        public string GetSnils()
        {
            return snils;
        }
        public string GetPassword()
        {
            return password;
        }

        public string GetPolicyNumber()
        {
            return policyNumber;
        }

        public void ChangeFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void ChangeSecondName(string secondName)
        {
            this.secondName = secondName;
        }

        public void ChangeThirdName(string thirdName)
        {
            this.thirdName = thirdName;
        }

        public void ChangeAge(int age)
        {
            this.age = age;
        }

        public void ChangeSnils(string snils)
        {
            this.snils = snils;
        }
        public void ChangePassword(string password)
        {
            this.password = password;
        }
        public void ChangePolicyNumber(string policyNumber)
        {
            this.policyNumber = policyNumber;
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public void RemoveTicket(string _ticket)
        {
            foreach (var ticket in Tickets)
            {
                if (ticket.ToString() == _ticket)
                {
                    Tickets.Remove(ticket);
                }
            }
        }

        public List<Ticket> GetTickets()
        {
            return Tickets;
        }
    }
}
