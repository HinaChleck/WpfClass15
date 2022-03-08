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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XpsDocument doc = new XpsDocument("1.xps", FileAccess.Write);
            XpsDocumentWriter writer=XpsDocument.CreateXpsDocumentWriter(doc);
            writer.Write(docViewer.Document as FixedDocument);
            doc.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XpsDocument doc = new XpsDocument("2.xps", FileAccess.Read);
            docViewer.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }


    }
}
