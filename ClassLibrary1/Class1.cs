using MySql.Data.MySqlClient;

namespace ClassLibrary1
{
    public class Class1
    {
        string servidor = "localhost";
        string bd = "Agenda2023";
        string usuario = "root";
        string password = "";

        public List<string> buscar(String id)
        {
            List<string> contacto = new List<string>();
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string consulta = "select * from agenda2023 where id='" + id + "'";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    contacto.Add(reader.GetInt32(0).ToString()); 
                    contacto.Add(reader.GetString(1));
                    contacto.Add(reader.GetString(2));
                    contacto.Add(reader.GetString(3));
                }
            }
            catch (MySqlException ex)
            {
                //return ex.Message; //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                conexionBD.Close(); //Cierra la conexión a MySQL
            }
            return contacto;
        }

        public List<Contacto> mostrar()
        {
            List<Contacto> contacto = new List<Contacto>();

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string consulta = "select * from agenda2023";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    contacto.Add(new Contacto(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }
            catch (MySqlException ex)
            {
                //return ex.Message; //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                conexionBD.Close(); //Cierra la conexión a MySQL
            }
            return contacto;
        }

        public String crear(String nom, String app, String tel)
        {
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);

            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "insert into agenda2023(nom, app, tel) values('" + nom + "','" + app + "','" + tel + "')";
            comm.ExecuteNonQuery();
            conn.Close();

            return "Se creó el contacto";
        }

        public String modificar(String id, String nom, String app, String tel)
        {
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);

            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "update agenda2023 set nom = '" + nom + "' , app = '" + app + "' , tel = '" + tel + "' where id = '" + id + "'";
            comm.ExecuteNonQuery();
            conn.Close();
            return "Se modificó el contacto";
        }
        public String eliminar(String id)
        {
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);

            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "delete from agenda2023 where id = '" + id + "'";
            comm.ExecuteNonQuery();
            conn.Close();
            return "Se eliminó el contacto";
        }

    }
}
