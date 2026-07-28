using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NATIVOS.Models;
using System.Diagnostics;

namespace NATIVOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            string conexion = _configuration.GetConnectionString("ConexionDB");

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();

                SqlCommand buscar = new SqlCommand(
                    "SELECT IdUsuario FROM Usuarios WHERE Correo = @correo",
                    cn);

                buscar.Parameters.AddWithValue("@correo", correo);

                object resultado = buscar.ExecuteScalar();

                int idUsuario;

                if (resultado == null)
                {
                    SqlCommand insertar = new SqlCommand(
                        @"INSERT INTO Usuarios
                        (Nombre, Correo, Contrasena)
                        VALUES
                        (@nombre, @correo, @contrasena);

                        SELECT SCOPE_IDENTITY();",
                        cn);

                    insertar.Parameters.AddWithValue("@nombre", correo);
                    insertar.Parameters.AddWithValue("@correo", correo);
                    insertar.Parameters.AddWithValue("@contrasena", contrasena);

                    idUsuario = Convert.ToInt32(insertar.ExecuteScalar());
                }
                else
                {
                    idUsuario = Convert.ToInt32(resultado);
                }

                SqlCommand historial = new SqlCommand(
                    @"INSERT INTO HistorialInicioSesion(IdUsuario)
                    VALUES(@id)",
                    cn);

                historial.Parameters.AddWithValue("@id", idUsuario);
                historial.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Destinos");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}