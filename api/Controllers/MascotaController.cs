using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using api.Models;
using System.Text;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace api.Controllers
{
    public class MascotaController : ApiController
    {
        private clsMascota objMascota;
        

        public MascotaController()
        {
            objMascota = new clsMascota();
        }
        // GET: Cliente
        [HttpPost]
        public HttpResponseMessage Prueba()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Correcto");

        }

        [HttpPost]
        public HttpResponseMessage Agregar(string nombre, int edad, string especie, string raza, string caracteristicas, int id_cliente, int estatus)
        {
            string resultado;
            objMascota.nombre = nombre;
            objMascota.edad = edad;
            objMascota.especie = especie;
            objMascota.raza = raza;
            objMascota.caracteristicas = caracteristicas;
            objMascota.id_cliente = id_cliente;
            objMascota.estatus = estatus;
            resultado = objMascota.Agregar(objMascota);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());

        }

        [HttpPut]
        public HttpResponseMessage Modificar(int id_mascota, string nombre, int edad, string especie, string raza, string caracteristicas, int id_cliente, int estatus)
        {
            bool resultado;
            objMascota.id_mascota = id_mascota;
            objMascota.nombre = nombre;
            objMascota.edad = edad;
            objMascota.especie = especie;
            objMascota.raza = raza;
            objMascota.caracteristicas = caracteristicas;
            objMascota.id_cliente = id_cliente;
            objMascota.estatus = estatus;
            resultado = objMascota.Modificar(objMascota);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());            

        }

        [HttpPut]
        public HttpResponseMessage Eliminar(int id_mascota)
        {
            bool resultado;
            objMascota.id_mascota = id_mascota;
            resultado = objMascota.eliminar(objMascota);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());
        }

        [HttpGet]
        public string  CargarMascota()
        {
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objMascota.CargarDatos();

            strDatos.Append("{" + '"' + "data" + '"' + ":" + "[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "id_mascota" + '"' + ":" + drRegistros["id_mascota"] + ", "
                    + '"' + "nombre" + '"' + ":" + '"' + drRegistros["nombre"] + '"' + ", "
                    + '"' + "edad" + '"' + ":" + drRegistros["edad"] + ", "
                    + '"' + "especie" + '"' + ":" + '"' + drRegistros["especie"] + '"' + ", "
                    + '"' + "raza" + '"' + ":" + '"' + drRegistros["raza"] + '"' + ", "
                    + '"' + "caracteristicas" + '"' + ":" + '"' + drRegistros["caracteristicas"] + '"' + ","
                    + '"' + "id_cliente" + '"' + ":" + drRegistros["id_cliente"] +
                    "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]}");
            drRegistros.Close();
            return strDatos.ToString();
        }
        [HttpPost]
        public string BuscarMascota(string nombre)
        {
            objMascota.nombre = nombre;
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objMascota.BuscarMascota(objMascota);

            strDatos.Append("{" + '"' + "data" + '"' + ":" + "[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "id_mascota" + '"' + ":" + drRegistros["id_mascota"] + ", "
                    + '"' + "nombre" + '"' + ":" + '"' + drRegistros["nombre"] + '"' + ", "
                    + '"' + "edad" + '"' + ":" + drRegistros["edad"] + ", "
                    + '"' + "especie" + '"' + ":" + '"' + drRegistros["especie"] + '"' + ", "
                    + '"' + "raza" + '"' + ":" + '"' + drRegistros["raza"] + '"' + ", "
                    + '"' + "caracteristicas" + '"' + ":" + '"' + drRegistros["caracteristicas"] + '"' + ","
                    + '"' + "id_cliente" + '"' + ":" + drRegistros["id_cliente"] +
                    "}, ");
            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]");
            drRegistros.Close();
            return strDatos.ToString();
        }
    }
}