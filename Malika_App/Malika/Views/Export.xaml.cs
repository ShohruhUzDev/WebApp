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
using System.Xml.Linq;

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
         
            atribut_txt.Clear();
        }

        private void qiymat_add_btn_Click(object sender, RoutedEventArgs e)
        {
            qiymatlar_lstbx.Items.Add(qiymat_txt.Text);
            Qiymats.Add(qiymat_txt.Text);
           
            qiymat_txt.Clear();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
           




            try
            {

                if_control if_Control = new if_control();


                if_Control.qiymat_cbx1.SelectionChanged +=new SelectionChangedEventHandler(OnQiymatSelected);
              
                if_Control.atribut_cbx1.SelectionChanged+=new SelectionChangedEventHandler(OnAtributSelected);
             
                oyna.Children.Add(if_Control);

                //if(first_selected)
                //{
                //    Qiymats.Remove(if_Control.SelectedQiymat);
                //    Atributs.Remove(if_Control.SelectedAtribut);

                //}





                foreach (var i in Atributs)
                {
                   
                        if_Control.atribut_cbx1.Items.Add(i);
                    
                }
                foreach (var i in Qiymats)
                {
                   
                        if_Control.qiymat_cbx1.Items.Add(i);
                    
                }



            }
           
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        public void OnAtributSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Atributs.Remove(comboBox.SelectedItem.ToString()!);

        }
        public void OnQiymatSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Qiymats.Remove(comboBox.SelectedItem.ToString()!);

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


            foreach( var i  in Atributs)
            {
                atribut_cbx.Items.Add(i);
            }

            foreach (var i in Qiymats)
            {
                qiymat_cbx.Items.Add(i);
            }
        }

        private void atribut_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Atributs.Remove(atribut_cbx.SelectedItem.ToString()!);
           
        }

        private void qiymat_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Qiymats.Remove(qiymat_cbx.SelectedItem.ToString()!); 
            
        }
    }
}
