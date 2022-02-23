using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using StudentsDetailsApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace StudentsDetailsApp
{
    class StudentDataB
    {

        public static string DBname = "SQLite.db3";
        public static string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteconnection;

        public StudentDataB()
        {
            try {

                Console.WriteLine(DatabasePath);
                sqliteconnection = new SQLiteConnection(DatabasePath);
                Console.WriteLine("Database Created Sucessfully");

            }
            catch(Exception ex)
            {
                Console.WriteLine("Database Exception"+ex);

            }

        }

        public void CreateStudent()
        {
            try
            {

                var create = sqliteconnection.CreateTable<Students>();
                Console.WriteLine("Table Created Sucessfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Table creation Exception"+ex);

            }
        }

        public bool InstertStudent(Students students)
        {
            var result = sqliteconnection.Insert(students);
            if(result == -1)
            {

                return false;
            }
            else
            {
                Console.WriteLine("Inserted data Sucessfully");
                return true;

            }

        }

        public bool ModifyStudent(Students students)
        {
            var result = sqliteconnection.Update(students);
            if (result == -1)
            {

                return false;
            }
            else
            {
                Console.WriteLine("Inserted data Sucessfully");
                return true;

            }

        }

        public bool DeleteStudent(Students students)
        {
            var result = sqliteconnection.Delete(students);
            if (result == -1)
            {

                return false;
            }
            else
            {
                Console.WriteLine("Inserted data Sucessfully");
                return true;

            }

        }

        public List<Students> GetStudents()
        {
            var sdata = sqliteconnection.Table<Students>().ToList();
            return sdata;

        
        }

        public Students GetStudentsByRollNo(int studRollno)
        {

            var userdata = sqliteconnection.Table<Students>().Where(u => u.srollno == studRollno).FirstOrDefault();
            return userdata;


        }

    }
}