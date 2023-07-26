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
using ToDoApiCli.Api;
using ToDoApiCli.Model;
using ToDoApiCli.Client;
using System.ComponentModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class CreatWindow : Window 
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5000 "} ;


        ToDoApi apiInstance {get ;set ;}
        public CreatWindow()
        {
            InitializeComponent();
            apiInstance = new ToDoApi(config) ; 
        }
        private string _description ;
        public string description {get;set ;} ="sample description " ;
        public string id { get ;set ;} = "99";
        public DateTime date {get ;set; }

        public void CreatClick(object sender , RoutedEventArgs e)
        {
            try{
                if(string.IsNullOrEmpty(Id.Text) || string.IsNullOrEmpty(Description.Text) )
                {
                    MessageBox.Show("empty space is not allowed") ; 
                }
                else{
                    if(!apiInstance.ToDoCheckIdGet(Id.Text))
                    {
                        date = arrivalDatePicker.SelectedDate.Value.Date ; 
                        var dummyitem = new Myitem(){Description=Description.Text , DateToDone=date , MyitemId=Id.Text , IsDone=false } ;
                        apiInstance.ToDoPost(dummyitem) ;
                        var w = App.makeobj() ;
                        w.updateUI() ; 
                        MessageBox.Show("new item has been successfully added.") ; 
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}") ;
                this.Close() ;
            }
        }
    }
}