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
    public partial class Equipe : PhoneApplicationPage
    {
        public Equipe()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            TxtDes.Text = "DESENVOLVEDOR";
            TxtBruno.Text = "Bruno Marques";
            TxtApoio.Text = "Apoio";
            TxtApoio1.Text = "Cássio Huggentobler";
            TxtApoio2.Text = "Mauricio Buzata";
            TxtApoio3.Text = "Simoni Pires";

        }

        

        





    }
}