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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TodaysWindow : Window
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5000 "} ; 
        ToDoApi apiInstance {get ;set ;}
        public List<Myitem> myitems { get; set; }
        public TodaysWindow()
        {
            InitializeComponent();
            apiInstance = new ToDoApi(config) ; 
            myitems = new List<Myitem>(); 
            myitems = apiInstance.ToDoTodayItemsGet() ; 
            List_view.ItemsSource = myitems;
        }
    }
}
