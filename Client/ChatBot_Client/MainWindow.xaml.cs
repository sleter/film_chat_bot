using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ChatBot_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<string> messages = new ObservableCollection<string>();

        public MainWindow()
        {
            DataContext = messages;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Text != String.Empty)
            {
                messages.Add($"You: {MessageBox.Text}");
                MessageBox.Text = String.Empty;
            }
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && MessageBox.Text != String.Empty)
            {
                messages.Add($"You: {MessageBox.Text}");
                MessageBox.Text = String.Empty;
            }
        }
    }
}
