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
    class ViewAllAdapter : RecyclerView.Adapter
    {
        private List<Students> myviewalldatalist;
        private ViewAllActivity viewAllActivity;

        public ViewAllAdapter(List<Students> myviewalldatalist, ViewAllActivity viewAllActivity)
        {
            this.myviewalldatalist = myviewalldatalist;
            this.viewAllActivity = viewAllActivity;
        }

        public override int ItemCount => myviewalldatalist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewAllDataViewHolder viewAllDataViewHolder = holder as ViewAllDataViewHolder;
            viewAllDataViewHolder.BindData(myviewalldatalist[position]);
            viewAllDataViewHolder.ItemView.Click += (s, e) =>
            {

                Toast.MakeText(viewAllActivity, myviewalldatalist[position].sName, ToastLength.Short).Show();
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.viewalldatalist, parent, false);
            return new ViewAllDataViewHolder(view);
        }
    }

    class ViewAllDataViewHolder : RecyclerView.ViewHolder
    {
        private TextView myRollNo1;
        private TextView myName1;
        private TextView myMarks1;
        public ViewAllDataViewHolder(View itemView) : base(itemView)
        {

            myRollNo1 = ItemView.FindViewById<TextView>(Resource.Id.roll);
            myName1 = ItemView.FindViewById<TextView>(Resource.Id.Name);
            myMarks1 = ItemView.FindViewById<TextView>(Resource.Id.Marks);


        }

        internal void BindData(Students students)
        {
            myRollNo1.Text = students.srollno.ToString();
            myName1.Text = students.sName;
            myMarks1.Text = students.sMarks.ToString();
        }
    }
}