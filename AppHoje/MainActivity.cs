using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using AppHoje.DataModel;
using System.Collections.Generic;
using AppHoje.Adapter;

namespace AppHoje
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText myEditText;
        ImageView btnAdicionar;
        ImageView btnBuscar;
        RecyclerView myRecyclerView;
        List<Prato> listaPratos; 
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

            CriarDados();
            SetupRecyclerView();

        }

        private void SetupRecyclerView()
        {
            myRecyclerView.SetLayoutManager(new LinearLayoutManager(myRecyclerView.Context));
            HojeAdapter adapter = new HojeAdapter(listaPratos);
            myRecyclerView.SetAdapter(adapter);
        }

        private void CriarDados()
        {
            listaPratos = new List<Prato>();
            listaPratos.Add(new Prato
            {
                ID = 20,
                Nome = "Massa com Isca",
                Descricao = "Massa contem glutem e a Isca não pode ser frita",
                Set = "2013",
                Status = "Vermelho"
            });
            listaPratos.Add(new Prato
            {
                ID = 20,
                Nome = "Salada verde",
                Descricao = "Alimento com muitos nutrientes",
                Set = "2014",
                Status = "Verde"
            });
            listaPratos.Add(new Prato
            {
                ID = 20,
                Nome = "Sopa de Feijão",
                Descricao = "Ajuda a perder peso",
                Set = "2013",
                Status = "Verder"
            });
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