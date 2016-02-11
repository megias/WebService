using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApiCristianMegias.Areas.Api.Models
{
    public class VideoManager
    {
        //Cambiar la ruta
        private static string cadenaConexion =
          @"Data Source=SGOLIVER-PC\SQLEXPRESS;Initial Catalog=DBCLIENTES;Integrated Security=True";

        public bool InsertarVideo(VideoPlayer video)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();
            //Cambiar la ruta
            string sql = "INSERT INTO Clientes (Nombre, link, tipus) VALUES (@nombre, @link, @tipus)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = video.Nombre;
            cmd.Parameters.Add("@link", System.Data.SqlDbType.NVarChar).Value = video.link;
            cmd.Parameters.Add("@tipus", System.Data.SqlDbType.NVarChar).Value = video.tipus;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
        public VideoPlayer ObtenerVideo(int id)
        {
            VideoPlayer video = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();
            //Cambiar la ruta
            string sql = "SELECT Nombre, Telefono FROM Clientes WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.NVarChar).Value = id;

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            if (reader.Read())
            {
                video = new VideoPlayer();
                video.Id = id;
                video.Nombre = reader.GetString(0);
                video.link = reader.GetString(1);
                video.tipus = reader.GetString(2);
            }

            reader.Close();

            return video;
        }
        public List<VideoPlayer> ObtenerVideos()
        {
            List<VideoPlayer> lista = new List<VideoPlayer>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();
            //Cambiar ruta
            string sql = "SELECT IdCliente, Nombre, Telefono FROM Clientes";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                VideoPlayer video = new VideoPlayer();

                video = new VideoPlayer();
                video.Id = reader.GetInt32(0);
                video.Nombre = reader.GetString(1);
                video.link = reader.GetString(2);
                video.tipus = reader.GetString(3);

                lista.Add(video);
            }

            reader.Close();

            return lista;
        }
    }
}