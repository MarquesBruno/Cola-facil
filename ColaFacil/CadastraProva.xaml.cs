using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ColaFacil.Entidades;
using ColaFacil.Repositorio;

namespace ColaFacil
{
    public partial class CadastraProva : PhoneApplicationPage
    {
        public Prova prov { get; set; }

        private int IdMateria = 0;
        
        public CadastraProva()
        {
            InitializeComponent();
            
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);            
            //Carrega Prova
            CadastraProva page = e.Content as CadastraProva;
            
            if (prov != null)
            {
                
                TxtIdProva.Text = prov.IdProva.ToString();
                TxtNomeProva.Text = prov.NomeProva;

                TxtIdProva.IsEnabled = false;
            }

        }








        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Carrega Prova
            string IdMateriaParametro = "";


            //if (prov != null)
            if(NavigationContext.QueryString.TryGetValue("IdMateria", out IdMateriaParametro))
            {
                TxtIdMateria.Text = IdMateriaParametro;
                
                    
                

                TituloPage.Text = "Add Prova" ;
            }
            if (prov != null)
            {
                TituloPage.Text = "Edit Prova";
                TxtIdProva.Text = prov.IdProva.ToString();
                TxtNomeProva.Text = prov.NomeProva;

                TxtIdProva.IsEnabled = false;
            }

            

        }

        #region Eventos
        
        
        private void appBarSaveProva_Click(object sender, EventArgs e)
        {
            if (TxtNomeProva.Text == string.Empty)
            {
                MessageBox.Show(" O Assunto da Prova deve ser informado");
                return;
            }

            if (prov != null)
            {
                
                prov.IdMateria = int.Parse(TxtIdMateria.Text);
                prov.IdProva = int.Parse(TxtIdProva.Text);
                prov.NomeProva = TxtNomeProva.Text;
                ProvaRepositorio.Update(prov);
                MessageBox.Show("Dados Alterado com Suceso");
            }
            else
            {
                Prova provinha = new Prova
                {
                    IdMateria = int.Parse(TxtIdMateria.Text),
                    IdProva = int.Parse(TxtIdProva.Text),
                    NomeProva = TxtNomeProva.Text
                };
                ProvaRepositorio.Create(provinha);
                MessageBox.Show(("Prova cadastrada com  Sucesso"));
            }

            NavigationService.GoBack();

        }

















        
        
        #endregion
    }
}