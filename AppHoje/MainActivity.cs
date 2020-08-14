using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

namespace AppHoje
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText myEditText;
        ImageView btnAdicionar;
        ImageView btnBuscar;
        RecyclerView myRecyclerView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            myEditText = (EditText)FindViewById(Resource.Id.txtBuscar);
            btnAdicionar = (ImageView)FindViewById(Resource.Id.btnNovo);
            btnBuscar = (ImageView)FindViewById(Resource.Id.btnProcurar);
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);

            btnBuscar.Click += BtnBuscar_Click;


        }

        private void BtnBuscar_Click(object sender, System.EventArgs e)
        {
            if(myEditText.Visibility == Android.Views.ViewStates.Gone)
            {
                myEditText.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                myEditText.ClearFocus();
                myEditText.Visibility = Android.Views.ViewStates.Gone;

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}