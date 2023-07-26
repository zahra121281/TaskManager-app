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
using Microsoft.AspNetCore.SignalR.Client; 


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5000 "} ; 
        ToDoApi apiInstance {get ;set ;}
        public List<Myitem> myitems { get; set; }
        HubConnection? hubConnection; 

        public MainWindow()
        {
            InitializeComponent();
            apiInstance = new ToDoApi(config) ; 
            hubConnection = new HubConnectionBuilder() 
            .WithUrl("http://localhost:5000/HubServer") 
            .Build();
            myitems = new List<Myitem>(); 
            myitems = apiInstance.ToDoGet(); 
            List_view.ItemsSource = myitems;
            hubConnection.StartAsync();
            hubConnection.On("Notify", (Action)(() => this.Dispatcher.BeginInvoke( () =>
            {
                myitems = apiInstance.ToDoGet() ;  
                 List_view.ItemsSource = myitems;
            })));
        }

        public void DeleteItem(object sender , RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(id.Text) )
                {
                    MessageBox.Show("Id filed could not be null!!") ; 
                    return ; 
                }
                else{
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            apiInstance.ToDoItemidDelete(id.Text) ;
                            hubConnection.SendAsync("HubServer") ;  
                        }
                }
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show($"{ex.Message}") ;
                return ; 
            }
        }

        public void EditItem(object sender , RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(id.Text) )
                {
                    MessageBox.Show("Id filed could not be null!!") ; 
                    return ; 
                }
            else{
                var item = apiInstance.ToDoTidGet(id.Text) ; 
                Window editwindow = new EditWindow(id.Text , item.IsDone ) ; 
                editwindow.Show() ; 
            }
        }
        public void TodayItme(object sender , RoutedEventArgs e)
        {
            Window todayitemsWindow = new TodaysWindow() ; 
            todayitemsWindow.Show() ; 
        }
        public void AddItem(object sender , RoutedEventArgs e)
        {
            Window CreatWindow = new CreatWindow() ; 
            CreatWindow.Show() ; 
        }


        public async void updateUI()
        {
            if(hubConnection is not null)
            {
               await hubConnection.SendAsync("HubServer") ; 
            }
            else{
                await hubConnection.StartAsync(); 
                updateUI();
            }
        }
        public void MakeDone(object sender , RoutedEventArgs e)
        {
            try{
                if(string.IsNullOrEmpty(idE.Text))
                {
                    MessageBox.Show("Id filed could not be null!!") ; 
                    return ; 
                }
                else
                {
                    var dummyitem = new Myitem(){Description="sds" , MyitemId=idE.Text , IsDone=true , DateToDone=DateTime.Now } ;
                    apiInstance.ToDoMakeDonePost(dummyitem) ; 
                    hubConnection.SendAsync("HubServer") ;  
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}") ;
                return ; 
            }
        }

    }
}
