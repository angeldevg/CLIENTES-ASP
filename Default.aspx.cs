using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Clientes_bd{

    public partial class _Default : Page{

        Clientes clientes;

        protected void Page_Load(object sender, EventArgs e){

            clientes = new Clientes();

            clientes.GridClientes(grid_clientes);


        }

        protected void btn_agregar_Click(object sender, EventArgs e){

            clientes = new Clientes();

            if (clientes.Add(txt_nit.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fn.Text) > 0) {

                lbl_message.Text = "Ingreso Exitoso";
                clientes.GridClientes(grid_clientes);
            }



        }

        protected void grid_clientes_SelectedIndexChanged(object sender, EventArgs e){


            txt_nit.Text = grid_clientes.SelectedRow.Cells[2].Text;
            txt_nombres.Text = grid_clientes.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_clientes.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_clientes.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_clientes.SelectedRow.Cells[6].Text;


            btn_modificar.Visible = true;

        }

        protected void grid_clientes_RowDeleting(object sender, GridViewDeleteEventArgs e) {

            clientes = new Clientes();

            if (clientes.Delete(Convert.ToInt32(e.Keys["id"])) > 0){

                lbl_message.Text = "Dato Eliminado!!!";
                clientes.GridClientes(grid_clientes);
                btn_modificar.Visible = false;

            }

        }

        protected void btn_modificar_Click(object sender, EventArgs e){

            clientes = new Clientes();

            if (clientes.Update(Convert.ToInt32(grid_clientes.SelectedValue), txt_nit.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text) > 0){

                lbl_message.Text = "Actualizado Correctamente!!!";
                clientes.GridClientes(grid_clientes);
                btn_modificar.Visible = false;
            }

        }
    }
}