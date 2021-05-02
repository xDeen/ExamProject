using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class DataAccess
    {
        MySqlConnection objConnection = new MySqlConnection();
        MySqlCommand objCommand = new MySqlCommand();
        MySqlDataAdapter objAdapter = new MySqlDataAdapter();


        public string CommandText
        {
            set
            {
                objCommand.CommandText = value.Trim();
            }

        }

        public MySqlParameter Parameter
        {
            set
            {
                objCommand.Parameters.Add(value);
            }
        }

        public System.Data.CommandType CommandType
        {
            set
            {
                objCommand.CommandType = value;
            }
        }

        public MySqlCommand Command
        {
            get
            {
                return objCommand;
            }
            set { }
        }

        public MySqlConnection Connection
        {
            get
            {
                return objConnection;
            }
            set { }
        }

        public void AddParameter(string strParamName, object objValue)
        {
            if ((objValue is string))
            {
                objValue.ToString();
            }

            MySqlParameter p1 = new MySqlParameter(strParamName, ((objValue == null) ? DBNull.Value : objValue));
            objCommand.Parameters.Add(p1);
        }

        public DataTable ReturnDataTable()
        {
            DataTable tempDT = new DataTable();
            try
            {

                this.InitializeConnection();
                objConnection.Open();
                objCommand.Connection = objConnection;
                objAdapter.SelectCommand = objCommand;
                objAdapter.Fill(tempDT);
                objConnection.Close();
                return tempDT;
            }
            catch (Exception ex)
            {
                string test = ex.ToString();
                objConnection.Close();
                return tempDT;
            }

        }

        public DataSet ReturnDataSet()
        {
            DataSet tempDS = new DataSet();
            this.InitializeConnection();
            objConnection.Open();
            objCommand.Connection = objConnection;
            objAdapter.SelectCommand = objCommand;
            objAdapter.Fill(tempDS);
            objConnection.Close();
            return tempDS;
        }

        public MySqlDataReader ReturnDataReader()
        {
            this.InitializeConnection();
            objConnection.Open();
            objCommand.Connection = objConnection;
            MySqlDataReader objReader = objCommand.ExecuteReader();
            return objReader;
        }

        public string ReturnScalar()
        {
            string tempStr;
            this.InitializeConnection();
            objConnection.Open();
            objCommand.Connection = objConnection;
            tempStr = objCommand.ExecuteScalar().ToString();
            objConnection.Close();
            return tempStr;
        }

        public void ExecuteNonQuery()
        {
            this.InitializeConnection();
            objConnection.Open();
            objCommand.Connection = objConnection;
            objCommand.ExecuteNonQuery();
            objConnection.Close();
        }

        public void Dispose()
        {
            if ((objConnection.State == ConnectionState.Open))
            {
                objConnection.Close();
            }

            objConnection.Dispose();
            objCommand.Dispose();
            objAdapter.Dispose();
        }

        public void InitializeConnection()
        {
            

            string FILE_NAME = "";
            string myServer = "";
            string myPort = "";
            string myDB = "";
            string myUID = "";
            string myPW = "";
            string cn = "";

            FILE_NAME = "Conn.cn";
            if (System.IO.File.Exists(FILE_NAME) == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(FILE_NAME);
                string line;
                string[] row;
                do
                {
                    line = objReader.ReadLine();
                    if (line == "")
                    {
                        break;
                    }
                    if (line[0] == '#')
                    {
                        continue;
                    }

                    row = line.Split(':');
                    if (row[0] == "Server")
                    {
                        myServer = row[1];
                    }
                    else if (row[0] == "port")
                    {
                        myPort = row[1];
                    }
                    else if (row[0] == "Database")
                    {
                        myDB = row[1];
                    }
                    else if (row[0] == "Uid")
                    {
                        myUID = row[1];
                    }
                    else if (row[0] == "Pwd")
                    {
                        myPW = row[1];
                    }


                } while (objReader.Peek() != -1);

               

                cn = "Server = " + myServer + "; " + "Port = " + myPort + "; " + "Database = " + myDB + "; " + "Uid = " + myUID + "; " + "Pwd = " + myPW + "; ";
                objReader.Close();
            }

            objConnection.ConnectionString = cn;
            objCommand.CommandTimeout = 0;

          
        }
    }
}
