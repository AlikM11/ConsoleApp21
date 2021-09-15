namespace ConsoleApp21.Person
{
    public abstract class Person
    {

        protected Person(string username, string password, string name, string surname, string city, string phone, int age)
        {
            id = 1;
            ID = id++;
            Age = age;
            Name = name;
            City = city;
            Phone = phone;
            Surname = surname;
            Password = password;
            Username = username;
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }
        
        public string Phone { get; set; }
        
        public string Name { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public int ID { get; set; }

        public static int id;

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nCity: {City}\nAge: {Age}\nPhone: {Phone}\nID: {id}";
        }
    }
}
