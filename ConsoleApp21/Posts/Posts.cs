namespace ConsoleApp21.Posts
{
    public class Posts: VirtualCvandPosts.CvAndPost
    {
        public Posts(){}
        public Posts(string email, string phones, string workCatagories, string duty, string workExperience, string education, int salary, string city, int Maxsalary, int Minage, int Maxage, string Requirement, string JobInfo, string Companyname, string Relevantperson) : base(email, phones, workCatagories, duty, workExperience, education, salary, city)
        {
            MinAge = Minage;
            MaxAge = Maxage;
            MaxSalary = Maxsalary;
            Jobinformation = JobInfo;
            CompanyName = Companyname;
            RelevantPerson = Relevantperson;
            Requirementsforthecandidate = Requirement;
        }
        public string Requirementsforthecandidate { get; set; }

        public string Jobinformation { get; set; }

        public string RelevantPerson { get; set; }

        public string CompanyName { get; set; }

        public int MaxSalary { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public override string ToString()
        {
            return $"{WorkCatagoriesHead}\n{WorkCatagories}\n{Duty}\n{MinSalary}-{MaxSalary}\t{CompanyName}\n" +
                $"Şəhər:     {City}\t\tTelefon:     {Phones}\nYaş:     {MinAge}-{MaxAge}\t\t\tE-Mail:     {Email}\n" +
                $"Təhsil:     {Education}\nİş Təcrübəsi:     {WorkExperience}\nElanın Tarixi:     {AdvertisementHistory.ToLongDateString()}\n" +
                $"Elanın Bitmə Tarixi:     {Expirationdate.ToLongDateString()}\n" +
                $"Əlaqədər Şəxs:     {RelevantPerson}\n\nİş Barədə Məlumat:     {Jobinformation}\n\nNamizədə Tələblər:     {Requirementsforthecandidate}\n\n";
        }
    }
}
