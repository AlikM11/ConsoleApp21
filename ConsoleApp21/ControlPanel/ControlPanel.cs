using System;
using System.Collections.Generic;
using ConsoleApp21.Cv;
using ConsoleApp21.SelectedMenu;
using ConsoleApp21.Notifications;
using System.Threading;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using NLog;

namespace ConsoleApp21.ControlPanel
{
    public class ControlPanel
    {
        public ControlPanel() {}
        public void SeralizeCV(ref Worker.Worker workers)
        {
            var str = JsonConvert.SerializeObject(workers.cV, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("WorkersCV.json", str);
        }
        public void DeserialzeCV(ref Worker.Worker workers)
        {
            var jsonstr = File.ReadAllText("WorkersCV.json");
            if (jsonstr.Length > 0) workers.cV = JsonConvert.DeserializeObject<List<CV>>(jsonstr);
        }
        public void SerializeVakancias(ref Employer.Employer employer)
        {
            var str = JsonConvert.SerializeObject(employer.Posts, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("EmployerVakancias.json", str);
        }
        public void DeserializeVakancia(ref Employer.Employer employer)
        {
            var jsonstr = File.ReadAllText("EmployerVakancias.json");
            if (jsonstr.Length > 0) employer.Posts = JsonConvert.DeserializeObject<List<Posts.Posts>>(jsonstr);
        }
        public void SerializeWorker(ref List<Worker.Worker> workers)
        {
            var str = JsonConvert.SerializeObject(workers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Workers.json", str);
        }
        public void DeserializeWorker(ref List<Worker.Worker> workers)
        {
            var jsonstr = File.ReadAllText("Workers.json");
            if (jsonstr.Length > 0) workers = JsonConvert.DeserializeObject<List<Worker.Worker>>(jsonstr);
        }
        public void SerializeEmployer(ref List<Employer.Employer> employer)
        {
            var str1 = JsonConvert.SerializeObject(employer, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Employers.json", str1);
        }
        public void DeserializeEmployer(ref List<Employer.Employer> employer)
        {
            var jsonstr1 = File.ReadAllText("Employers.json");
            if (jsonstr1.Length > 0) employer = JsonConvert.DeserializeObject<List<Employer.Employer>>(jsonstr1);
        }

        public void SelectorWorkCatagory(int index, int size, ref Catagories.Catagories catagories, ref Worker.Worker workers, ref Employer.Employer employer, ref Posts.Posts posts, ref CV cV)
        {
            int more = index;
            int index2 = 0;
            string[] arr = new string[size];
            for (int i = 0; i < arr.Length; i++, index++)
            {
                arr[i] = catagories.SelectorBody[index];
            }
            var a = SelectingMenu.choose(arr);
            Console.WriteLine(a);
            index2 = a + more;
            if (workers != null) { cV.WorkCatagories = catagories.SelectorBody[index2]; }
            else if (employer != null) { posts.WorkCatagories = catagories.SelectorBody[index2]; }
        }
        public  int SearchWorkCatagory(int index, int size, ref Catagories.Catagories catagories, ref Worker.Worker workers, ref Employer.Employer employer, ref Posts.Posts posts, ref CV cV)
        {
            int more = index;
            int index2 = 0;
            string[] arr = new string[size];
            for (int i = 0; i < arr.Length; i++, index++)
            {
                arr[i] = catagories.SelectorBody[index];
            }
            var a = SelectingMenu.choose(arr);
            Console.WriteLine(a);
            index2 = a + more;
            return index2;
        }
        public void CreateVacansia(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            var str = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new(str);
            var PhoneControl = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex regex1 = new(PhoneControl);
            string Namecontrol = "[0-9]";
            Regex regex2 = new(Namecontrol);
            Console.Clear();
            posts = new Posts.Posts();
        a:
            Console.Write("E-mail: "); string email = Console.ReadLine();
            Match match = regex.Match(email); if (match.Success && email.Length >= 5) { posts.Email = email; goto b; }
            else { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Düzgün Email Daxil edin!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto a; }
        b:
            Console.Clear();
            Console.Write("Telefon: "); string phone = Console.ReadLine();
            Match match1 = regex1.Match(phone);
            if (match1.Success) { posts.Phones = phone;  goto tru;}
            else { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Yanlış daxil etdiniz!!!\nTelefon Nomrəsi daxil eliyərkən əvvəlcə()mötərizələr içərisinə nömrənin başlığını yazın daha sonra nömrəni"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(2000); goto b; }
            tru:
            string[] str5 = new string[catagories.SelectorHeader.Count];
            for (int i = 0; i < catagories.SelectorHeader.Count; i++)
            {
                str5[i] = catagories.SelectorHeader[i];
            }
            var select5 = SelectingMenu.choose(str5);
            posts.WorkCatagoriesHead = catagories.SelectorHeader[select5];
            if (select5 == 0) { SelectorWorkCatagory(0, 8, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 1) { SelectorWorkCatagory(8, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 2) { SelectorWorkCatagory(12, 6, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 3) { SelectorWorkCatagory(18, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 4) { SelectorWorkCatagory(23, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 5) { SelectorWorkCatagory(25, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 6) { SelectorWorkCatagory(29, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 7) { SelectorWorkCatagory(32, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 8) { SelectorWorkCatagory(36, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 9) { SelectorWorkCatagory(41, 11, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 10) { SelectorWorkCatagory(52, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 11) { SelectorWorkCatagory(55, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            Console.Clear();
            Console.Write("Vəzifə: "); string duty = Console.ReadLine();
            posts.Duty = duty;
            string[] arr = new string[catagories.SelectCity.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = catagories.SelectCity[i];
            }
            var city = SelectingMenu.choose(arr, "");
            posts.City = catagories.SelectCity[city];

            string[] arr2 = new string[catagories.SelectSalary.Count];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = catagories.SelectSalary[i].ToString();
            }
            var minsal = SelectingMenu.choose("Minimum Maaş:", arr2);
            posts.MinSalary = catagories.SelectSalary[minsal];
            Console.WriteLine("Maksimum Maaş:");
            var maxsal = SelectingMenu.choose("Maksimum Maaş:", arr2);
            posts.MaxSalary = catagories.SelectSalary[maxsal];

            string[] str1 = new string[catagories.SelectorAge.Count];
            for (int i = 0; i < catagories.SelectorAge.Count; i++)
            {
                str1[i] = catagories.SelectorAge[i].ToString();
            }
            var minage = SelectingMenu.choose("Minumum Yaş", str1);
            posts.MinAge = catagories.SelectorAge[minage];
            var maxage = SelectingMenu.choose("Maksimum Yaş", str1);
            posts.MaxAge = catagories.SelectorAge[maxage];

            string[] str3 = new string[catagories.SelectorEducation.Count];
            for (int i = 0; i < catagories.SelectorEducation.Count; i++)
            {
                str3[i] = catagories.SelectorEducation[i];
            }
            var edu = SelectingMenu.choose("Təhsil", str3);
            posts.Education = catagories.SelectorEducation[edu];

            string[] str4 = new string[catagories.SelectorExperience.Count];
            for (int i = 0; i < catagories.SelectorExperience.Count; i++)
            {
                str4[i] = catagories.SelectorExperience[i];
            }
            var wrkex = SelectingMenu.choose(str4);
            posts.WorkExperience = catagories.SelectorExperience[wrkex];
            Console.Clear();
            Console.Write("Namizədə Tələblər: "); string requirement = Console.ReadLine();
            posts.Requirementsforthecandidate = requirement;
            Console.Clear();
            Console.Write("İş Barəsində Məlumat: "); string info = Console.ReadLine();
            posts.Jobinformation = info;
            Console.Clear();
            Console.Write("Şirkətin Adı: "); string Companyname = Console.ReadLine();
            posts.CompanyName = Companyname;
            RelevantPerson:
            Console.Write("Əlaqədər Şəxs: "); string releavedperson = Console.ReadLine();
            Match match2 = regex2.Match(releavedperson);
            if (match2.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Ad yazıldıqda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto RelevantPerson; }
            else { posts.RelevantPerson = releavedperson; goto dt; }
            dt:
            posts.AdvertisementHistory = DateTime.Now;
            posts.Expirationdate = DateTime.Now.AddDays(31);
            employer.Posts.Add(posts);
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info($"{employer.Name} Vakansiya Paylasdi");
            SerializeVakancias(ref employer);
            Console.Clear();
            EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
        }
        public void CVCreater(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            var stremail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new(stremail);
            var PhoneControl = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex regex1 = new(PhoneControl);
            string Namecontrol = "[0-9]";
            Regex regex2 = new(Namecontrol);
            Console.Clear();
            cV = new CV();
            ad:
            Console.Write("Ad: "); string name = Console.ReadLine();
            Match match1 = regex2.Match(name);
            if (match1.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Ad yazıldıqda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto ad; }
            else { cV.Name = name; goto soya; }
            soya:
            Console.Clear();
            Console.Write("Soyad: "); string surname = Console.ReadLine();
            Match match2 = regex2.Match(surname);
            if (match2.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Soyad yazıldıqda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto soya; }
            else { cV.Surname = surname; goto father; }
            father:
            Console.Clear();
            Console.Write("Ata Adı: "); string fathername = Console.ReadLine();
            Match match3 = regex2.Match(fathername);
            if (match3.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Ad yazıldıqda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto father; }
            else { cV.FathersName = fathername; goto gender; }
            gender:
            string[] str = new string[catagories.SelectorGender.Count];
            for (int i = 0; i < catagories.SelectorGender.Count; i++)
            {
                str[i] = catagories.SelectorGender[i];
            }
            var select = SelectingMenu.choose(str);
            if (workers != null) cV.Gender = catagories.SelectorGender[select];
            string[] str1 = new string[catagories.SelectorAge.Count];
            for (int i = 0; i < catagories.SelectorAge.Count; i++)
            {
                str1[i] = catagories.SelectorAge[i].ToString();
            }
            var select2 = SelectingMenu.choose(str1, "");
            if (workers != null) cV.Age = catagories.SelectorAge[select2];
            string[] str3 = new string[catagories.SelectorEducation.Count];
            for (int i = 0; i < catagories.SelectorEducation.Count; i++)
            {
                str3[i] = catagories.SelectorEducation[i];
            }
            var select3 = SelectingMenu.choose(str3);
            if (workers != null) cV.Education = catagories.SelectorEducation[select3];
            Console.Clear();
            Console.Write("Detail: "); string detials = Console.ReadLine();
            cV.Details = detials;

            string[] str4 = new string[catagories.SelectorExperience.Count];
            for (int i = 0; i < catagories.SelectorExperience.Count; i++)
            {
                str4[i] = catagories.SelectorExperience[i];
            }
            var select4 = SelectingMenu.choose(str4);
            if (workers != null) cV.WorkExperience = catagories.SelectorExperience[select4];

            Console.Clear();
            Console.Write("Work Experience detail: "); string wrkdetails = Console.ReadLine();
            cV.WorkexperienceDetails = wrkdetails;

            string[] str5 = new string[catagories.SelectorHeader.Count];

            for (int i = 0; i < catagories.SelectorHeader.Count; i++)
            {
                str5[i] = catagories.SelectorHeader[i];
            }
            var select5 = SelectingMenu.choose(str5);
            cV.WorkCatagoriesHead = catagories.SelectorHeader[select5];
            if (select5 == 0) { SelectorWorkCatagory(0, 8, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 1) { SelectorWorkCatagory(8, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 2) { SelectorWorkCatagory(12, 6, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 3) { SelectorWorkCatagory(18, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 4) { SelectorWorkCatagory(23, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 5) { SelectorWorkCatagory(25, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 6) { SelectorWorkCatagory(29, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 7) { SelectorWorkCatagory(32, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 8) { SelectorWorkCatagory(36, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 9) { SelectorWorkCatagory(41, 11, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 10) { SelectorWorkCatagory(52, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            else if (select5 == 11) { SelectorWorkCatagory(55, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); }
            Console.Clear();
            Console.Write("Duty: "); string duty = Console.ReadLine();
            cV.Duty = duty;

            string[] arr = new string[catagories.SelectCity.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = catagories.SelectCity[i];
            }
            var city = SelectingMenu.choose(arr, "");
            cV.City = catagories.SelectCity[city];

            string[] arr2 = new string[catagories.SelectSalary.Count];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = catagories.SelectSalary[i].ToString();
            }
            var salary = SelectingMenu.choose(arr2, "");
            cV.MinSalary = catagories.SelectSalary[salary];
            Console.Clear();
            Console.Write("Enter Skills: "); string skills = Console.ReadLine();
            cV.Skills = skills;
            Console.Clear();
            Console.Write("Advance Information: "); string advance = Console.ReadLine();
            cV.AdvanceInformation = advance;
            Console.Clear();
            Console.Write("LINKEDIN Link: ");string linedinlink = Console.ReadLine();
            cV.LINKEDIN = linedinlink;
            Console.Clear();
            Console.Write("GITLINK Link: "); string gitlink = Console.ReadLine();
            cV.GITLINK = gitlink;
        a:
            Console.Clear();
            Console.Write("E-mail: "); string email = Console.ReadLine();
            Match match4 = regex.Match(email); if (match4.Success && email.Length >= 5) { cV.Email = email; goto b; }
            else { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Düzgün Email Daxil edin!!!"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto a; }
        b:
            Console.Clear();
            Console.Write("Telefon: "); string phone = Console.ReadLine();
            Match match5 = regex1.Match(phone);
            if (match5.Success) { cV.Phones = phone; goto tru; }
            else { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Yanlış daxil etdiniz!!!\nTelefon Nomrəsi daxil eliyərkən əvvəlcə()mötərizələr içərisinə nömrənin başlığını yazın daha sonra nömrəni"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto b; }
        tru:
            cV.AdvertisementHistory = DateTime.Now;
            cV.Expirationdate = DateTime.Now.AddDays(31);
            workers.cV.Add(cV);
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info($"{workers.Name} cv Paylasdi");
            SeralizeCV(ref workers);
            WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
        }
        public void EmployerNotifications(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            if (employer.notifications != null && employer.notifications.Count > 0)
            {
                for (int i = 0; i < employer.notifications.Count; i++)
                {
                    Console.WriteLine($"{i + 1}){employer.notifications[i].SenderName} {employer.notifications[i].SenderSurname}-Tərəfinnən sizə bildiriş var!!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Bildiriş Yoxdur");
                Thread.Sleep(1000);
                EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
            }
            Console.Write("Əlavə Məlumat üçün Seçim edin: "); int choo = Convert.ToInt32(Console.ReadLine());
            if (choo < 1 && choo > employer.notifications.Count + 1) { goto a; }
            Console.Clear();
            Console.WriteLine($"\n{employer.notifications[choo - 1].SenderName} {employer.notifications[choo - 1].SenderSurname} - {employer.notifications[choo - 1].Content}");
            Se:
            Console.Write("1)Cv-ni qəbul etmək\t2)Rədd Eləmək\t3)Sonra Yenidən baxaram");
            int cho = Convert.ToInt32(Console.ReadLine());
            if (cho == 1)
            {
                var index = employer.notifications[choo - 1].PostIndex;
                Console.WriteLine("İş elanıvız Silindi");
                Thread.Sleep(1000);
                employer.Posts.Remove(employer.Posts[index]);
                SerializeVakancias(ref employer);
                employer.notifications.Remove(employer.notifications[choo - 1]);
            }
            else if (cho == 2) { employer.notifications.Remove(employer.notifications[choo - 1]); }
            else if (cho ==3) { goto a; }
            else { goto Se; }
            EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
        }
        public  void WorkerNotifications(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            if (workers.notifications != null && workers.notifications.Count > 0)
            {
                for (int i = 0; i < workers.notifications.Count; i++)
                {
                    Console.WriteLine($"{i + 1}){workers.notifications[i].SenderName} {workers.notifications[i].SenderSurname}-Tərəfinnən sizə bildiriş var!!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Bildiriş Yoxdur");
                Thread.Sleep(1000);
                WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
            }
            Console.Write("Əlavə Məlumat üçün Seçim edin: "); int choo = Convert.ToInt32(Console.ReadLine());
            if (choo < 1 && choo > workers.notifications.Count + 1) { goto a; }
            Console.WriteLine($"\n{workers.notifications[choo - 1].SenderName} {workers.notifications[choo - 1].SenderSurname} - {workers.notifications[choo - 1].Content}");

            Se:
            Console.Write("1)İş təklifini qəbul etmək\t2)Rədd Eləmək\t3)Sonra Yenidən baxaram");
            int cho = Convert.ToInt32(Console.ReadLine());
            if (cho == 1)
            {
                var index = workers.notifications[choo - 1].PostIndex;
                Console.WriteLine("Sizin CV-niz silindi");
                Thread.Sleep(1000);
                workers.cV.Remove(workers.cV[index]);
                SeralizeCV(ref workers);
                workers.notifications.Remove(workers.notifications[choo - 1]);
            }
            else if (cho == 2) { workers.notifications.Remove(workers.notifications[choo - 1]); }
            else if (cho == 3) { goto a; }
            else { goto Se; }
            WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
        }
        public void ShowVakancies(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            var a = employers.FindAll(a => a.Name.Length >= 0);
            a.ForEach(a => a.Posts.ForEach(b => Console.WriteLine($"{b.WorkCatagoriesHead}\n{b.MinSalary} - {b.MaxSalary}\n{b.CompanyName}")));
            Console.Write("Enter the name of the Company you want to Search: ");
            ConsoleKeyInfo input2;
            input2 = Console.ReadKey(true);
            if (input2.Key == ConsoleKey.Backspace) { WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            string selector = Console.ReadLine();
            Console.Clear();
            int index = 0;
            for (int i = 0; i < employers.Count; i++)
            {
                for (int j = 0; j < employers[i].Posts.Count; j++)
                {
                    if (employers[i].Posts[j] != null)
                    {
                        if (employers[i].Posts[j].CompanyName == selector)
                        {
                            Console.WriteLine(employers[i].Posts[j]);
                            index = j;
                            b:
                            Console.Write("1)CV Göndərmək\t2)Keçmək");
                            int choo = Convert.ToInt32(Console.ReadLine());
                            if (choo == 1)
                            {
                                Notification notification = new Notification(workers.Name, workers.Surname, DateTime.Now, "Sizə Cv Gondərib", index);
                                employers[i].notifications.Add(notification);
                                Console.WriteLine("Cv-niz Gonərildi");
                                Thread.Sleep(1000);
                                Logger logger = LogManager.GetCurrentClassLogger();
                                logger.Info($"{workers1[i].Name} Cv gonderdi {employer.Name} Sexse");
                                WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                            }
                            else if (choo == 2){goto a;}
                            else { goto b; }
                        }
                    }
                }
            }
        }
        public void ShowWorkersCv(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            var a = workers1.FindAll(a => a.Name.Length >= 0);
            a.ForEach(a => a.cV.ForEach(b => Console.WriteLine($"{b.WorkCatagoriesHead}\n{b.MinSalary}\n{b.Name} {b.Surname}")));
            Console.Write("Enter the name next surname you want to Search: ");
            ConsoleKeyInfo input2;
            input2 = Console.ReadKey(true);
            if (input2.Key == ConsoleKey.Backspace) { EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            string name = Console.ReadLine(); string surname = Console.ReadLine();
            int index = 0;
            Console.Clear();
            for (int i = 0; i < workers1.Count; i++)
            {
                for (int j = 0; j < workers1[i].cV.Count; j++)
                {
                    if (workers1[i].cV[j].Name == name && workers1[i].cV[j].Surname == surname)
                    {
                        Console.WriteLine(workers1[i].cV[j]);
                        index = j;
                        b:
                        Console.Write("1)İş təklif etmək\t2)Keçmək");
                        int choo = Convert.ToInt32(Console.ReadLine());
                        if (choo == 1)
                        {
                            Notification notification = new Notification(employer.Name, employer.Surname, DateTime.Now, "Sizə iş təklif edir...", index);
                            workers1[i].notifications.Add(notification);
                            Console.WriteLine("iş təklifiniz göndərildi...");
                            Thread.Sleep(1000);
                            Logger logger = LogManager.GetCurrentClassLogger();
                            logger.Info($"{workers1[i].Name} Cv gonderdi {employer.Name} Sexse");
                            EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);

                        }
                        else if (choo == 2) { goto a; }
                        else { goto b; }
                    }
                }
            }
        }
        public void WorkerCatagoriesSearching(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            string[] str = new string[catagories.SelectorHeader.Count];

            for (int i = 0; i < catagories.SelectorHeader.Count; i++)
            {
                str[i] = catagories.SelectorHeader[i];
            }
            var catindex = SelectingMenu.choose(str);
            int catbodyindex = 0;

            if (catindex == 0) { var index = SearchWorkCatagory(0, 8, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 1) { var index = SearchWorkCatagory(8, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 2) { var index = SearchWorkCatagory(12, 6, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 3) { var index = SearchWorkCatagory(18, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 4) { var index = SearchWorkCatagory(23, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 5) { var index = SearchWorkCatagory(25, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 6) { var index = SearchWorkCatagory(29, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 7) { var index = SearchWorkCatagory(32, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 8) { var index = SearchWorkCatagory(36, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 9) { var index = SearchWorkCatagory(41, 11, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 10) { var index = SearchWorkCatagory(52, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 11) { var index = SearchWorkCatagory(55, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            string[] arr = new string[catagories.SelectCity.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = catagories.SelectCity[i];
            }
            var cityindex = SelectingMenu.choose(arr, "");

            string[] arr2 = new string[catagories.SelectSalary.Count];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = catagories.SelectSalary[i].ToString();
            }
            var salaryindex = SelectingMenu.choose(arr2, "");

            string[] str3 = new string[catagories.SelectorEducation.Count];
            for (int i = 0; i < catagories.SelectorEducation.Count; i++)
            {
                str3[i] = catagories.SelectorEducation[i];
            }
            var edu = SelectingMenu.choose(str3);

            string[] str4 = new string[catagories.SelectorExperience.Count];
            for (int i = 0; i < catagories.SelectorExperience.Count; i++)
            {
                str4[i] = catagories.SelectorExperience[i];
            }
            var select4 = SelectingMenu.choose(str4);
            string header = catagories.SelectorHeader[catindex];
            string body = catagories.SelectorBody[catbodyindex];
            string city = catagories.SelectCity[cityindex];
            int salary = catagories.SelectSalary[salaryindex];
            string education = catagories.SelectorEducation[edu];
            string experience = catagories.SelectorExperience[select4];
        a:
            Console.Clear();
            for (int i = 0; i < employers.Count; i++)
            {
                for (int j = 0; j < employers[i].Posts.Count; j++)
                {
                    if (employers[i].Posts[j].WorkCatagoriesHead == header || employers[i].Posts[j].WorkCatagories == body || employers[i].Posts[j].City == city || employers[i].Posts[j].MinSalary == salary || employers[i].Posts[j].Education == education || employers[i].Posts[j].WorkExperience == experience)
                    {
                        Console.WriteLine($"{employers[i].Posts[j].WorkCatagoriesHead}\n{employers[i].Posts[j].MinSalary} - {employers[i].Posts[j].MaxSalary}\n{employers[i].Posts[j].CompanyName}");
                        Console.Write("Enter the name of the Company you want to Search: ");
                        ConsoleKeyInfo input2;
                        input2 = Console.ReadKey(true);
                        if (input2.Key == ConsoleKey.Backspace) { WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
                        string selector = Console.ReadLine();
                        Console.Clear();
                        int index = 0;
                        if (employers[i].Posts[j] != null)
                        {
                            if (employers[i].Posts[j].CompanyName == selector)
                            {
                                Console.WriteLine(employers[i].Posts[j]);
                                index = j;
                                b:
                                Console.Write("1)CV Göndərmək\t2)Keçmək");
                                int choo = Convert.ToInt32(Console.ReadLine());
                                if (choo == 1)
                                {
                                    Notification notification = new Notification(workers.Name, workers.Surname, DateTime.Now, "Sizə Cv Gondərib", index);
                                    employers[i].notifications.Add(notification);
                                    Console.WriteLine("Cv-niz Gonərildi");
                                    Thread.Sleep(1000);
                                    Logger logger = LogManager.GetCurrentClassLogger();
                                    logger.Info($"{workers1[i].Name} Cv gonderdi {employer.Name} Sexse");
                                    WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                                }
                                else if (choo == 2){goto a;}
                                else { goto b; }
                            }
                        }
                    }
                }
            }
        }
        public void EmployerCatagoriesSearching(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            string[] str = new string[catagories.SelectorHeader.Count];

            for (int i = 0; i < catagories.SelectorHeader.Count; i++)
            {
                str[i] = catagories.SelectorHeader[i];
            }
            var catindex = SelectingMenu.choose(str);
            int catbodyindex = 0;
            if (catindex == 0) { var index = SearchWorkCatagory(0, 8, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 1) { var index = SearchWorkCatagory(8, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 2) { var index = SearchWorkCatagory(12, 6, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 3) { var index = SearchWorkCatagory(18, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 4) { var index = SearchWorkCatagory(23, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 5) { var index = SearchWorkCatagory(25, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 6) { var index = SearchWorkCatagory(29, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 7) { var index = SearchWorkCatagory(32, 4, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 8) { var index = SearchWorkCatagory(36, 5, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 9) { var index = SearchWorkCatagory(41, 11, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 10) { var index = SearchWorkCatagory(52, 3, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }
            else if (catindex == 11) { var index = SearchWorkCatagory(55, 2, ref catagories, ref workers, ref employer, ref posts, ref cV); catbodyindex = index; }

            string[] arr = new string[catagories.SelectCity.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = catagories.SelectCity[i];
            }
            var cityindex = SelectingMenu.choose(arr, "");

            string[] arr2 = new string[catagories.SelectSalary.Count];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = catagories.SelectSalary[i].ToString();
            }
            var salaryindex = SelectingMenu.choose(arr2, "");

            string[] str3 = new string[catagories.SelectorEducation.Count];
            for (int i = 0; i < catagories.SelectorEducation.Count; i++)
            {
                str3[i] = catagories.SelectorEducation[i];
            }
            var edu = SelectingMenu.choose(str3);

            string[] str4 = new string[catagories.SelectorExperience.Count];
            for (int i = 0; i < catagories.SelectorExperience.Count; i++)
            {
                str4[i] = catagories.SelectorExperience[i];
            }
            var select4 = SelectingMenu.choose(str4);

            string header = catagories.SelectorHeader[catindex];
            string body = catagories.SelectorBody[catbodyindex];
            string city = catagories.SelectCity[cityindex];
            int salary = catagories.SelectSalary[salaryindex];
            string education = catagories.SelectorEducation[edu];
            string experience = catagories.SelectorExperience[select4];
        a:
            Console.Clear();
            for (int i = 0; i < workers1.Count; i++)
            {
                for (int j = 0; j < workers1[i].cV.Count; j++)
                {
                    if (workers1[i].cV[j].WorkCatagoriesHead == header || workers1[i].cV[j].WorkCatagories == body || workers1[i].cV[j].City == city || workers1[i].cV[j].MinSalary == salary || workers1[i].cV[j].Education == education || workers1[i].cV[j].WorkExperience == experience)
                    {

                        Console.WriteLine($"{workers1[i].cV[j].WorkCatagoriesHead}\n{workers1[i].cV[j].MinSalary} - {workers1[i].cV[j].Name} {workers1[i].cV[j].Surname}");
                        Console.Write("Enter the name next surname you want to Search: ");
                        ConsoleKeyInfo input2;
                        input2 = Console.ReadKey(true);
                        if (input2.Key == ConsoleKey.Backspace) { EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
                        string name = Console.ReadLine(); string surname = Console.ReadLine();
                        Console.Clear();
                        int index = 0;
                        if (workers1[i].cV[j].Name == name && workers1[i].cV[j].Surname == surname)
                        {
                            Console.WriteLine(workers1[i].cV[j]);
                            index = j;
                            b:
                            Console.Write("1)İş təklif etmək\t2)Keçmək");
                            int choo = Convert.ToInt32(Console.ReadLine());
                            if (choo == 1)
                            {
                                Notification notification = new Notification(employer.Name, employer.Surname, DateTime.Now, "Sizə iş təklif edir...", index);
                                workers1[i].notifications.Add(notification);
                                Console.WriteLine("iş təklifiniz göndərildi...");
                                Thread.Sleep(1000);
                                Logger logger = LogManager.GetCurrentClassLogger();
                                logger.Info($"{employer.Name} iş təklifiniz göndərdi {workers1[i]} Sexse");
                                EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                            }
                            else if (choo == 2) { goto a; }
                            else { goto b; }
                        }
                    }
                    else{ Console.Write("Heç bir məlumat tapılmadı");Thread.Sleep(1000);}
                }
            }
        }
        public void WorkerSearching(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            Console.Write("Axtarış elədiyiviz vəzifəni daxil edin: ");
            string search = Console.ReadLine();
            for (int i = 0; i < employers.Count; i++)
            {
                for (int j = 0; j < employers[i].Posts.Count; j++)
                {
                    if (employers[i].Posts[j].Duty == search)
                    {
                        Console.WriteLine($"{employers[i].Posts[j].WorkCatagoriesHead}\n{employers[i].Posts[j].MinSalary} - {employers[i].Posts[j].MaxSalary}\n{employers[i].Posts[j].CompanyName}");
                        Console.Write("Enter the name of the Company you want to Search: ");
                        ConsoleKeyInfo input2;
                        input2 = Console.ReadKey(true);
                        if (input2.Key == ConsoleKey.Backspace) { WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
                        string selector = Console.ReadLine();
                        Console.Clear();
                        int index = 0;
                        if (employers[i].Posts[j] != null)
                        {
                            if (employers[i].Posts[j].CompanyName == selector)
                            {
                                Console.WriteLine(employers[i].Posts[j]);
                                index = j;
                                b:
                                Console.Write("1)CV Göndərmək\t2)Keçmək");
                                int choo = Convert.ToInt32(Console.ReadLine());
                                if (choo == 1)
                                {
                                    Notification notification = new Notification(workers.Name, workers.Surname, DateTime.Now, "Sizə Cv Gondərib", index);
                                    employers[i].notifications.Add(notification);
                                    Console.WriteLine("Cv-niz Gonərildi");
                                    Thread.Sleep(1000);
                                    Logger logger = LogManager.GetCurrentClassLogger();
                                    logger.Info($"{workers1[i].Name} Cv gonderdi {employer.Name} Sexse");
                                    WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                                }
                                else if (choo == 2){ goto a; }
                                else { goto b; }
                            }
                        }
                    }
                }
            }
        }
        public void EmployerSearching(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            Console.Write("Axtarış elədiyiviz vəzifəni daxil edin: ");
            string search = Console.ReadLine();
            for (int i = 0; i < workers1.Count; i++)
            {
                for (int j = 0; j < workers1[i].cV.Count; j++)
                {
                    if (workers1[i].cV[j].Duty == search)
                    {
                        Console.WriteLine($"{workers1[i].cV[j].WorkCatagoriesHead}\n{workers1[i].cV[j].MinSalary} - {workers1[i].cV[j].Name} {workers1[i].cV[j].Surname}");
                        Console.Write("Enter the name next surname you want to Search: ");
                        ConsoleKeyInfo input2;
                        input2 = Console.ReadKey(true);
                        if (input2.Key == ConsoleKey.Backspace) { EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
                        string name = Console.ReadLine(); string surname = Console.ReadLine();
                        Console.Clear();
                        int index = 0;
                        if (workers1[i].cV[j].Name == name && workers1[i].cV[j].Surname == surname)
                        {
                            Console.WriteLine(workers1[i].cV[j]);
                            index = j;
                            b:
                            Console.Write("1)İş təklif etmək\t2)Keçmək");
                            int choo = Convert.ToInt32(Console.ReadLine());
                            if (choo == 1)
                            {
                                Notification notification = new Notification(employer.Name, employer.Surname, DateTime.Now, "Sizə iş təklif edir...", index);
                                workers1[i].notifications.Add(notification);
                                Console.WriteLine("iş təklifiniz göndərildi...");
                                Thread.Sleep(1000);
                                Logger logger = LogManager.GetCurrentClassLogger();
                                logger.Info($"{employer.Name} iş təklifiniz göndərdi {workers1[i]} Sexse");
                                EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                            }
                            else if (choo == 2) { goto a; }
                            else { goto b; }
                        }
                    }
                }
            }
        }
        public void ExchangeWorkerorEmployerPage(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            string Namecontrol = "[0-9]";
            Regex regex1 = new(Namecontrol);
            var PhoneControl = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex regex = new(PhoneControl);
            string[] str = new string[2] { "Exchange Profil", "Back" };
            var select = SelectingMenu.choose(str);
            if (select == 0)
            {
                int f = 0;
                ConsoleKeyInfo input2;
                do
                {
                    Console.Clear();
                    if (f == 0) Console.BackgroundColor = ConsoleColor.Green;
                    if(workers!=null)Console.WriteLine($"Username: {workers.Username}");
                    else if (employer != null) { Console.WriteLine($"Username: {employer.Username}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 1) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"Password: {workers.Password}");
                    else if (employer != null) { Console.WriteLine($"Password: {employer.Password}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 2) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"Name: {workers.Name}");
                    else if (employer != null) { Console.WriteLine($"Name: {employer.Name}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 3) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"Surname: {workers.Surname}");
                    else if (employer != null) { Console.WriteLine($"Surname: {employer.Surname}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 4) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"City: {workers.City}");
                    else if (employer != null) { Console.WriteLine($"City: {employer.City}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 5) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"Age: {workers.Age}");
                    else if (employer != null) { Console.WriteLine($"Age: {employer.Age}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (f == 6) Console.BackgroundColor = ConsoleColor.Green;
                    if (workers != null) Console.WriteLine($"Phone: {workers.Phone}");
                    else if (employer != null) { Console.WriteLine($"Phone: {employer.Phone}"); }
                    Console.BackgroundColor = ConsoleColor.Black;
                    input2 = Console.ReadKey(true);
                    if (input2.Key == ConsoleKey.UpArrow)
                    {
                        f--;
                        if (f == -1) { f = 6; }
                    }
                    else if (input2.Key == ConsoleKey.DownArrow)
                    {
                        f++;
                        if (f == 7) { f = 0; }
                    }
                    else if (input2.Key == ConsoleKey.Backspace) { WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
                    else if (input2.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        if (f == 0) {
                        a: Console.Write("Username Daxil edin: "); string username = Console.ReadLine();
                        if (username.Length < 4) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Username uzunluğu azdır min 4 xarakter "); Console.BackgroundColor = ConsoleColor.Black; goto a; } 
                        else { if (workers != null) workers.Username = username; else if (employer != null) employer.Username = username;}}
                        else if (f == 1) {
                        b: Console.Write("Password Daxil edin: "); string Password = Console.ReadLine();
                        if (Password.Length < 4) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Password uzunluğu azdır min 4 xarakter "); Console.BackgroundColor = ConsoleColor.Black; goto b; }
                        else { if (workers != null) workers.Password = Password; else if (employer != null) employer.Password = Password;} }
                        else if (f == 2) {nam:
                        Console.Write("Yeni Ad daxil edin: "); string name = Console.ReadLine(); Match match = regex1.Match(name);
                        if (match.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Ad yazılanda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black;goto nam; }
                        else { goto c; }
                        c:
                        if (workers != null) workers.Name = name; else if (employer != null) employer.Name = name;}
                        else if (f == 3) {sur:
                        Console.Write("Yeni Soyad daxil edin: "); string surname = Console.ReadLine(); Match match = regex1.Match(surname);
                        if (match.Success) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Soyad yazılanda rəqəm istifadə eləmək olmaz!!!"); Console.BackgroundColor = ConsoleColor.Black; goto sur; }
                        else { goto d; }
                        d:
                        if (workers != null) workers.Surname = surname; else if (employer != null) employer.Surname = surname; }
                        else if (f == 4)
                        {
                            string[] str1 = new string[catagories.SelectCity.Count];
                            for (int i = 0; i < catagories.SelectCity.Count; i++)
                            {
                                str1[i] = catagories.SelectCity[i];
                            }
                            var a = SelectingMenu.choose(str1, "");
                            if (workers != null) workers.City = catagories.SelectCity[a];
                            else if (employer != null)employer.City = catagories.SelectCity[a];
                        }
                        else if (f == 5)
                        {
                            string[] str2 = new string[catagories.SelectorAge.Count];
                            for (int i = 0; i < catagories.SelectorAge.Count; i++)
                            {
                                str2[i] = catagories.SelectorAge[i].ToString();
                            }
                            var a = SelectingMenu.choose(str2, "");
                            if (workers != null) workers.Age = catagories.SelectorAge[a];
                            else if (employer != null) employer.Age = catagories.SelectorAge[a];
                        }
                        else if (f == 6) {
                            num:
                        Console.Write("Yeni Telefon nömrəsi daxil edin{()mötərizə içərisini əvvəla baslığı yazın daha sonra nomrə}: "); string number = Console.ReadLine();
                            Match match = regex.Match(number);
                            if (match.Success) {goto num2; }
                            else { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Nömrə düzgün yazılmayıb!!!"); Console.BackgroundColor = ConsoleColor.Black; goto num; }
                            num2:
                            if (workers != null) workers.Phone = number;
                            else if (employer != null) employer.Phone = number;}
                    }
                } while (input2.Key != ConsoleKey.Escape);
            }
            else if (select == 1) { 
                if (workers != null) WorkerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts);
                else if (employer != null) { EmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            }
        }
        public void WorkerPage(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            string[] str = new string[7] { "My Profil", "Vakancias", "Create CV", "Searching", "Catagories", "Notification", "Back" };
            var select = SelectingMenu.choose(str);
            Console.WriteLine(select);
            if (select == 0) { ExchangeWorkerorEmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 1) { ShowVakancies(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 2) { CVCreater(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 3) { WorkerSearching(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 4) { WorkerCatagoriesSearching(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 5) { WorkerNotifications(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 6) { Start(ref workers1, ref employers); }
        }
        public void EmployerPage(ref Worker.Worker workers, ref Catagories.Catagories catagories, ref CV cV, ref Employer.Employer employer, ref List<Worker.Worker> workers1, ref List<Employer.Employer> employers, ref Posts.Posts posts)
        {
            string[] str = new string[7] { "My Profil", "Worker's CV", "Add Vacansia", "Searching", "Catagories", "Notification", "Back" };
            var select = SelectingMenu.choose(str);
            if (select == 0) { ExchangeWorkerorEmployerPage(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 1) { ShowWorkersCv(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 2) { CreateVacansia(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 3) { EmployerSearching(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 4) { EmployerCatagoriesSearching(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 5) { EmployerNotifications(ref workers, ref catagories, ref cV, ref employer, ref workers1, ref employers, ref posts); }
            else if (select == 6) { Start(ref workers1, ref employers); }
        }
        public void Register(ref List<Worker.Worker> workers, ref List<Employer.Employer> employer,ref Catagories.Catagories catagories)
        {
            string Namecontrol = "[0-9]";
            Regex regex1 = new(Namecontrol);
            var PhoneControl = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex regex = new(PhoneControl);
        a:
            Console.Clear();
            Console.Write("Username: "); string username = Console.ReadLine();
            for (int i = 0; i < workers.Count; i++)
            {
                if (username == workers?[i].Username) { Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Bu Username artıq mövcuddur"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto a; }
            }
            for (int i = 0; i < employer.Count; i++)
            {
                if (username == employer?[i].Username) {Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("Bu Username artıq mövcuddur"); Console.BackgroundColor = ConsoleColor.Black; Thread.Sleep(1000); goto a; }
            }
            if (username.Length < 3) { goto a; }
        b:
            Console.Write("Password: "); string password = Console.ReadLine();
            if (username.Length < 3) { goto b; }
            Console.Clear();
            ad:
            Console.Write("Ad: "); string name = Console.ReadLine();
            Match match1 = regex1.Match(name);
            if (match1.Success) { Console.WriteLine("Ad yazıldıqda rəqəm istifadə eləmək olmaz!!!");Thread.Sleep(1000); goto ad; }
            else {goto soya; }
            soya:
            Console.Clear();
            Console.Write("Soyad: "); string surname = Console.ReadLine();
            Match match2 = regex1.Match(surname);
            if (match2.Success) { Console.WriteLine("Soyad yazıldıqda rəqəm istifadə eləmək olmaz!!!"); Thread.Sleep(1000); goto soya; }
            else { goto city; }
            city:
            string[] arr = new string[catagories.SelectCity.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = catagories.SelectCity[i];
            }
            var city = SelectingMenu.choose(arr, "");
        c:
            Console.Clear();
            Console.Write("Telefon: "); string phone = Console.ReadLine();
            Match match = regex.Match(phone);
            if (match.Success) { goto tru;  }
            else { Console.WriteLine("Yanlış daxil etdiniz!!!\nTelefon Nomrəsi daxil eliyərkən əvvəlcə()mötərizələr içərisinə nömrənin başlığını yazın daha sonra nömrəni");Thread.Sleep(2000); goto c; }
            tru:
            string[] str1 = new string[catagories.SelectorAge.Count];
            for (int i = 0; i < catagories.SelectorAge.Count; i++)
            {
                str1[i] = catagories.SelectorAge[i].ToString();
            }
            var select2 = SelectingMenu.choose(str1, "");
            var employer1 = new Employer.Employer(username, password, name, surname, catagories.SelectCity[city], phone, catagories.SelectorAge[select2]);
            var worker = new Worker.Worker(username, password, name, surname, catagories.SelectCity[city], phone, catagories.SelectorAge[select2]);
        d:
            Console.Clear();
            Console.Write("1)İşə götürən\t2)iş axtaran");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1) {
                employer1.notifications = new List<Notification>();
                employer1.Posts = new List<Posts.Posts>();
                employer.Add(employer1);
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Info($"{employer1.Name} Qeydiyyat olundu Ise goturen kimi");
                Console.WriteLine("Uğurla Qeydiyyat olundunuz"); Thread.Sleep(2000);SerializeEmployer(ref employer); }
            else if (choose == 2) {
                worker.notifications = new List<Notification>();
                worker.cV = new List<CV>();      
               workers.Add(worker);
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Info($"{worker.Name} Qeydiyyat olundu Is axtaran kimi"); Console.WriteLine("Uğurla Qeydiyyat olundunuz"); Thread.Sleep(2000);SerializeWorker(ref workers); }
            else { goto d; }
            Start(ref workers,ref employer);
        }
        public void Login(ref List<Worker.Worker> workers, ref List<Employer.Employer> employer, ref Catagories.Catagories catagories, ref CV cV, ref Posts.Posts posts)
        {
        a:
            Console.Clear();
            Console.Write("Username: "); string user = Console.ReadLine();
            Console.Write("Password: "); string pass = Console.ReadLine();
            var worker = workers.Find(w => w.Username == user && w.Password == pass);
            var employ = employer.Find(e => e.Username == user && e.Password == pass);
            if (worker?.Username == user && worker?.Password == pass) { WorkerPage(ref worker, ref catagories, ref cV, ref employ, ref workers, ref employer, ref posts); DeserialzeCV(ref worker);
                SeralizeCV(ref worker);
            }
            if (employ?.Username == user && employ?.Password == pass) { EmployerPage(ref worker, ref catagories, ref cV, ref employ, ref workers, ref employer, ref posts); }
            else{ Console.WriteLine("False Information Pleas Try Again: ");goto a;}
        }
        public void Start(ref List<Worker.Worker> workers, ref List<Employer.Employer> employer)
        {
        var catagories = new Catagories.Catagories();
        var posts = new Posts.Posts();
        var cV = new CV();

        catagories.SelectorBody = new List<string>() {
        "Kredit Mütəxəssisi","Sığorta","Audit","Mühasib","Maliyyə analizi","Bank Xidməti","Kassir",
        "İqtisatçı","Marketinq Menecment","İctimayətlə əlaqədər","Reklam", "KopiRaytinq","Sistem İdarəetməsi",
        "Məlumat Bazasının idarə edilməsi və inkişafı","IT Mütəxəssiz/Məsləhətçi ","Proqramlaşdırma","IT Layihələrin idarə edilməsi",
        "Texniki avadanlıq Mütəxəssisi","İnzibati dəstək", "Menecment","Ofis Menecmenti","Katibə/Resepşın","Heyətin idarə olunması",
        "Daşınmaz əmlak agenti/Makler","Satış üzrə mütəxəssiz","Web Dizayn","Memar/İnteryer Dizayn","Geyim dizaynı","Rəssam","Vəkil",
        "Cinayət Hüququ","HüquqŞünas","Məktəb Tədrisi","Universitet tədrisi","Repetitor","Xüsusi Təhsil","Avtomatlaşsırılmış İdarəetmə",
        "Tikinti","Kənd təsərrüfatı","Mühəndis","Geologiya və ətraf mühit","Xadimə","Anbardar","Restoran işi",
        "Sürücü","Dayə","Fəhlə","Turizm və mehmanxana işi","Tərcüməçi","Mühafizə xidmıti",
        "Spa və gözəllik","Kuryer","Həkim","Tibb personal","Tibb Təmsilcisi","Jurnalistika","Tələbələr üçün"
        };
        catagories.SelectCity = new List<string>()
        {
        "Ağcabədi","Ağdam","Ağdaş", "Ağdərə", "Ağstafa","Ağsu","Astara","Bakı","Babək",
        "Balakən","Beyləqan","Bərdə","Biləsuvar","Cəbrayıl","Cəlilabad","Culfa",
        "Daşkəsən","Əli-Bayramlı","Füzuli","Gədəbəy","Gəncə","Goranboy","Göyçay","Göygöl",
        "Hacıqabul","Xaçmaz","Xızı","Xocalı","Xocavənd","İmişli","İsmayıllı","Kəlbəcər","Kəngərli",
        "Kürdəmir","Qəbələ","Qax","Qazax","Qobustan","Quba","Qubadlı","Qusar",
        "Laçın","Lənkəran","Lerik","Masallı","Neftçala","Oğuz","Ordubad","Saatlı",
        "Sabirabad","Sədərək","Salyan","Samux","Şabran","Şahbuz","Şəki","Şamaxı",
        "Şəmkir","Şərur","Şuşa","Siyəzən","Tərtər","Tovuz","Ucar","Yardımlı",
        "Yevlax","Zəngilan","Zaqatala","Zərdab"
        };
        catagories.SelectorHeader = new List<string>() {
        "Maliyə","Marketinq","Informasiya Texnologiyaları","Inzibati","Satış","Dizayn",
        "Hüquqşünaslıq","Təhsil və elm","Sənayye və kənd təsərrüfatı","Xidmət","Tibb və əczaçılıq","Müxtəlif"
        };
        catagories.SelectorExperience = new List<string>() { "Təcrübə yoxdur", "1 ildən aşagı", "1 ildən 3 ilə qədər", "3 ildən 5 ilə qədər", "5 ildən artıq" };
        catagories.SelectorEducation = new List<string>() { "Elmi dərəcə", "Ali", "Natamam Ali", "Orta texniki", "Orta Xüsusi", "Orta", "Təhsilsiz" };
        catagories.SelectSalary = new List<int>() {
        100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100,
        2200, 2300, 2400, 2500, 2600, 2700, 2800, 2900, 3000,4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000 };
        catagories.SelectorAge = new List<int>() {
        18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,
        39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63
        };
        catagories.SelectorGender = new List<string>() { "Kişi", "Qadın", "Digər" };
        string[] arr = new string[2] { "Login", "Register" };
        var select = SelectingMenu.choose(arr);
            if (select == 0) { Login(ref workers, ref employer, ref catagories, ref cV, ref posts); }
            else if (select == 1) { Register(ref workers, ref employer, ref catagories); }
        }
        

    }
}
