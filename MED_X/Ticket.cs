using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MED_X
{
    public class Ticket
    {
        public readonly string WordIdentifier;
        public readonly int Number;
        public readonly string Description;
        public readonly string Time;

        public Ticket(string description, string time)
        {
            Description = description;
            WordIdentifier = description.Substring(0,2);
            Time = time;
            Number = TicketsService.uniqueId[WordIdentifier];
            TicketsService.uniqueId[WordIdentifier] += 1;
        }

        public override string ToString()
        {
            return WordIdentifier + Number.ToString();
        }

        public string GetDescription()
        {
            return Description;
        }

        static class TicketsService
        {
            public static Dictionary<string, int> uniqueId = new Dictionary<string, int>
            {
                {"Хи",0 },
                {"Оф",0 },
                {"Те",0 }
            };

            public static Dictionary<string, List<string>> uniqueTime = new Dictionary<string, List<string>>
            {
                {"Хирург}",new List<string>{"10:00","11:00","12:00"} },
                {"Офтальмолог",new List<string>{"10:00","11:00","12:00"} },
                {"Терапевт",new List<string>{"10:00","11:00","12:00"} }
            };

            private static void IncrementId(string key)
            {
                uniqueId[key]++;
            }

            public static int GetUniqueId(string key)
            {
                IncrementId(key);
                return uniqueId[key];
            }

            public static List<string> GetUniqueTime(string key)
            {
                return uniqueTime[key];
            }

            public static void RemoveUniqueTime(string key, string time)
            {
                uniqueTime[key].Remove(time);
            }
        }
    }
}
