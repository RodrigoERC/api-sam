using SAM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Web.Http.Cors;

namespace SAM.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductosController : ApiController
    {
        private clsProductos objProductos;

        public ProductosController()
        {
            objProductos = new clsProductos();
        }

        [HttpPost]
        public HttpResponseMessage Prueba()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Correcto");
        }

        [HttpPost]
        public HttpResponseMessage Agregar(string nombre, string descripcion, float precio, int stock, byte[] imagen, int estatus, int idProveedor)
        {
            bool boolResultado;

            objProductos.nombre = nombre;
            objProductos.descripcion = descripcion;
            objProductos.precio = precio;
            objProductos.stock = stock;
            objProductos.estatus = estatus;
            objProductos.idProveedor = idProveedor;

            boolResultado = objProductos.Agregar(objProductos);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, Convert.ToString(boolResultado));
        }

        [HttpPut]
        public HttpResponseMessage Modificar(int idProducto, string nombre, string descripcion, float precio, int stock, byte[] imagen, int estatus, int idProveedor)
        {
            bool boolResultado;

            objProductos.idProducto = idProducto;
            objProductos.nombre = nombre;
            objProductos.descripcion = descripcion;
            objProductos.precio = precio;
            objProductos.stock = stock;
            objProductos.estatus = estatus;
            objProductos.idProveedor = idProveedor;

            boolResultado = objProductos.Modificar(objProductos);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, Convert.ToString(boolResultado));
        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(int idProducto, int estatus)
        {
            bool boolResultado;

            objProductos.idProducto = idProducto;
            objProductos.estatus = estatus;
            boolResultado = objProductos.Eliminar(objProductos);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, Convert.ToString(boolResultado));
        }

        [HttpGet]
        public string CargarDatosProductos()
        {
            return objProductos.CargarProductos();
        }

        [HttpGet]
        public string buscarProveedor(string b)
        {
            return objProductos.Buscar(b);
        }
    }
}