using System.Collections.Generic;
using ConsoleApp21.Notifications;

namespace ConsoleApp21.Employer
{
    public class Employer:Person.Person
    {
        public Employer(string username, string password, string name, string surname, string city, string phone, int age):base(username,password,name,surname,city,phone,age){}

        public List<Notification> notifications;

        public List<Posts.Posts> Posts;

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
