using Microsoft.AspNetCore.Mvc;
using Prueba_ARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_ARS.Controllers
{
    public class AfiliadoController : Controller
    {
        public IActionResult Index()
        {
            Database data = new Database();

            ViewData["Planes"] = data.ObtenerPlanes();
            ViewData["Estatuses"] = data.ObtenerEstatus();

            List<Afiliado> afiliados = data.ObtenerAfiliados();

            return View(afiliados);
        }

        [HttpPost]
        public IActionResult Index(string nombre, string apellido, string cedula)
        {
            Database data = new Database();

            ViewData["Planes"] = data.ObtenerPlanes();
            ViewData["Estatuses"] = data.ObtenerEstatus();


            List<Afiliado> afiliados = new List<Afiliado>();
            if (apellido is null && cedula is null)
            {
                afiliados = data.BuscarAfiliadosPorNombre(nombre);

            }
            else
            {
                afiliados = data.BuscarAfiliadosMasivo(nombre, apellido, cedula);
            }

            return View(afiliados);
        }

        public IActionResult Crear()
        {
            Database data = new Database();
            ViewData["Planes"] = data.ObtenerPlanes();
            ViewData["Estatuses"] = data.ObtenerEstatus();
            

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Afiliado afiliado)
        {
            Database data = new Database();

            data.GuardarAfiliado(afiliado);
            return Redirect("Index");
        }

        public IActionResult Actualizar(int Id)
        {
            Database data = new Database();
            Afiliado afiliado = data.BuscarAfiliadosPorId(Id);

            ViewData["Planes"] = data.ObtenerPlanes();
            ViewData["Estatuses"] = data.ObtenerEstatus();

            return View(afiliado);
        }

        [HttpPost]
        public IActionResult Actualizar(Afiliado afiliado)
        {
            Database data = new Database();
            data.ActualizarAfiliado(afiliado);

            return Redirect("~/afiliado/Index");
        }

        public IActionResult Inactivar(int Id)
        {
            Database data = new Database();
            data.InactivarAfiliado(Id);

            return Redirect("~/afiliado/Index");
        }

        [HttpPost]
        public IActionResult ActualizarMonto(int Id, Decimal Monto_Consumido)
        {
            Database data = new Database();
            data.ActualizarMontoConsumido(Id, Monto_Consumido);

            return Redirect("~/afiliado/Index");
        }
    }


}
