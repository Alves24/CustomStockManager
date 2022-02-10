using LibreriaPersonal;
using System;
using System.IO;

namespace Mep3._0
{
    public static class Logger
    {
        public static void Producto(Balde prod, string motivo)
        {
            string fileName
                = FormatFileName($"{prod.GetNombreCompleto()}_{prod.GetID()}");
            string path = $"files/logs/Productos/{ fileName }.txt";

            string mensaje;

            mensaje = "________________________________________________________________________\r";

            mensaje += Fechas.Formato_Dia_Mes_Anio_Letras(DateTime.Now) + "\r";

            mensaje += $"| { prod.GetNombreCompleto() } | Cambio a | Motivo: {motivo}  \r";

            mensaje += String.Format("| {0,-4} | {1,-4} | {2,-4} | {3,-4} |",
                                     "x20", "x10", "x4", "x1") + "\r";

            mensaje += String.Format("| {0,-4} | {1,-4} | {2,-4} | {3,-4} |",
                                     prod.Get20(), prod.Get10(), prod.Get4(), prod.Get1()) + "\r";

            WriteLog(path, mensaje);
        }

        public static void Material(MateriaPrima mp, string motivo, float stockAnterior, float stockModificado)
        {
            string fileName = FormatFileName($"{mp.Nombre}_{mp.id}");
            string path = $"files/logs/Materiales/{ fileName }.txt";

            WriteLog(path, motivo, stockAnterior, stockModificado);
        }

        public static void Error(string ErrorCode, string ObjetoData)
        {
            string mensaje = Fechas.Formato_Dia_Mes_Anio_Letras(DateTime.Now) + "\r";
            mensaje += $"Codigo del Error: {ErrorCode} \r";
            mensaje += $"Objeto: {ObjetoData} \r";

            WriteLog("files/logs/ErrorLogs.txt", mensaje);
        }

        private static void WriteLog(string path, string motivo, float stockAnterior, float stockModificado)
        {
            string fecha = Fechas.Formato_Dia_Mes_Anio_Letras(DateTime.Now);
            fecha = $"------ { fecha } ------";

            string datos = $"STOCK - Anterior: {stockAnterior} Modificado: {stockModificado}.";

            using (StreamWriter Archivo = File.AppendText(path))
            {
                Archivo.WriteLine();
                Archivo.WriteLine(fecha);
                Archivo.WriteLine(motivo);
                Archivo.WriteLine(datos);

                Archivo.Close();
            }
        }

        private static void WriteLog(string path, string mensaje)
        {
            using (StreamWriter Archivo = File.AppendText(path))
            {
                Archivo.WriteLine();
                Archivo.Write(mensaje);

                Archivo.Close();
            }
        }

        private static string FormatFileName(string longFileName)
        {
            string newName = longFileName.Replace(" ", "");
            return newName.Replace("/", "-");
        }
    }
}