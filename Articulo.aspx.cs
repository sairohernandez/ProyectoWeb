using System;
using System.Web;
using System.Web.UI;
using PrograWeb.Datos;
using PrograWeb.Modelos;
using System.Collections.Generic;

namespace PrograWeb
{

    public partial class Articulo : System.Web.UI.Page
    {
        protected EArticulo articulo;


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!Page.IsPostBack) || (string.IsNullOrEmpty(Request.QueryString["id"])))
              
            {
                try
                {
                    string id = Request.QueryString["id"];
                    DArticulo mArticulo = new DArticulo();
                    this.articulo = mArticulo.getArticuloById(id);

                    ProductImage.ImageUrl = this.articulo.rutaImagen;
                    ProductName.Text = this.articulo.nombreArticulo;
                    ProductPrice.Text = "₡" + this.articulo.precioArticulo.ToString("#,000.00");
                    ProductDescription.Text = this.articulo.descripcionArticulo;
                    ProductSku.Text = this.articulo.skuArticulo;
                    ProductCategory.Text = this.articulo.categoriaArticulo;

                    if (this.articulo.cantidadArticulo <= 0)
                    {
                        ProductQty.Visible = false;
                        AddToCartBtn.Text = "Agotado";
                        AddToCartBtn.Enabled = false;
                        AddToCartBtn.CssClass = "d-inline-block w-50 btn btn-secondary align-top";
                    }
              
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
         
        }

        protected void Add_To_Cart(object sender, EventArgs e)
        {
            List<EFacturaDetalle>  car = (List<EFacturaDetalle>)Session["GridView"];

            if (car == null) {
                car = new List<EFacturaDetalle>();
            }
            car.Add(new EFacturaDetalle {  
                codigoArticulo = Convert.ToInt32(Request.QueryString["id"]),          
                cantidadDetalle = Convert.ToInt32(ProductQty.Text),
                nombreArticulo = ProductName.Text,
                precioDetalle = Convert.ToDouble(ProductPrice.Text.Replace("₡", ""))
            });
            Session["GridView"] = car;

            //     //Session["GridView"]

            //Console.WriteLine("addtocart 1");
            //int id = this.articulo.idArticulo;
            //int qty = Int32.Parse(ProductQty.Text);
            //Console.WriteLine("addtocart 2");

            //if (!string.IsNullOrEmpty(ProductQty.Text))
            //{
            //    Console.WriteLine("addtocart 3");
            //    //Response.Redirect(this.articulo.idArticulo.ToString() + "-" + ProductQty.Text + ".aspx");
            //}
            //Console.WriteLine("addtocart 4");
        }


    }
}
