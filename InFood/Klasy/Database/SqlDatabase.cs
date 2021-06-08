using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using InFood.Klasy;
using InFood.Klasy.BusinessLogic;

namespace InFood.Klasy.Database
{
    class SqlDatabase
    {
        public static void SaveObjectToDB(string a_sFileName)
        {
            Uzytkownik[] _oUsers;
            //var xmlData = _oUsers.ImportFromFile(a_sFileName);
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "infood.database.windows.net";
                builder.UserID = "infood";
                builder.Password = "Admin#2021";
                builder.InitialCatalog = "infood";
                
                /*using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into SerializedData values(@xmldata,@varchardata,@varbinarydata)";

                        cmd.Parameters.Add("@xmldata", SqlDbType.Xml, Int32.MaxValue).Value = xmlData.InnerXml;
                        cmd.Parameters.Add("@varchardata", SqlDbType.VarChar, Int32.MaxValue).Value = strData;
                        cmd.Parameters.Add("@varbinarydata", SqlDbType.VarBinary, Int32.MaxValue).Value = binData;

                        cmd.ExecuteNonQuery();
                    }
                }*/
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
