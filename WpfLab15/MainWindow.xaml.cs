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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Markup;
using System.Net.Security;

namespace WpfLab15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // не забыть подключить using System.Diagnostics;using System.Windows.Navigation;

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
                using (FileStream fs = File.Open("1.xaml", FileMode.OpenOrCreate))
                {

                    docViewer.Document = XamlReader.Load(fs) as FlowDocument;//Исключение, если сначала очистить, затем сохранить, а затем попробовать загрузить. (без сохранения очищенного docViewer работает) 

                }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                using (FileStream fs = File.Open("1.xaml", FileMode.Create))
                {
                    if (docViewer.Document != null)
                    {
                        XamlWriter.Save(docViewer.Document, fs);
                    }
                }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                docViewer.ClearValue(FlowDocumentReader.DocumentProperty);
                       
        }
    }
}
