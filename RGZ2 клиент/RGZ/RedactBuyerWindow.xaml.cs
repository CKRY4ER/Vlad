using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RGZ
{
    /// <summary>
    /// Логика взаимодействия для RedactBuyerWindow.xaml
    /// </summary>
    public partial class RedactBuyerWindow : Window
    {
        private Buyer _buyer;
        List<State> st;
        public RedactBuyerWindow(Buyer buyer)
        {
            InitializeComponent();
            DeleteSpace(buyer);
            _buyer = buyer;
            DataContext = _buyer;

            st = KRBDEntities.GetContext().State.ToList();
            st[0].BuyerId = buyer.BuyerId;
            KRBDEntities.GetContext().SaveChanges();
        }

        private void DeleteSpace(Buyer buyer)
        {
            buyer.Passport.IssuedByWhom = buyer.Passport.IssuedByWhom.Replace(" ", "");
            buyer.Name = buyer.Name.Replace(" ", "");
            buyer.Surname = buyer.Surname.Replace(" ", "");
            buyer.MiddleName = buyer.MiddleName?.Replace(" ", "");

            buyer.PhoneNumber = buyer.PhoneNumber.Replace(" ", "");
            buyer.CardNumber = buyer.CardNumber?.Replace(" ", "");
        }

        private void SaveChange_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_buyer.Passport.Serial.ToString()))
                errors.AppendLine("Поле \"Cерия пасспорта\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Passport.Number.ToString()))
                errors.AppendLine("Поле \"Номер пасспорта\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Passport.DateOfIssue.ToString()))
                errors.AppendLine("Поле \"Дата выдачи пасспорта\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Passport.IssuedByWhom.ToString()))
                errors.AppendLine("Поле \"Кем выдан пасспорт\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Name.ToString()))
                errors.AppendLine("Поле \"Имя\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Surname.ToString()))
                errors.AppendLine("Поле \"Фамилия\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.Birthday.ToString()))
                errors.AppendLine("Поле \"Дата рождения\" является обязательным");

            if (string.IsNullOrWhiteSpace(_buyer.PhoneNumber.ToString()))
                errors.AppendLine("Поле \"Номер телефона\" является обязательным");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            
            List<Buyer> buyers = KRBDEntities.GetContext().Buyer
                .Where(b => b.Passport.Serial == _buyer.Passport.Serial)
                .Where(b => b.Passport.Number == _buyer.Passport.Number)
                .ToList();

            if (buyers.Count != 0)
            {
                if (_buyer.BuyerId != buyers[0].BuyerId)
                {
                    MessageBox.Show("Не возможно отредактировать. Введенные паспортные данные принадлежат другому человеку!");
                    return;
                }
            }

            try
            {
                KRBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                st[0].BuyerId = 0;
                KRBDEntities.GetContext().SaveChanges();
                this.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            st[0].BuyerId = 0;
            KRBDEntities.GetContext().SaveChanges();
        }
    }
    
}
