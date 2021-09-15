using System;
using ConsoleApp21.Worker;
using ConsoleApp21.Employer;
using System.Collections.Generic;
using ConsoleApp21.Cv;
using ConsoleApp21.Notifications;
using ConsoleApp21.Posts;
using ConsoleApp21.ControlPanel;

class Program
{
    static void Main(string[] args)
    {
        List<Worker> workers = new List<Worker>()
        {
            new Worker("Samir","Samo123","Samir","Ibadli","Baki","+994551123322",26),
            new Worker("Qasim","Qaso123","Qasim","Balayev","Baki","+994556665599",28),
            new Worker("Qurban","Quro123","Qurban","Qurbanli","Baki","+994551124322",26),
            new Worker("Kamran","Kamo123","Kamran","Nadirli","Baki","+994551123322",26),
        };
        List<Employer> employer = new List<Employer>()
        {
            new Employer("Nicat","Nico123","Nicat","Nebiyev","Baki","+994551123322",26),
            new Employer("Ruslan","Ruso123","Ruslan","Eliyev","Baki","+994556665599",28),
            new Employer("Natiq","Nato123","Natiq","Kelenterli","Baki","+994551124322",26),
            new Employer("Alik","Alik123","Elesger","Memmedov","Baki","+994551123322",26),
        };
        foreach (var item in workers)
        {
            item.cV = new List<CV>();
        }
        foreach (var item in employer)
        {
            item.Posts = new List<Posts>();
        }
        foreach (var item in workers)
        {
            item.notifications = new List<Notification>();
        }
        foreach (var item in employer)
        {
            item.notifications = new List<Notification>();
        }

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        var control = new ControlPanel();
        control.DeserializeWorker(ref workers);
        control.SerializeWorker(ref workers);
        control.DeserializeEmployer(ref employer);
        control.SerializeEmployer(ref employer);
        
        
        control.Start(ref workers,ref employer);
        

    }


}