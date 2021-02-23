using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;



namespace Clientes_bd
{
    public class Clientes{


        Conexion conectar;


        public int Add(string nit, string nombres, string apellidos, string direccion, string telefono, string fecha){

            conectar = new Conexion();
            int no_ingreso = 0;

            string strconsulta = string.Format("insert into clientes (nit, nombres, apellidos, direccion, telefono, fecha_nacimiento) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", nit, nombres, apellidos, direccion, telefono, fecha);

            MySqlCommand insertar = new MySqlCommand(strconsulta, conectar.conection);

            conectar.OpenConection();

            insertar.Connection = conectar.conection;

            no_ingreso = insertar.ExecuteNonQuery();

            conectar.CloseConection();

            return no_ingreso;  
        }


        public int Update(int id, string nit, string nombres, string apellidos, string direccion, string telefono){

            conectar = new Conexion();
            int no_modificacion = 0;

            string strconsulta = string.Format("update clientes set nit = '{0}', nombres = '{1}', apellidos = '{2}', direccion = '{3}', telefono = '{4}' where id_cliente = {5};", nit, nombres, apellidos, direccion, telefono, id);

            MySqlCommand modificar = new MySqlCommand(strconsulta, conectar.conection);

            conectar.OpenConection();

            modificar.Connection = conectar.conection;

            no_modificacion = modificar.ExecuteNonQuery();

            conectar.CloseConection();

            return no_modificacion;  
        }


        public int Delete(int id){

            conectar = new Conexion();
            int no_eliminacion = 0;

            string strconsulta = string.Format("delete from clientes where id_cliente  = {0}", id);

            MySqlCommand eliminar = new MySqlCommand(strconsulta, conectar.conection);

            conectar.OpenConection();

            eliminar.Connection = conectar.conection;

            no_eliminacion = eliminar.ExecuteNonQuery();

            conectar.CloseConection();

            return no_eliminacion;
        }

    private DataTable GridClientes(){

            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.OpenConection();

            string consulta = string.Format("select c.id_cliente as id, c.nit, c.nombres, c.apellidos, c.direccion, c.telefono, c.fecha_nacimiento from clientes c;");

            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conection);

            query.Fill(tabla);

            conectar.CloseConection();


            return tabla;
        
        }


        public void GridClientes(GridView grid){

            grid.DataSource = GridClientes();
            grid.DataBind();
                   
        
        }

    }
}