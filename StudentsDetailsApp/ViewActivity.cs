using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using StudentsDetailsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsDetailsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ViewActivity : Activity
    {
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager mymanager;
        List<Students> myviewdatalist;
        private ViewAdapter myadapter;
        private Students myStudents;
        private StudentDataB sDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewdata);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

          

            GetViewData();

            recyclerView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));

            mymanager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(mymanager);

            myadapter = new ViewAdapter(myviewdatalist, this);
            recyclerView.SetAdapter(myadapter);



        }

        private List<Students> GetViewData()
        {

            if (Intent.Extras != null)
            {
                int rollno = Intent.Extras.GetInt("RollNo", 0);
                sDB = new StudentDataB();

                var studentsData = sDB.GetStudentsByRollNo(rollno);

                myviewdatalist = new List<Students>();

                myviewdatalist.Add(studentsData);

            }
            return myviewdatalist;
        

        }
    }
}