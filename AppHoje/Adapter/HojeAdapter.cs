using System;

using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using AppHoje.DataModel;
using Android.Support.V7.Widget;

namespace AppHoje.Adapter
{
    class HojeAdapter : RecyclerView.Adapter
    {
        public event EventHandler<HojeAdapterClickEventArgs> ItemClick;
        public event EventHandler<HojeAdapterClickEventArgs> ItemLongClick;
        List<Prato> items;

        public HojeAdapter(List<Prato> data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.hojerow;
            itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var vh = new HojeAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as HojeAdapterViewHolder;
            holder.txtNome.Text = items[position].Nome;
            holder.txtDepartamento.Text = items[position].Descricao;
            holder.txtStatus.Text = items[position].Status;
            holder.txtTexto.Text = items[position].Set;
        }

        public override int ItemCount => items.Count;

        void OnClick(HojeAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(HojeAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class HojeAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView txtNome { get; set; }
        public TextView txtDepartamento { get; set; }
        public TextView txtTexto { get; set; }
        public TextView txtStatus { get; set; }
        public ImageView imgDelete { get; set; }


        public HojeAdapterViewHolder(View itemView, Action<HojeAdapterClickEventArgs> clickListener,
                            Action<HojeAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;
            txtNome = (TextView)itemView.FindViewById(Resource.Id.txtNome);
            txtDepartamento = (TextView)itemView.FindViewById(Resource.Id.txtDepartamento);
            txtTexto = (TextView)itemView.FindViewById(Resource.Id.txtTexto);
            txtStatus = (TextView)itemView.FindViewById(Resource.Id.txtStatus);
            imgDelete = (ImageView)itemView.FindViewById(Resource.Id.imgDelete);

            itemView.Click += (sender, e) => clickListener(new HojeAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new HojeAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class HojeAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}