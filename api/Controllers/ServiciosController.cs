using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using api.Models;
using System.Text;
using System.Data.SqlClient;
using System.Web.Http.Cors;
using Microsoft.Extensions.Primitives;
using System.Web.UI;
using Azure;

namespace api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*")]
    public class SeviciosController : ApiController
    {
        private clsServicios objServicios;
        

        public SeviciosController()
        {
            objServicios = new clsServicios();
        }
        // GET: Cliente
        //[HttpPost]

        [HttpPost]
        public HttpResponseMessage Agregar(string pstrNombre, string pstrDescripcion, double pstrcosto, string pstrImagen)
        {
            
            string resultado;
            objServicios.pstrNombre = pstrNombre;
            objServicios.pstrDescripcion = pstrDescripcion;
            objServicios.pstrCosto = pstrcosto;
            objServicios.pstrImagen = pstrImagen;
            resultado = objServicios.Agregar(objServicios);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());

        }

        [HttpPut]
        public HttpResponseMessage Modificar(int idServicio, string pstrNombre, string pstrDescripcion, double pstrcosto, string pstrImagen)
        {
            string resultado;
            objServicios.intIdServicio = idServicio;
            objServicios.pstrNombre = pstrNombre;
            objServicios.pstrDescripcion = pstrDescripcion;
            objServicios.pstrCosto = pstrcosto;
            objServicios.pstrImagen = pstrImagen;
            resultado = objServicios.Modificar(objServicios);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());
            

        }
        [HttpDelete]
        public HttpResponseMessage Eliminar(int idServicio)
        {
            string resultado;
            objServicios.intIdServicio = idServicio;
            resultado = objServicios.eliminar(objServicios);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,resultado.ToString());

        }
       
       
        [HttpGet]
        public string CargarServicios()
        {
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objServicios.CargarDatos();

            strDatos.Append("{"+'"'+"data"+'"'+":[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdServicio" + '"' + ":" + '"' + drRegistros["idServicio"] + '"' + "," + '"' + "Nombre" + '"' + ":" + '"' + drRegistros["Nombre"] + '"' + "," + '"'+ "Descripcion" + '"' + ":" + '"' + drRegistros["Descripcion"] + '"' + "," + '"' + "Costo" + '"' + ":" + '"' + drRegistros["Costo"] + '"' + "," + '"' +  "Img" + '"' + ":" + '"' + drRegistros["Imagen"] + '"' + "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]}");
            drRegistros.Close();

            return strDatos.ToString();
        }
       [HttpPost]
        public string BuscarServicios(string pstrNombre)
        {
            objServicios.pstrNombre = pstrNombre;
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objServicios.BuscarServicio(objServicios);

            strDatos.Append("{" + '"' + "data" + '"' + ":[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdServicio" + '"' + ":" + '"' + drRegistros["idServicio"] + '"' + "," + '"' + "Nombre" + '"' + ":" + '"' + drRegistros["Nombre"] + '"' + "," + '"' + "Descripcion" + '"' + ":" + '"' + drRegistros["Descripcion"] + '"' + "," + '"' + "Costo" + '"' + ":" + '"' + drRegistros["Costo"] + '"' + "," + '"' + "Img" + '"' + ":" + '"' + drRegistros["Imagen"] + '"' + "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]");
            drRegistros.Close();
            return strDatos.ToString();
        }
    }
}