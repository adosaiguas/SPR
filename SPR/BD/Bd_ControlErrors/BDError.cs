using System;
using SPR.Controller;

public class BDErrors
{
    public static String controlError(SqlException e)
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
                    msg = "Error de base de datos";
                    break;
                case 18456:
                    msg = "Entrada de usuario o contraseña incorrectos";
                    break;
                default:
                    msg = e.Number + "   " + e.Message.ToString();
                    break;
            }
            return msg;
        }
        catch (NullReferenceException ex)
        {
            FileController.writeDataIntoLog(Console.WriteLine(ex.Message), FileController.fileStr);
        }
    }
    
}
