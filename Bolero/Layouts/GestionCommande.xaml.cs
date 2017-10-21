using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Bolero
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class GestionCommande : Window, INotifyPropertyChanged
    {
        public GestionCommande()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblDate.Content = DateTime.Now.ToShortDateString();
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblHeure.Content = DateTime.Now.ToLongTimeString();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            Layouts.ModifierCommande modi = new Layouts.ModifierCommande();
            modi.ShowDialog();
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {

        }

        // Search ********************************************************************
         private static DependencyProperty SearchTextProperty =
                                                    DependencyProperty.Register("SearchText", typeof(string), typeof(GestionCommande),
                                                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                                                                                         FrameworkPropertyMetadataOptions.Inherits));

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set 
            {
                SetValue(SearchTextProperty, value);
            }
        }


        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var t = (TextBox)sender;
            t.SelectAll();
        }

        private void SearchTextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            var t = (TextBox)sender;
            t.SelectAll();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            OnSearchEvent();
        }

        public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent(
             "Search", // Event name
              RoutingStrategy.Bubble, // Bubble means the event will bubble up through the tree
              typeof(RoutedEventHandler), // The event type
                 typeof(GestionCommande)
                 ); // Belongs to ChildControlBase

        // Allows add and remove of event handlers to handle the custom event
        public event RoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.Equals(Key.Enter))
            {
                OnSearchEvent();
            } 
        }

        private void OnSearchEvent()
        {
            SearchText = SearchTextBox.Text;
            var newEventArgs = new RoutedEventArgs(GestionCommande.SearchEvent);
            RaiseEvent(newEventArgs);
        }

        // Search ********************************************************************


    }
}