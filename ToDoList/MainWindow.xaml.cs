using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
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


namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool areButtonsEnabled = true;
      
        public MainWindow()
        {
            InitializeComponent();
            TextBlock empty_space = new TextBlock();
            empty_space.Text = "";
            List.Children.Add(empty_space);
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            string todo = Input.Text;

            if(!string.IsNullOrEmpty(todo))
            {
                TextBlock todo_item = new TextBlock();
                todo_item.Text = "    - " + todo;
                todo_item.Margin = new Thickness(5);
                todo_item.Foreground = new SolidColorBrush(Colors.Blue);
                todo_item.FontFamily = new FontFamily("Papyrus");
                todo_item.FontSize = 16;
                List.Children.Add(todo_item);
                Input.Clear();
            }

        }

        private async void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (List.Children.Count > 1 && List.Children[1] is TextBlock textBlock) 
            {
                Button deleteButton = (Button)sender;
                deleteButton.IsEnabled = false;

                textBlock.TextDecorations = TextDecorations.Strikethrough;
                InvalidateVisual();

                await Task.Delay(1000);

                List.Children.RemoveAt(1);
                deleteButton.IsEnabled = true;
            }
        }
    }
}
