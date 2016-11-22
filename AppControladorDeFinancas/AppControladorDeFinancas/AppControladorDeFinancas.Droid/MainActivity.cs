using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AppControladorDeFinancas.Droid
{
	[Activity (Label = "Controlado Financeiro", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        List<Cartao> cartoes;
        List<string> cartoesString;
        private ArrayAdapter<Cartao> adapter;
        private ArrayAdapter<string> listaString;
        private TextView descricaoCartao;
        private TextView valorItem;
        private ListView lista;
        private Button btnNovoCartao;
        private Button btnSelecionaCartao;
        private Button btnValorAtual;
        private Button btnAdcionaItem;


        private void iniciaInterface()
        {
            cartoes = new List<Cartao>();
            cartoesString = new List<string>();
            btnNovoCartao = FindViewById<Button>(Resource.Id.btnNovoCartao);
            btnValorAtual = FindViewById<Button>(Resource.Id.btnValorAtual);
            btnSelecionaCartao = FindViewById<Button>(Resource.Id.btnSelecionarCartao);
            btnAdcionaItem = FindViewById<Button>(Resource.Id.btnAdicionaItem);
            lista = FindViewById<ListView>(Resource.Id.listaCartoes);
            descricaoCartao = FindViewById<TextView>(Resource.Id.descricaoItem);
            valorItem = FindViewById<TextView>(Resource.Id.valorItem);
            adapter = new ArrayAdapter<Cartao>(this, Android.Resource.Layout.SimpleListItem1, cartoes);
            listaString = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, cartoesString);
        }
        protected override void OnCreate (Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            iniciaInterface();            

            btnNovoCartao.Click += delegate { if (descricaoCartao.Text != "" && descricaoCartao.Text != null) adicionaCartao(Convert.ToString(descricaoCartao.Text)); else this.descricaoCartao.Text = "preencha o nome do cartão!"; };
            btnAdcionaItem.Click += delegate { };
            btnSelecionaCartao.Click += delegate { descricaoCartao.Text = lista.SelectedItem.ToString(); };
            btnValorAtual.Click += delegate { };
        }
        
        private void adicionaCartao(string textoCartao)
        {
            cartoes.Add(new Cartao(textoCartao));
            copiaCartoes();
            atualizaListaCartao(cartoes[cartoes.Count - 1]);

            Toast.MakeText(this, "cartão-- " + this.descricaoCartao.Text + "-- adicionado!", ToastLength.Short).Show();
            descricaoCartao.Text = "";
        }

        private void copiaCartoes()
        {
            foreach (Cartao atual in cartoes)
            {
                cartoesString.Add(atual.nomecartao());
            }
        }
        private void atualizaListaCartao(Cartao cartao)
        {
            listaString.Add(cartao.nomecartao());
            listaString.NotifyDataSetChanged();
            lista.Adapter = listaString;
        }
	}
}


