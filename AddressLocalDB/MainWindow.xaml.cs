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

namespace AddressLocalDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AddressDBDataSet addressDBDataSet;
        private AddressDBDataSetTableAdapters.AddressTableAdapter addressDBDataSetAddressTableAdapter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            addressDBDataSet = ((AddressLocalDB.AddressDBDataSet)(this.FindResource("addressDBDataSet")));
            // Load data into the table Address. You can modify this code as needed.
            addressDBDataSetAddressTableAdapter = new AddressLocalDB.AddressDBDataSetTableAdapters.AddressTableAdapter();
            addressDBDataSetAddressTableAdapter.Fill(addressDBDataSet.Address);
            System.Windows.Data.CollectionViewSource addressViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("addressViewSource")));
            addressViewSource.View.MoveCurrentToFirst();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            addressDBDataSetAddressTableAdapter.Update(addressDBDataSet.Address);
        }
    }
}
