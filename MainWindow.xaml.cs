/* #############################
 * 
 * Author: Johnathon Mc Grory
 * Date : 1/05/2020
 * Description : C# Code for Object Orientated Development for Final End Of Year Project 
 * 
 * ############################# */

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
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Globalization;

namespace last_time
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //section is a static used to partition the different types of drinks. There are nine sections, just as their are nine different drink buttons
        //and nine different sets of results in the first listbox
        static string type;
        //a set of drinks selected in the first listbox
        List<Drinks> selectedDrinks = new List<Drinks>();
        List<Drinks> selectedDrinks1 = new List<Drinks>();
        List<Drinks> selectedDrinks2 = new List<Drinks>();

        //database connection
        DrinksModelContainer db = new DrinksModelContainer();
        //static variable to determine whether a user is logged in or not
        bool loginState;
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //when the window first loads the user has not yet logged in so loginState is set to false
            loginState = false;
        }

        //these buttons define what type of drinks are displayed on the left listbox
        #region  Drink Type Buttons

        private void MineralsButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Minerals"
            var query = from m in db.Drinks
                        where m.Type == "Minerals"
                        select m;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Minerals";
        }

        private void DraughtButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Draught"
            var query = from dr in db.Drinks
                        where dr.Type == "Draught"
                        select dr;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Draught";
        }

        private void WinesButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Wines"
            var query = from w in db.Drinks
                        where w.Type == "Wines"
                        select w;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Wines";
        }

        private void TeasAndCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Teas and Coffees"
            var query = from t in db.Drinks
                        where t.Type == "Teas and Coffees"
                        select t;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Teas and Coffees";
        }

        private void Bottled_BeerButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Bottled Beer"
            var query = from bb in db.Drinks
                        where bb.Type == "Bottled Beer"
                        select bb;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Bottled Beer";
        }

        private void GinsButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of " Gins"

            var query = from g in db.Drinks
                        where g.Type == "Gins"
                        select g;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Gins";
        }

        private void VodkasButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Vodkas"

            var query = from v in db.Drinks
                        where v.Type == "Vodkas"
                        select v;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Vodkas";
        }

        private void WhiskeysButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Whiskeys"
            var query = from wh in db.Drinks
                        where wh.Type == "Whiskeys"
                        select wh;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Whiskeys";
        }

        private void ShotsButton_Click(object sender, RoutedEventArgs e)
        {
            //displays all the drinks with the string property type of "Shots"
            var query = from s in db.Drinks
                        where s.Type == "Shots"
                        select s;

            lbxSelector.ItemsSource = null;
            lbxSelector.ItemsSource = query.ToList();

            lbxSelector1.ItemsSource = null;
            lbxSelector1.ItemsSource = query.ToList();

            //defines the type of drink
            type = "Shots";
        }

        #endregion Drink Type Buttons

        //left-click with your mouse to remove whatever item is currently selected from the listbox on the right (lbxCashier)
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //check to make sure that the list is not empty
            bool isEmpty = !selectedDrinks.Any();
            if (isEmpty)
            {
                // error message
                MessageBox.Show("There is nothing to remove!");
            }
            else
            {
                if (lbxCashier.SelectedItem != null)
                {
                    //stores the index of selected item, removes the item from the list at that index, recalculates the total, refreshes the listbox
                    int index = lbxCashier.SelectedIndex;
                    selectedDrinks.RemoveAt(index);
                    decimal cost = CalculateTotal();
                    CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                    tblkTotal.Text = string.Format(currentCulture, "{0:C2}", cost);
                    lbxCashier.ItemsSource = selectedDrinks.ToList();

                }
                else
                {
                    //error message when nothing is selected
                    MessageBox.Show("Nothing was selected!");
                }
            }
        }
        //right-click with mouse to remove everthing from the listbox on the right (lbxCashier)
        private void RemoveAll(object sender, MouseButtonEventArgs e)
        {
            //check to make sure that the list is not empty
            bool isEmpty = !selectedDrinks.Any();
            if (isEmpty)
            {
                // error message
                MessageBox.Show("There is nothing to remove!");
            }
            else
            {
                selectedDrinks.Clear();
                lbxCashier.ItemsSource = null;
                decimal cost = CalculateTotal();
                CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                tblkTotal.Text = string.Format(currentCulture, "{0:C2}", cost);
            }    
        }

        //cashes off the cashier if cost < €10 || throws an error messag if cost > €10
        private void TenEuroCashButton_Click(object sender, RoutedEventArgs e)
        {
            CheckStock();
            decimal cost = CalculateTotal();
            UpdateStock();
            if (cost <= 10 && cost > 0)
            {
                CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                tblkChangeDue.Text = String.Format(currentCulture, "{0:C2}", 10 - cost);
                selectedDrinks.Clear();
                lbxCashier.ItemsSource = selectedDrinks;
            }
            else if (cost > 10)
            {
                MessageBox.Show("Insuffient note!!");
            }
            else
            {
                MessageBox.Show("Nothing was selected!!");
            }
        }

        private void CheckStock()
        {
            
            //check if enough of certain product in stock
            
            
            bool enoughStock = true;
            foreach (var drink in selectedDrinks)
            {
                using (var db = new DrinksModelContainer())
                {
                    List<Drinks> tempList = new List<Drinks>();
                    foreach (var row in selectedDrinks)
                    {
                        tempList.Add(row);
                    }

                    foreach (var item in tempList)
                    {
                        var query = from s in db.Drinks
                                    where s.Id == item.Id
                                    select s;

                        int selectedDrinkCount = query.Count();
                        foreach (Drinks q in query)
                        {
                            int internalSelectedDrinksCount = 0;
                            selectedDrinkCount = selectedDrinkCount + internalSelectedDrinksCount;
                            if (q.Stock - selectedDrinkCount >= 0 )
                            {
                                enoughStock = true;
                                internalSelectedDrinksCount++;

                            }
                            else if (q.Stock == null)
                            {
                                continue;
                            }
                            else if (q.Stock - selectedDrinkCount < 0)
                            {
                                enoughStock = false;
                                break;
                            }
                        }

                    }
                }

            }
            if (enoughStock == false)
            {
                MessageBox.Show("Not enough stock for this transaction");
            }
        }

        //cashes off the cashier if cost < €20 || throws an error message if cost > €20 || throws an error if nothing was selected before the button was clicked
        //calls the method that will update the stock of items that were sold
        private void TwentyEuroCashButton_Click(object sender, RoutedEventArgs e)
        {
            CheckStock();
            decimal cost = CalculateTotal();
            UpdateStock();
            if (cost <= 20 && cost > 0)
            {
                CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                tblkChangeDue.Text = String.Format(currentCulture, "{0:C2}", 20 - cost);
                selectedDrinks.Clear();
                lbxCashier.ItemsSource = selectedDrinks;
            }
            else if (cost > 20)
            {
                MessageBox.Show("Insuffient note!!");
            }
            else
            {
                MessageBox.Show("Nothing was selected!!");
            }
        }

        //cashes off the cashier if cost < €50 || throws an error messag if cost > €50 || throws an error if nothing was selected before the button was clicked
        //calls the method that will update the stock of items that were sold
        private void FiftyEuroCashButton_Click(object sender, RoutedEventArgs e)
        {
            CheckStock();
            decimal cost = CalculateTotal();
            UpdateStock();
            if (cost <= 50 && cost > 0)
            {
                CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                tblkChangeDue.Text = String.Format(currentCulture, "{0:C2}", 50 - cost);
                selectedDrinks.Clear();
                lbxCashier.ItemsSource = selectedDrinks;
            }
            else if (cost > 50)
            {
                MessageBox.Show("Insuffient note!!");
            }
            else
            {
                MessageBox.Show("Nothing was selected!!");
            }
        }

        //cashes off the cashier (doesn't display change so user will have to calculate change themselves)
        //calls the method that will update the stock of items that were sold
        private void CashButton_Click(object sender, RoutedEventArgs e)
        {
            CheckStock();
            decimal cost = CalculateTotal();
            UpdateStock();
            selectedDrinks.Clear();
            lbxCashier.ItemsSource = selectedDrinks;
        }

        //updates the int property stock in the database
        private void UpdateStock()
        {
            using (var db = new DrinksModelContainer())
            {
                List<Drinks> tempList = new List<Drinks>();
                foreach (var row in selectedDrinks)
                {
                    tempList.Add(row);
                }

                foreach (var row in tempList)
                {
                    if (row.Stock != null)
                    {
                        var query = from s in db.Drinks
                                    where s.Id == row.Id
                                    select s;

                        foreach (Drinks drink in query)
                        {
                            drink.Stock = drink.Stock - 1;
                        }
                        // Submit the changes to the database.
                        try
                        {
                            Console.WriteLine("Save Starting");
                            db.SaveChanges();
                            Console.WriteLine("Save Complete");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            // Provide for exceptions.
                        }

                    }
                }
            }

        }

        //THE ISSUE WITH THIS METHOD WAS IT WOULD -1 FROM THE STOCK LEVEL IN THE DATABASE BUT WOULD NOT READ THAT CHANGE 
        //THROUGH EACH ITERATION OF THE FOR LOOP SO THAT THE NEXT TIME IT ITERATED IT WOULD -1 FROM THE ORIGINAL STOCK AMOUNT AS OPPOSED TO THE NEW STOCK AMOUNT

        //private void UpdateStock()
        //{

        //    foreach (var row in selectedDrinks)
        //    {
        //        if (row.Stock != null)
        //        {
        //            int stock = Convert.ToInt32(row.Stock - 1);
        //            int id = Convert.ToInt32(row.Id);
        //            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\JOHNATHON\SOURCE\REPOS\LAST_TRY_DATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //            string selectSql = "UPDATE Drinks SET Stock = @stock";
        //            using (var connection = new SqlConnection(connectionString))
        //            using (var command = new SqlCommand(selectSql, connection))
        //            {
        //                command.CommandText = "UPDATE Drinks SET Stock = @stock WHERE Id=@rowID";
        //                command.Parameters.AddWithValue("@stock", stock);
        //                command.Parameters.AddWithValue("@rowID", id);
        //                connection.Open();
        //                command.ExecuteNonQuery();
        //                connection.Close();
        //            }
        //        }
        //    }
        //}

        private void lbxSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            using (var c = new DrinksModelContainer())
            {


                int index = lbxSelector.SelectedIndex;
                if (index != -1)
                {
                    tblkChangeDue.Text = null;
                    List<Drinks> selectedDrinks1 = AddToList(index);
                    selectedDrinks.Add(selectedDrinks1.First());
                    selectedDrinks1.Clear();
                    lbxCashier.ItemsSource = selectedDrinks.ToList();
                    lbxCashier.SelectedIndex = lbxCashier.Items.Count - 1;
                    lbxCashier.ScrollIntoView(lbxCashier.SelectedItem);
                    lbxSelector.SelectedItem = null;
                    //immediateley nullifies selected item, making it empty with an index of -1. This way we can notice a change from
                    //-1 to a new index in case one item is used more than one time
                    CalculateTotal();
                }
            }
        }
        private static List<Drinks> AddToList(int index)
        {
            List<Drinks> checkID = new List<Drinks>();
            using (var c = new DrinksModelContainer())
            {
                if (type == "Minerals")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 33
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Draught")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 15
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Wines")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 71
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Teas and Coffees")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 56
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Bottled Beer")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 1
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Gins")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 27
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Vodkas")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 62
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Whiskeys")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 66
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
                else if (type == "Shots")
                {
                    var query = from d in c.Drinks
                                where d.Id == index + 48
                                select d;

                    var query1 = query.ToList();

                    foreach (var item in query1)
                    {
                        checkID.Add(item);
                    }
                }
            }
            return checkID;
        }
        private decimal CalculateTotal()
        {
            decimal cost = 0;

            foreach (var item in selectedDrinks)
            {
                cost = cost + item.Cost;
            }
            if (cost > 0)
            {
                CultureInfo currentCulture = CultureInfo.GetCultureInfo("fr-FR");
                tblkTotal.Text = String.Format(currentCulture, "{0:C2}", cost);
            }
            else
            {

            }
            return cost;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool nameMatch = false;
            bool passwordMatch = false;
            nameMatch = CheckUsers(nameMatch);
            passwordMatch = CheckPassword(passwordMatch);

            if ((passwordMatch == true) && (nameMatch == true))
            {
                loginState = true;
                MessageBox.Show("You have successfully logged in");
                tbxUser.Text = null;
                tbxPassword.Text = null;
            }
            else
            {
                MessageBox.Show("Try again");
            }
        }

        private bool CheckUsers(bool nameMatch)
        {
            string username = tbxUser.Text;

            var users = from u in db.Users1
                        select u.Name;

            foreach (var user in users)
            {
                if (username == user)
                {
                    nameMatch = true;
                    break;
                }
                else
                {
                    nameMatch = false;
                    tbxUser.Text = null;
                    tbxPassword.Text = null;
                }
            }
            return nameMatch;
        }

        private bool CheckPassword(bool passwordMatch)
        {
            string password = tbxPassword.Text;

            var passwords = from u in db.Users1
                            select u.Password;

            foreach (var pass in passwords)
            {
                if (pass == password)
                {
                    passwordMatch = true;
                    break;
                }
                else
                {
                    passwordMatch = false;
                    tbxUser.Text = null;
                    tbxPassword.Text = null;
                }
            }
            return passwordMatch;
        }

        private void btnAddStock_Click(object sender, RoutedEventArgs e)
        {
            if (loginState == true)
            {
                string quantity = tbxStockQuantity.Text;
                try
                {
                    int amount = int.Parse(quantity);
                    AddStock(amount);
                }
                catch (Exception)
                {
                    MessageBox.Show("You did not enter a valid amount");
                    tbxStockQuantity.Text = null;
                }
            }
            else
            {
                MessageBox.Show("You need to log in first!");
            }

        }

        private void AddStock(int amount)
        {
            using (var db = new DrinksModelContainer())
            {
                List<Drinks> tempList = new List<Drinks>();
                foreach (var row in selectedDrinks2)
                {
                    tempList.Add(row);
                    tester.ItemsSource = tempList.ToList();
                }

                foreach (var row in tempList)
                {
                    try
                    {
                        var query = from s in db.Drinks
                                    where s.Id == row.Id
                                    select s;

                        foreach (Drinks drink in query)
                        {
                            if (drink.Stock != null)
                            {
                                drink.Stock = drink.Stock + amount;
                                MessageBox.Show(string.Format("You have added {0} {1}", amount, drink.Name));
                                tbxStockQuantity.Text = null;
                                selectedDrinks2.Clear();
                            }
                            else
                            {
                                MessageBox.Show("There is no stock for this item");
                            }

                        }
                        // Submit the changes to the database.
                        try
                        {
                            Console.WriteLine("Save Starting");
                            db.SaveChanges();
                            Console.WriteLine("Save Complete");
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void lbxSelector1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lbxSelector1.SelectedIndex;
            if (index != -1)
            {
                selectedDrinks2.Clear();
                selectedDrinks1 = AddToList(index);
                selectedDrinks2.Add(selectedDrinks1.First());
                selectedDrinks1.Clear();
                tester.ItemsSource = selectedDrinks2.ToList();
                lbxSelector1.SelectedItem = null;
            }
        }
    }
}
