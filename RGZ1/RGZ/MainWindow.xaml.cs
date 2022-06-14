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

namespace RGZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BuyerGrid.ItemsSource = KRBDEntities.GetContext().Buyer.ToList();
        }

        private void UpdateBuyerGrid_Click(object sender, RoutedEventArgs e)
        {
            KRBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            BuyerGrid.ItemsSource = KRBDEntities.GetContext().Buyer.ToList();
        }

        private void AddBuyerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuyerGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Buyer buyer = BuyerGrid.SelectedItem as Buyer;

            List<State> st = KRBDEntities.GetContext().State.ToList();

            if (st[0].BuyerId == buyer.BuyerId)
            {
                MessageBox.Show("Не возможно отредактировать. Данную строку редактирует другой пользователь");
                return;
            }

            new RedactBuyerWindow(buyer).Show();
        }

        private void DeleteBuyer_Click(object sender, RoutedEventArgs e)
        {
            Buyer buyer = BuyerGrid.SelectedItem as Buyer;
            if (buyer == null)
                return;

            List<State> st = KRBDEntities.GetContext().State.ToList();

            if (st[0].BuyerId == buyer.BuyerId)
            {
                MessageBox.Show("Не возможно удалить. Данную строку редактирует другой пользователь");
                return;
            }

            KRBDEntities.GetContext().Buyer.Remove(buyer);
            KRBDEntities.GetContext().SaveChanges();
        }
    }
}
