using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp8_FrameWork
{
   

    public partial class MainWindow : Window
    {
        string connectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();




        public MainWindow()
        {
            SetConnection();
            InitializeComponent();
            
            
        }

        private void Window_Loaded(object sender,RoutedEventArgs e)
        {
            
            this.UpdateDataGrid();
        }
        private void Window_Closed(object sende,EventArgs e)
        {
            connection.Close();
        }
        private void SetConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void UpdateDB()
        {
            
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataTable);
        }
        
        private void UpdateDataGrid()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText="SELECT * FROM VYKLADACH";
            command.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(command);
            adapter.InsertCommand = new SqlCommand("sp_InsertTeacher", connection);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@PrizvVykl", SqlDbType.NVarChar, 225, "PrizvVykl"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@ImiaVykl", SqlDbType.NVarChar, 225, "ImiaVykl"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@PoBaVykl", SqlDbType.NVarChar, 225, "PoBaVykl"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@KodPost", SqlDbType.NVarChar, 225, "KodPost"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@NomKaf", SqlDbType.Real, 6, "NomKaf"));
            SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@KodVykl", SqlDbType.Int, 0, "KodVykl");
            parameter.Direction = ParameterDirection.Output;
            
            SqlDataReader dataReader = command.ExecuteReader();
            dataTable.Load(dataReader);
            vykladachTrym.ItemsSource = dataTable.DefaultView;
            dataReader.Close();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
           
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (vykladachTrym.SelectedItems != null)
            {
                for (int i = 0; i <vykladachTrym.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = vykladachTrym.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
    
    private void addButton_Click(object sender, RoutedEventArgs e)
        {
           
            String sql = "INSERT INTO VYKLADACH(KodVykl,PrizvVykl,ImiaVykl,PoBaVykl,PIBVykl,KodPost,NomKaf)" + "VALUES(@KodVykl, @PrizvVykl, @ImiaVykl, @PoBaVykl, @PIBVykl, @KodPost, @NomKaf)";
            this.AUD(sql, 0);
          
        }
        private void AUD(string sql_stmt,int state)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM VYKLADACH";
            String msg="";
            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = sql_stmt;
            sqlCommand.CommandType = CommandType.Text;
            switch (state)
            {
                case 0:
                    msg = "Row Added Successfully";
                    sqlCommand.Parameters.Add("KodVykl", SqlDbType.NVarChar, 255).Value = (int.Parse(dataTable.Rows[dataTable.Rows.Count-1].ItemArray[0].ToString())+1).ToString();
                    sqlCommand.Parameters.Add("PrizvVykl", SqlDbType.NVarChar, 255).Value = "nothing";
                    sqlCommand.Parameters.Add("ImiaVykl", SqlDbType.NVarChar, 255).Value = "nothing";
                    sqlCommand.Parameters.Add("PoBaVykl", SqlDbType.NVarChar, 255).Value = "nothing";
                    sqlCommand.Parameters.Add("PIBVykl", SqlDbType.NVarChar, 255).Value = "nothing";
                    sqlCommand.Parameters.Add("KodPost", SqlDbType.NVarChar, 255).Value = "nothing";
                    sqlCommand.Parameters.Add("NomKaf", SqlDbType.Real, 6).Value = "0";
                    break;
            }
            try
            {
                int n = sqlCommand.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.UpdateDataGrid();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vykladachTrym_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView dataRow = dataGrid.SelectedItem as DataRowView;
            if (dataRow != null)
            {
                
            }
        }
    }
}
