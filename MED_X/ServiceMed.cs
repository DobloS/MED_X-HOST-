using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_X
{
    internal class ServiceMed
    {
        
        private Queue<Ticket> tickets = new Queue<Ticket>();


        public ServiceMed()
        {
        }

        public void AddNewTicket(Ticket ticket)
        {
            tickets.Enqueue(ticket);
        }

        public Queue<Ticket> GetTickets()
        {
            return tickets;
        }

        public void RemoveTicket()
        {
            tickets.Dequeue();
        }

        public void UpgradeTime()
        {

        }
    }
}

