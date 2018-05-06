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
        readonly ObservableCollection<Message> _messages = new ObservableCollection<Message>();

        public MainWindow()
        {
            DataContext = _messages;
            InitializeComponent();
            _messages.Add(new Message(){MessageText = "Hello",Sended = "No"});
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Text != string.Empty)
            {
                AddToMessages(new Message() { MessageText = MessageBox.Text, Sended = "False" });
            }
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && MessageBox.Text != string.Empty)
            {
                AddToMessages(new Message() { MessageText = MessageBox.Text, Sended = "True" });
            }
        }

        private void AddToMessages(Message message)
        {
            _messages.Add(message);
            MessageBox.Text = string.Empty;
            int lastMessageIndex = MessagesListBox.Items.Count - 1;
            MessagesListBox.ScrollIntoView(MessagesListBox.Items[lastMessageIndex]);
        }
    }
}
