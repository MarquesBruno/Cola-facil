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
    public partial class CadastraMateria : PhoneApplicationPage
    {
        public Materia mat { get; set; }
        public CadastraMateria()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            //Carrega Materia
            CadastraMateria page = e.Content as CadastraMateria;

            if (mat != null)
            {
                
                TxtId.Text = mat.IdMateria.ToString();
                TxtNomeMat.Text = mat.NomeMateria;
                TxtNomeprof.Text = mat.NomeProf;

                TxtId.IsEnabled = false;
                
              
            }

        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Carregar Materia
            
            if (mat != null)
            {
                /*try {*/
                TxtTitulo.Text = "Edit Matéria";

                TxtId.Text = mat.IdMateria.ToString();
                TxtNomeMat.Text = mat.NomeMateria;
                TxtNomeprof.Text = mat.NomeProf.ToString();

                TxtId.IsEnabled = false;
               /* }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Selecione uma matéria para Editar");
                    NavigationService.GoBack();
                }*/
            }
        }



        private void appBarSave_Click(object sender, EventArgs e)
        {            

            if (TxtNomeMat.Text == string.Empty)
            {
                MessageBox.Show(" O Nome da matéria deve ser informado");
                return;
            }

            if (TxtNomeprof.Text == string.Empty)
            {
                MessageBox.Show(" O Nome do Professor deve ser informado");
                return;
            }
            
            if (mat != null)
            {
                mat.IdMateria = int.Parse(TxtId.Text);
                mat.NomeMateria = TxtNomeMat.Text;
                mat.NomeProf = TxtNomeprof.Text;


                    //TxtTitulo.Text = "Editar Materia";
                    
                    //Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                    //NavigationService.Navigate(caminho);


               MateriaRepositorio.Update(mat);
               MessageBox.Show("Dados Alterados com sucesso.");
                }
            
            

            if (mat==null)
            {
                Materia disciplina = new Materia
                {
                    IdMateria = int.Parse(TxtId.Text),
                    NomeMateria = TxtNomeMat.Text,
                    NomeProf = TxtNomeprof.Text

                };
               // Uri caminho = new Uri("/ProvaRepositorio.cs?parametro=" + TxtId.Text, UriKind.RelativeOrAbsolute); 
                MateriaRepositorio.Create(disciplina);
                MessageBox.Show("Materia Cadastrada com Sucesso.");
            }

            NavigationService.GoBack();

        }

        
    }
}