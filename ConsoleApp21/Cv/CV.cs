using System.Collections.Generic;
using ConsoleApp21.VirtualCvandPosts;

namespace ConsoleApp21.Cv
{
    public class CV:CvAndPost
    {
        public CV() { }
        public CV(string email, string phones, string workCatagories, string duty, string workExperience, string education, int salary,string city,int age,string name,string surname,string ftname,string gender,string detail,string wxpdetail,string skills,string advance ):base(email,phones,workCatagories,duty,workExperience,education,salary,city)
        {
            Age = age;
            Name = name;
            Gender = gender;
            Skills = skills;
            Details = detail;
            Surname = surname;
            FathersName = ftname;
            AdvanceInformation = advance;
            WorkexperienceDetails = wxpdetail;
        }

        public string WorkexperienceDetails { get; set; }

        public string AdvanceInformation { get; set; }

        public string FathersName { get; set; }

        public string LINKEDIN { get; set; }

        public string GITLINK { get; set; }

        public string Surname { get; set; }

        public string Details { get; set; }

        public string Skills { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{WorkCatagoriesHead}/{WorkCatagories}\n{Duty}\n" +
                $"{MinSalary} AZN {Name} {Surname}\n\nŞəhər:\t{City}\t\tTelefon: {Phones}\nYaş:\t{Age}\t\t\tE-Mail: {Email}\n" +
                $"Elanın Tarixi:\t{AdvertisementHistory.ToLongDateString()}\t\tLinedin: {LINKEDIN}\nBitmə Tarixi:\t{Expirationdate.ToLongDateString()}\t\tGitlink: {GITLINK}\n" +
                $"Ad:\t{Name} {FathersName} {Surname}\n\n" +
                $"Bacarıqlar\n{Skills}\n\nTəhsil\n{Education}\nİş Təcrübəsi\n{WorkExperience}\n{WorkexperienceDetails}\nƏlavə Məlumat\n{AdvanceInformation}\n\n";
        }
    }
}
