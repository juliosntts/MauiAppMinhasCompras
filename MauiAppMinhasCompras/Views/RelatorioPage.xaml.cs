using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Helpers;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public RelatorioPage()
        {
            InitializeComponent();
            DataInicio = DateTime.Now.AddMonths(-1); 
            DataFim = DateTime.Now; 
            dp_inicio.Date = DataInicio;
            dp_fim.Date = DataFim;
        }

        private async void OnFiltrarComprasClicked(object sender, EventArgs e)
        {
            try
            {

                DateTime dataInicio = dp_inicio.Date;
                DateTime dataFim = dp_fim.Date;

                if (dataInicio > dataFim)
                {
                    await DisplayAlert("Erro", "A data de início não pode ser maior que a data de fim.", "OK");
                    return;
                }

                var produtosFiltrados = await App.Db.GetAll();
                var produtosNoIntervalo = produtosFiltrados
                    .Where(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFim)
                    .ToList();

                lv_produtos.ItemsSource = produtosNoIntervalo;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }
    }
}
