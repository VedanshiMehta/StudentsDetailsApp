using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsDetailsApp.Model
{
    [Table("StudentsData")]
    class Students
    {
        [PrimaryKey]
        [Column("RollNo")]
        public int srollno { get; set; }

  
        [Column("StudentsName")]
        public string sName { get; set; }

     
        [Column("StudentsMarks")]
        public  int sMarks { get; set; }
    }
}