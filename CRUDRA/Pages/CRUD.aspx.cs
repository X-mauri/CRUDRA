﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;

namespace CRUDRA.Pages
{
          
    public partial class CRUD : System.Web.UI.Page
    {  readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
            public static string sID = "-1";
            public static string sOpc = "";

            protected void Page_Load(object sender, EventArgs e)
            {
                //obtener el id
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    }

                    if (Request.QueryString["op"] != null)
                    {
                        sOpc = Request.QueryString["op"].ToString();

                        switch (sOpc)
                        {
                            case "C":
                                this.lbltitulo.Text = "Ingresar nuevo usuario";
                                this.BtnCreate.Visible = true;
                                break;
                            case "R":
                                this.lbltitulo.Text = "Consulta de usuario";
                                break;
                            case "U":
                                this.lbltitulo.Text = "Modificar usuario";
                                this.BtnUpdate.Visible = true;
                                break;
                            case "D":
                                this.lbltitulo.Text = "Eliminar usuario";
                                this.BtnDelete.Visible = true;
                                break;
                        }
                    }
                }
            }

            void CargarDatos()
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbnombre.Text = row[1].ToString();
                tbapellidop.Text = row[2].ToString();
                tbapellidom.Text = row[3].ToString();
                tbnumeroc.Text = row[4].ToString();
                tbcarrera.Text = row[5].ToString();
                con.Close();
            }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@ApellidoP", SqlDbType.VarChar).Value = tbapellidop.Text;
            cmd.Parameters.Add("@ApellidoM", SqlDbType.VarChar).Value = tbapellidom.Text;
            cmd.Parameters.Add("@NumeroC", SqlDbType.Int).Value = tbnumeroc.Text;
            cmd.Parameters.Add("@Carrera", SqlDbType.VarChar).Value = tbcarrera.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
            }

            protected void BtnUpdate_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("sp_update", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
                cmd.Parameters.Add("@ApellidoP", SqlDbType.VarChar).Value = tbapellidop.Text;
                cmd.Parameters.Add("@ApellidoM", SqlDbType.VarChar).Value = tbapellidom.Text;
                cmd.Parameters.Add("@NumeroC", SqlDbType.Int).Value = tbnumeroc.Text;
                cmd.Parameters.Add("@Carrera", SqlDbType.VarChar).Value = tbcarrera.Text;
                cmd.ExecuteNonQuery();
                con.Close();


        }

            protected void BtnDelete_Click(object sender, EventArgs e)
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }

            protected void BtnVolver_Click(object sender, EventArgs e)
            {
                Response.Redirect("Index.aspx");
            }
        }
    }