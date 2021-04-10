using System;

namespace WebApplication1.Models{
    public class Student{
        public string imie {get;set;}
        public string nazwisko {get;set;}
        public string numerIndeksu {get;set;}
        public string dataUrodzenia {get;set;}
        public string studia {get;set;}
        public string tryb {get;set;}
        public string email {get;set;}
        public string imie_ojca {get;set;}
        public string imie_matki {get;set;}

        internal static Student FromCsv(string v)
        {
            Console.WriteLine(v);
            string[] vals = v.Split(';');
            Student student = new Student();
            student.imie = vals[0];
            student.nazwisko = vals[1];
            student.numerIndeksu = vals[2];
            student.dataUrodzenia = vals[3];
            student.studia = vals[4];
            student.tryb = vals[5];
            student.email = vals[6];
            student.imie_ojca = vals[7];
            student.imie_matki = vals[8];
            return student;
        }
        
    }
}