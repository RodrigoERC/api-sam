using System;
using ApiVeterinaria.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace ApiVeterinaria.Controllers
{
    public class ProveedorController : ApiController
    {
        private clsProveedor objProveedor;

        private ProveedorController() {
            objProveedor = new clsProveedor();
        }

        [HttpPost]
        public HttpResponseMessage Agregar(string pNombre, string pTelefono, string pDireccion, string pCorreo) {
            bool resultado;

            objProveedor.StrNombre = pNombre;
            objProveedor.StrTelefono = pTelefono;
            objProveedor.StrCorreo = pCorreo;
            objProveedor.StrDireccion = pDireccion;

            resultado = objProveedor.Agregar(objProveedor);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado ? "OK" : "No jalo");

        }

        [HttpPut]
        public HttpResponseMessage Modificar(int pId, string pNombre, string pTelefono, string pDireccion, string pCorreo)
        {
            bool resultado;

            objProveedor.Id = pId;
            objProveedor.StrNombre = pNombre;
            objProveedor.StrTelefono = pTelefono;
            objProveedor.StrCorreo = pCorreo;
            objProveedor.StrDireccion = pDireccion;

            resultado = objProveedor.Modificar(objProveedor);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado ? "OK" : "No jalo");

        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(int pId)
        {
            bool bolResultado;
            bolResultado = objProveedor.Eliminar(pId);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, bolResultado ? "OK" : "Algo salio mal");
        }

        [HttpGet]
        public string DatosProveedor() {
            return objProveedor.CargarProveedor();
        }

        [HttpGet]
        public string buscarProveedor(string b)
        {
            return objProveedor.Buscar(b);
        }

    }
}