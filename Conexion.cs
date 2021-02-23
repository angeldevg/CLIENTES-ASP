using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace Clientes_bd
{
    public class Conexion{

        private String cadena = "server=localhost; database=db_empresa; user=usr_empresa; password=Empres@123";

        public MySqlConnection conection = new MySqlConnection();
        public MySqlDataAdapter adapter = new MySqlDataAdapter();

        public void OpenConection(){

            try {

                String conn;

                conn = cadena;

                conection = new MySqlConnection();

                conection.ConnectionString = conn;
                conection.Open();


                System.Diagnostics.Debug.WriteLine("Conexion Exitosa!!!");


            }
            catch(Exception ex) {

                System.Diagnostics.Debug.WriteLine(ex.Message);

            }


        }


        public void CloseConection() {

            if (conection.State == System.Data.ConnectionState.Open) {
                conection.Close();

            }


        }


    }
}