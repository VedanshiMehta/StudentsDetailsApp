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
    public class ViewAllActivity : Activity
    {
        private RecyclerView myrecyclerView;
        private RecyclerView.LayoutManager mylayoutmanager;
        private ViewAllAdapter viewalladapter;
        private List<Students> myviewalldatalist;
        private StudentDataB sDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewalldata);

            myrecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView2);

            ViewAllData();

            myrecyclerView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));

            mylayoutmanager = new LinearLayoutManager(this);
            myrecyclerView.SetLayoutManager(mylayoutmanager);

            viewalladapter = new ViewAllAdapter(myviewalldatalist, this);
            myrecyclerView.SetAdapter(viewalladapter);


        }

        private List<Students> ViewAllData()
        {
            sDB = new StudentDataB();
            var studdata = sDB.GetStudents();

            myviewalldatalist = new List<Students>();

            myviewalldatalist.AddRange(studdata);

            return myviewalldatalist;
        }
    }
}