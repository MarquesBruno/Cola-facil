using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ColaFacil.Resources;
using ColaFacil.Entidades;
using ColaFacil.Repositorio;

namespace ColaFacil
{
    public partial class ListaProvas : PhoneApplicationPage
    {
        Prova prova;
        private int IdMateria = 0;

        public ListaProvas()
        {
            InitializeComponent();
        }
        #region Métodos
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void RefreshProva()
        {
            List<Prova> provinha = Repositorio.ProvaRepositorio.Get(IdMateria);
            LstProva.ItemsSource = provinha;
        }




        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            prova = (sender as ListBox).SelectedItem as Prova;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastraProva page = e.Content as CadastraProva;
            if (page != null)
                page.prov = prova;
        }



        #endregion

        #region Eventos
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string IdMateriaParametro = "";

            if (NavigationContext.QueryString.TryGetValue("IdMateria", out IdMateriaParametro))
            {
                IdMateria = int.Parse(IdMateriaParametro);
                ProvaRepositorio.Get(IdMateria);
            }
            RefreshProva();
        }        
        
        private void appBarNewProva_Click(object sender, EventArgs e)
        {
            //prova = null;
            //Navigate("/CadastraProva.xaml");
            NavigationService.Navigate(new Uri("/CadastraProva.xaml?IdMateria=" + IdMateria, UriKind.Relative));
        }



        private void appBarEditProva_Click(object sender, EventArgs e)
        {

            if (prova != null)
            {
                NavigationService.Navigate(new Uri("/CadastraProva.xaml?IdMateria=" + IdMateria, UriKind.Relative));
            }
            else
            {
                if (MessageBox.Show("Selecione uma matéria para Editar")
                    == MessageBoxResult.OK)
                { }
            }
        }





        private void appBarDeleteProva_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir Prova " + prova.NomeProva + "?") == MessageBoxResult.OK)
                {
                    ProvaRepositorio.Delete(prova);
                    RefreshProva();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma Prova para excluir");
                return; ;
            }         


        }

        private void appBarCheckProva_click(object sender, EventArgs e)
        {
            try
            {
                Navigate("/ListaPerguntas.xaml?IdProva=" + prova.IdProva);
            }
            catch
            {
                MessageBox.Show("Selecione uma prova para acessar");
                return;
            }
        }

        
        
        #endregion

        private void appBarAbout_click(object sender, EventArgs e)
        {
            Navigate("/Sobre.xaml");
        }

        

        
    }
}