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

    public partial class EditWindow : Window
    {
        DateTime newDate {get ;set ;}
        Configuration config = new Configuration() {BasePath = "http://localhost:5000 "} ; 
        ToDoApi apiInstance {get ;set ;}
        Myitem dummyitem {get ;set ;}
    
        public EditWindow(string id , bool isdone)
        {
            InitializeComponent();
            apiInstance = new ToDoApi(config) ; 
            newDate = new DateTime() ; 
            dummyitem = new Myitem() ;
            dummyitem.MyitemId = id ;  
            dummyitem.IsDone = isdone ; 
        }
            
        public string description {get ;set ;} = "sample description" ;

        private bool VerifyDateIsFuture(DateTimeOffset date)
        {
            if (date > DateTimeOffset.Now)
            {
                return true;
            }
            return false;
        }
        public void Editbtn(object sender , RoutedEventArgs e )
        {
            try{
                if( !VerifyDateIsFuture(arrivalDatePicker.SelectedDate.Value.Date) || string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show("please fill all the fields") ; 
                    return ; 
                }
                else{
                    dummyitem.Description = desc.Text ;
                    dummyitem.DateToDone = arrivalDatePicker.SelectedDate.Value.Date ;
                    apiInstance.ToDoUpdatePost(dummyitem) ; 
                    var w = App.makeobj() ;
                    w.updateUI() ; 
                    MessageBox.Show("item has been updated successfully!!") ;   
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
