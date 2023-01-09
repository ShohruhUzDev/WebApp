using Malika.UserControls;
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
using System.Windows.Shapes;

namespace Malika.Views
{
    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {

        public List<string> Atributs { get; set; }=new List<string>();  
        public List<string> Qiymats { get; set; }=new List<string>();   
        public Export()
        {
            InitializeComponent();
        }

        private void atribut_add_btn_Click(object sender, RoutedEventArgs e)
        {
            atributlar_lstbx.Items.Add(atribut_txt.Text);
            Atributs.Add(atribut_txt.Text);
          //  atributlar_lstbx.ItemsSource = Atributs;
            atribut_txt.Clear();
        }

        private void qiymat_add_btn_Click(object sender, RoutedEventArgs e)
        {
            qiymatlar_lstbx.Items.Add(qiymat_txt.Text);
            Qiymats.Add(qiymat_txt.Text);
           // qiymatlar_lstbx.ItemsSource= Qiymats;
            qiymat_txt.Clear();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if_control if_Control = new if_control();
            oyna.Children.Add(if_Control);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
                 if(qiymatlar_lstbx.SelectedIndex!=-1)
            {
                
                Qiymats.Remove(qiymatlar_lstbx.SelectedItem.ToString()!);
                qiymatlar_lstbx.Items.Clear();

                foreach(var i in Qiymats)
                {
                    qiymatlar_lstbx.Items.Add(i);
                }
            }
            if (atributlar_lstbx.SelectedIndex != -1)
            {
               
                Atributs.Remove(atributlar_lstbx.SelectedItem.ToString()!);
                
                atributlar_lstbx.Items.Clear();
                foreach (var i in Atributs)
                {
                    atributlar_lstbx.Items.Add(i);
                }

            }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
