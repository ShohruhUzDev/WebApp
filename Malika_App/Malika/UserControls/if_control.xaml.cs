using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Malika.UserControls
{
    /// <summary>
    /// Interaction logic for if_control.xaml
    /// </summary>
    public partial class if_control : UserControl
    {


        public string SelectedAtribut { get; set; } = "";
        public string SelectedQiymat { get; set; } = "";
        public if_control()
        {
            InitializeComponent();
        }

        //public void atribut_cbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedAtr();
        //}

        public void SelectedAtr()
        {
            MessageBox.Show( atribut_cbx1.SelectedItem.ToString()!);
        }

        //public void qiymat_cbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    SelectedQiy();
        //}
        public void SelectedQiy()
        {
            MessageBox.Show( qiymat_cbx1.SelectedItem.ToString()!);
        }

    }
}
