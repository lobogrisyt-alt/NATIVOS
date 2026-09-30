using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NATIVOS.Models;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace NATIVOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public SqlConnection ACTIVO { get; private set; }

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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RecuperarContrasena()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Registro2()
        {
            return View();
        }

        // =========================
        // REGISTRO DE USUARIO
        // =========================
        [HttpPost]
        public IActionResult Registro2(
            string nombre,
            string primerApellido,
            string segundoApellido,
            string celular,
            string correo,
            string fechaNacimiento,
            string sexo,
            string contrasena,
            string confirmarContrasena)
        {
            // Verificar que las contraseñas coincidan
            if (contrasena != confirmarContrasena)
            {
                return Content("Las contraseñas no coinciden.");
            }

            // Unimos primer y segundo apellido
            string apellido = primerApellido;

            if (!string.IsNullOrWhiteSpace(segundoApellido))
            {
                apellido += " " + segundoApellido;
            }

            // Generar hash de la contraseña
            string passwordHash = Convert.ToHexString(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(contrasena)
                )
            );

            string conexion =
                _configuration.GetConnectionString("ConexionDB");

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();

                // Verificar si el correo ya existe
                SqlCommand verificar = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Correo = @correo",
                    cn);

                verificar.Parameters.AddWithValue("@correo", correo);

                int existe = Convert.ToInt32(
                    verificar.ExecuteScalar()
                );

                if (existe > 0)
                {
                    return Content("Este correo ya está registrado.");
                }

                // Insertar nuevo usuario
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Usuarios
                    (Nombre, Apellido, Correo, PasswordHash, Rol, FechaRegistro, Estado)
                    VALUES
                    (@nombre, @apellido, @correo, @passwordHash,
                     @rol, GETDATE(), @estado)",
                    cn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                cmd.Parameters.AddWithValue("@rol", "Comunidad");
                cmd.Parameters.AddWithValue("@estado", "Activo");

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Login");
        }

        // =========================
        // LOGIN
        // =========================
        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            string conexion =
                _configuration.GetConnectionString("ConexionDB");

            // Generar el mismo hash utilizado durante el registro
            string passwordHash = Convert.ToHexString(
                SHA256.HashData(
                    Encoding.UTF8.GetBytes(contrasena)
                )
            );

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();

                SqlCommand buscar = new SqlCommand(
                    @"SELECT IdUsuario
                      FROM Usuarios
                      WHERE Correo = @correo
                      AND PasswordHash = @passwordHash
                      AND Estado = 'Activo'",
                    cn);

                buscar.Parameters.AddWithValue("@correo", correo);
                buscar.Parameters.AddWithValue(
                    "@passwordHash",
                    passwordHash
                );

                object resultado = buscar.ExecuteScalar();

                // Usuario no encontrado
                if (resultado == null)
                {
                    return Content(
                        "Correo o contraseña incorrectos. " +
                        "Si no tienes una cuenta, debes registrarte primero."
                    );
                }

                int idUsuario = Convert.ToInt32(resultado);

                // Registrar el inicio de sesión
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

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id ??
                    HttpContext.TraceIdentifier
            });
        }
    }
}