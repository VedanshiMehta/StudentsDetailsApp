using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using StudentsDetailsApp.Model;
using System;

namespace StudentsDetailsApp
{
   
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText myRollNo;
        private EditText myName;
        private EditText myMarks;
        private Button myAddB;
        private Button myDelete;
        private Button myModify;
        private Button myView;
        private Button myViewAll;
        private StudentDataB sDB;
        private Students mstudents;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            UIClickevents();
            sDB = new StudentDataB();
            sDB.CreateStudent();
            mstudents = new Students();
        }

        private void UIClickevents()
        {
            myAddB.Click += MyAddB_Click;
            myDelete.Click += MyDelete_Click;
            myModify.Click += MyModify_Click;
            myView.Click += MyView_Click;
            myViewAll.Click += MyViewAll_Click;
        }

        private void MyViewAll_Click(object sender, EventArgs e)
        {
            Intent j = new Intent(this, typeof(ViewAllActivity));
            StartActivity(j);
        }

        private void MyView_Click(object sender, EventArgs e)
        {
            var sdata = sDB.GetStudents();
            foreach (var rollno in sdata)
            {
                
                int roll = rollno.srollno;
                if (roll == int.Parse(myRollNo.Text))
                {
                    Intent i = new Intent(this, typeof(ViewActivity));
                    i.PutExtra("RollNo", roll);
                    StartActivity(i);
                }
            }
            
        }

        private void MyModify_Click(object sender, EventArgs e)
        {
            if (myRollNo.Text != string.Empty && myName.Text != string.Empty && myMarks.Text != string.Empty)
            {
                int roll = int.Parse(myRollNo.Text);
                mstudents = sDB.GetStudentsByRollNo(roll);


                if (mstudents != null)
                {
                    mstudents.srollno = int.Parse(myRollNo.Text);
                    mstudents.sName = myName.Text;
                    mstudents.sMarks = int.Parse(myMarks.Text);

                    var isupdated = sDB.ModifyStudent(mstudents);
                    if (isupdated == true)
                    {
                        Toast.MakeText(this, "Data Updated Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                    }

                }
            }
            else
            {

                Toast.MakeText(this, "Enter details in particular given field", ToastLength.Short).Show();
            }
        }

        private void MyDelete_Click(object sender, EventArgs e)
        {
            int roll = int.Parse(myRollNo.Text);
            mstudents = sDB.GetStudentsByRollNo(roll);

            if (mstudents != null)
            {
                var isDeleted = sDB.DeleteStudent(mstudents);
                if (isDeleted == true)
                {
                    Toast.MakeText(this, "Data Deleted Succesfully", ToastLength.Short).Show();
                }

                else
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                }

            }
        }

        private void MyAddB_Click(object sender, EventArgs e)
        {
            if (myRollNo.Text != string.Empty && myName.Text != string.Empty && myMarks.Text != string.Empty)
            {
                mstudents.srollno = int.Parse(myRollNo.Text);
                mstudents.sName = myName.Text;
                mstudents.sMarks = int.Parse(myMarks.Text);

                var isinserted = sDB.InstertStudent(mstudents);
                if (isinserted == true)
                {
                    Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                }
            }
            else
            {

                Toast.MakeText(this, "Enter details in particular given field", ToastLength.Short).Show();
            }
        }

        private void UIReference()
        {
            myRollNo = FindViewById<EditText>(Resource.Id.editText1);
            myName = FindViewById<EditText>(Resource.Id.editText2);
            myMarks = FindViewById<EditText>(Resource.Id.editText3);
            myAddB = FindViewById<Button>(Resource.Id.buttonA);
            myDelete = FindViewById<Button>(Resource.Id.buttonD);
            myModify = FindViewById<Button>(Resource.Id.buttonM);
            myView = FindViewById<Button>(Resource.Id.buttonV);
            myViewAll = FindViewById<Button>(Resource.Id.buttonVA);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}