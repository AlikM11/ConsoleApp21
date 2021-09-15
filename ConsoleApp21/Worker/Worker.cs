using System.Collections.Generic;
using ConsoleApp21.Notifications;
using ConsoleApp21.Cv;

namespace ConsoleApp21.Worker
{
    public class Worker:Person.Person
    {
        public Worker(string username, string password, string name, string surname, string city, string phone, int age) : base(username, password, name, surname, city, phone, age) { }

        public List<Notification> notifications;
        
        public List<CV> cV;

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
