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
    public partial class ListaPerguntas : PhoneApplicationPage
    {
        Pergunta pergunta;
        private int IdProva = 0;

        public ListaPerguntas()
        {
            InitializeComponent();
        }
        #region Métodos
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void RefreshPergunta()
        {
            List<Pergunta> perguntinha = Repositorio.PerguntaRepositorio.Get(IdProva);
            LstPergunta.ItemsSource = perguntinha;
        }




        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            pergunta = (sender as ListBox).SelectedItem as Pergunta;
        }
        
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastraPergunta page = e.Content as CadastraPergunta;
            if (page != null)
                page.perg = pergunta;
        }



        #endregion

        #region Eventos
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string IdProvaParametro = "";

            if (NavigationContext.QueryString.TryGetValue("IdProva", out IdProvaParametro))
            {
                IdProva = int.Parse(IdProvaParametro);
                PerguntaRepositorio.Get(IdProva);
            }
            RefreshPergunta();
        }        
        
        private void appBarNewPergunta_Click(object sender, EventArgs e)
        {
            //prova = null;
            //Navigate("/CadastraProva.xaml");
            NavigationService.Navigate(new Uri("/CadastraPergunta.xaml?IdProva=" + IdProva, UriKind.Relative));
        }




        private void appBarEditPergunta_Click(object sender, EventArgs e)
        {
            
            if (pergunta != null)
            {
                NavigationService.Navigate(new Uri("/CadastraPergunta.xaml?IdProva=" + IdProva, UriKind.Relative));
            }
            else
            {
                if (MessageBox.Show("Selecione uma matéria para Editar")
                    == MessageBoxResult.OK)
                { }
            }
        }








        private void appBarDeletePergunta_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir Pergunta " + pergunta.NomePergunta + "?") == MessageBoxResult.OK)
                {
                    PerguntaRepositorio.Delete(pergunta);
                    RefreshPergunta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma Pergunta para excluir");
                return; 
            }         


        }

        private void appBarRefreshPergunta_click(object sender, EventArgs e)
        {
            RefreshPergunta();
        }

        
        
        #endregion

        private void appBarAbout_click(object sender, EventArgs e)
        {
            Navigate("/Sobre.xaml");
        }

   

        
    }
}