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
    class ViewAdapter : RecyclerView.Adapter
    {
        private List<Students> myviewdatalist;
        private ViewActivity viewActivity;

        public ViewAdapter(List<Students> myviewdatalist, ViewActivity viewActivity)
        {
            this.myviewdatalist = myviewdatalist;
            this.viewActivity = viewActivity;
        }

        public override int ItemCount => myviewdatalist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ViewDataViewHoder viewDataViewHoder = holder as ViewDataViewHoder;
            viewDataViewHoder.BindData(myviewdatalist[position]);

            viewDataViewHoder.ItemView.Click += (s, e) =>
             {

                 Toast.MakeText(viewActivity, myviewdatalist[position].sName, ToastLength.Short).Show();
             };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.viewdatabyroll, parent, false);
            return new ViewDataViewHoder(view);
        }
    }

    class ViewDataViewHoder : RecyclerView.ViewHolder
    {
        private TextView myRollNo;
        private TextView myName;
        private TextView myMarks;
        public ViewDataViewHoder(View itemView) : base(itemView)
        {

            myRollNo = ItemView.FindViewById<TextView>(Resource.Id.studentroll);
            myName = ItemView.FindViewById<TextView>(Resource.Id.studentName);
            myMarks = ItemView.FindViewById<TextView>(Resource.Id.studentMarks);
        }

        internal void BindData(Students students)
        {
            myRollNo.Text = students.srollno.ToString();
            myName.Text = students.sName;
            myMarks.Text = students.sMarks.ToString();
        }
    }
}