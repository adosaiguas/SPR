using SPR.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.BD
{
    class BdError
    {
        public static String ControlError(SqlException e)
        {
            try
            {
                String msg;
                switch (e.Number)
                {
                    case 2601:
                    case 2627:
                        msg = "El registro que se intenta introducir ya se encuentra en la base de datos";
                        break;
                    case 208:
                        msg = "Nombre de tabla incorrecta";
                        break;
                    case 53:
                        msg = "Error de conexión con el servidor";
                        break;
                    case 547:
                        msg = "El registro que se intenta eliminar hace referencia a otro registro de otra base de datos. Imposible eliminar.";
                        break;
                    case 4060:
                        msg = "Error de base de datos, no se encuentra en el servidor";
                        break;
                    default:
                        msg = e.Number + "   " + e.Message.ToString();
                        break;
                }
                return msg;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(FileController.writeDataIntoALog(ex.Message + " " + ex.StackTrace, FileController.fileStr));
                return ex.Message;
            }
        }
    }
}
