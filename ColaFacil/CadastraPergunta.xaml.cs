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
    public partial class CadastraPergunta : PhoneApplicationPage
    {
        public Pergunta perg { get; set; }

        private int IdProva = 0;
        
        public CadastraPergunta()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            //Carrega Pergunta
            CadastraPergunta page = e.Content as CadastraPergunta;

            if (perg != null)
            {
                
                TxtIdPergunta.Text = perg.IdPergunta.ToString();
                TxtNomePergunta.Text = perg.NomePergunta;
                TxtResposta.Text = perg.Resposta;

                TxtIdPergunta.IsEnabled = false;
            }

        }








        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Carrega Prova
            string IdProvaParametro = "";


            //if (prov != null)
            if(NavigationContext.QueryString.TryGetValue("IdProva", out IdProvaParametro))
            {
                TxtIdProva.Text = IdProvaParametro;


                TituloPage.Text = "Add Pergunta";
            }
            if (perg != null)
            {
                TituloPage.Text = "Edit Pergunta";
                TxtIdPergunta.Text = perg.IdPergunta.ToString();
                TxtNomePergunta.Text = perg.NomePergunta;
                TxtResposta.Text = perg.Resposta;

                TxtIdPergunta.IsEnabled = false;
            }



        }

        #region Eventos
        
        
        private void appBarSavePergunta_Click(object sender, EventArgs e)
        {
            if (TxtNomePergunta.Text == string.Empty)
            {
                MessageBox.Show(" A Pergunta deve ser informada");
                return;
            }
            if (TxtResposta.Text == string.Empty)
            {
                MessageBox.Show(" A Resposta deve ser informada");
                return;
            }

            if (perg != null)
            {
                perg.IdProva = int.Parse(TxtIdProva.Text);
                perg.IdPergunta = int.Parse(TxtIdPergunta.Text);
                perg.NomePergunta = TxtNomePergunta.Text;
                perg.Resposta = TxtResposta.Text;
                
                PerguntaRepositorio.Update(perg);
                MessageBox.Show("Dados Alterado com Suceso");
            }
            else
            {
                Pergunta perguntinha = new Pergunta
                {
                    IdProva = int.Parse(TxtIdProva.Text),
                    IdPergunta = int.Parse(TxtIdPergunta.Text),
                    NomePergunta = TxtNomePergunta.Text,
                    Resposta = TxtResposta.Text
                };
                PerguntaRepositorio.Create(perguntinha);
                MessageBox.Show(("Pergunta e Resposta cadastradas com  Sucesso"));
            }

            NavigationService.GoBack();

        }

















        
        
        #endregion
    }
}