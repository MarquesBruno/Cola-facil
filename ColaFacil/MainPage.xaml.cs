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
    public partial class MainPage : PhoneApplicationPage
    {
        Materia materia;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        #region Métodos
        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void Refresh()
        {
            List<Materia> disciplinas = Repositorio.MateriaRepositorio.Get();
            LstMateria.ItemsSource = disciplinas;

        }





        #endregion

        #region Eventos
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void appBarNew_Click(object sender, EventArgs e)
        {
            materia = null;            
            Navigate("/CadastraMateria.xaml");

        }

        private void appBarEdit_Click(object sender, EventArgs e)
        {
            if (materia != null)
            {
                Navigate("/CadastraMateria.xaml");
            }
            else
            {
                if (MessageBox.Show("Selecione uma matéria para Editar")
                    == MessageBoxResult.OK)
                { }
            }  

            
            
            
                        
        }

        private void appBarDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Excluir Materia " + materia.NomeMateria + "?") == MessageBoxResult.OK)
                {
                MateriaRepositorio.Delete(materia);
                Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma matéria para excluir");
                return;
            }

            
            

        }

        private void appBarCheck_click(object sender, EventArgs e)
        {
            try
            {
                Navigate("/ListaProvas.xaml?IdMateria=" + materia.IdMateria);
            }catch
            {
                MessageBox.Show("Selecione uma matéria para acessar");
                return;
            }
            
        }

        //private void Button_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        //{
            
       // }
        private void appBarListaProva_Click(object sender, RoutedEventArgs e)
        {
            
            //Desativado por inguanto apagar depois caso seja necessario



            //NavigationService.Navigate(new Uri("/ProvaRepositorio.cs?msg=" + mat.IdMateria, UriKind.Relative));
            Navigate("/ListaProvas.xaml?IdMateria=" + materia.IdMateria);
            //Navigate("/ListaProvas.xaml");


        }

        #endregion






        private void onSelecionChange(object sender, SelectionChangedEventArgs e)
        {
            materia = (sender as ListBox).SelectedItem as Materia;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            CadastraMateria page = e.Content as CadastraMateria;
            if (page != null)
                page.mat = materia;
        }

        private void appBarAbout_click(object sender, EventArgs e)
        {
            
            Navigate("/Sobre.xaml");
            
        }

        
      


        
        #region Comentarios

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        #endregion

    }
}