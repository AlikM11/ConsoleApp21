using System;

namespace ConsoleApp21.VirtualCvandPosts
{
    public abstract class CvAndPost
    {
        public CvAndPost(){}
        protected CvAndPost(string email, string phones, string workCatagories, string duty, string workExperience, string education,int salary,string city)
        {
            Duty = duty;
            City = city;
            Email = email;
            Phones = phones;
            MinSalary = salary;
            Education = education;
            WorkExperience = workExperience;
            WorkCatagories = workCatagories;
        }
        public DateTime AdvertisementHistory { get; set; }

        public string WorkCatagoriesHead { get; set; }

        public DateTime Expirationdate { get; set; }

        public string WorkCatagories { get; set; }

        public string WorkExperience { get; set; }

        public string Education { get; set; }

        public int MinSalary { get; set; }

        public string Phones { get; set; }

        public string Email { get; set; }

        public string Duty { get; set; }

        public string City { get; set; }
    }
}
