using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace ColaFacil
{
    public partial class Info : PhoneApplicationPage
    {
        public Info()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            TxtInfo1.Text = "Com este App o usuário poderá adicionar, alterar, remover e acessar suas informações, seguindo  a ordem: matéria, prova e perguntas.";
            TxtInfo.Text = "Abaixo segue os principais comandos :";
            TxtAdd.Text = "Adiciona novo item;";
            TxtEdit.Text = "Após selecionar item, é editado;";
            TxtDelete.Text = "Após selecionar item, é excluido;";
            TxtCheck.Text = "Após selecionar item, é acessado;";
            TxtRefresh.Text = "Recarrega a pagina;";
            TxtHelp.Text = "Informações do App;";
            TxtAvalia.Text = "Avalia o App;";
            TxtEquip.Text = "Equipe.";

        }

        

        





    }
}