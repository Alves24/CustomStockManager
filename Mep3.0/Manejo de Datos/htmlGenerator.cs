
// PDF

//using IronPdf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
   
using LibreriaPersonal;
// Files
using System.IO;
using ManejoDatos;
using Mep3._0.Entidades.Especificas;

namespace Mep3._0
{
    public struct ProductoNeto
    {
        public int Cantidad;
        public string Nombre;
    }

    public static class htmlGenerator
    {
        // Public classes
        public static void Make_StockActual(List<MateriaPrima> Materiales, List<Balde> Productos, int numProduccion)
        {
            var momentoActual = DateTime.Now;
            string textoFecha = Fechas.Formato_Dia_Mes_Anio_Letras(momentoActual);
            string hora = momentoActual.Hour.ToString() + ":" + momentoActual.Minute.ToString();
            
            string body = "";
            string code;

            // HEADER PAGINA
            body += $"<div id='headerPagina'>";
            body += @"<img id='logo' src='maquetador\logoAlumanta.png' alt='Logo Alumanta'>";
            body += $"<h1> Informe de Stock </h1>";
            body += $"<h2> { textoFecha } </h2>";
            body += $"<h2> { hora } </h2>";
            body += $"</div>";

            #region STOCK
            body += "<div id='ContenedorTablas'>";

            // TABLA PRODUCTOS
            body += Tabla_StockActualProductos(Productos , numProduccion);
            
            // TABLA MATERIALES
            body += Tabla_StockActualMateriaPrima(Materiales);

            body += "</div>";
            #endregion

            
            #region TABLAS GENERICAS
            //body += "<div id='ContenedorTablas'>";

            //// Tabla ultimas ORDENES
            //body += Tabla_Generica(GetMatrizOrdenes(5), "UltimasOrdenes", "UltimasOrdenes");

            //body += "</div>";
            #endregion

            code = htmlCodeGenerator(ReadStockActualCSS(), body, " Informe de Stock M.E.P.");
            RenderToHTML(code);
        }
    
        private static string[,] GetMatrizOrdenes( int cantidad )
        {
            var Ordenes = Deserializador.Ordenes(cantidad);
            var matriz = new string[cantidad + 1 , 4];

            // Headers (th)
            matriz[0, 0] = "Numero";
            matriz[0, 1] = "Cliente";
            matriz[0, 2] = "Estado";
            matriz[0, 3] = "Fecha";

            // Filas (td)
            for( int i = 0; i < cantidad; i++)
            {
                matriz[i + 1 , 0] = Ordenes[i].GetNumero().ToString();
                matriz[i + 1 , 1] = Ordenes[i].GetCliente();
                matriz[i + 1 , 2] = "Entregado";
                matriz[i + 1 , 3] = Fechas.Formato_Dia_Mes_Anio_Numeros(Ordenes[i].Fecha);
            }

            return matriz;
        }
        

        // Generadores de tablas
        private static string Tabla_Generica
        (string[,] tabla, string HeaderTitle, string CssClass, string Ancho = "50")
        {
            string colspan = tabla.GetLength(1).ToString();
            string code = "";
            string cell;


            //  Start Table...
            //  Define: HeaderTitle, ColSpan and CssClass.
            code += 
                $"<table style='float: left'; class='{CssClass}'>" +
                    $"<tr>"+
                        $"<th colspan='{colspan}' style='width:12cm'> {HeaderTitle} </th>" +
                    $"</tr>";

            
            //  Table body
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                if (i == 0) cell = "th"; else cell = "td";

                code += "<tr>";

                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    code += $"<{cell}> { tabla[i, j] } </{cell}>";
                }

                code += "</tr>";
            }

            //  End..
            code += "</table>";
              

            return code;
        }

        private static string Tabla_StockActualProductos(List<Balde> Lista , int numProduccion)
        {
            string code = "";
            code += "<table style='float: left';>";


            // Titulo tabla
            code +=
            "<tr class='headVerde'>" +
                "<th colspan = '5' style='width:12cm' > Productos </th>" +
            "</tr>";

            // Encabezado Tabla
            code +=
            "<tr class='headVerde2'>" +
                "<th align = 'center' style='width:9cm'> Nombre</th> " +
                "<th align = 'center' style='width:40px'> 20kg </th> " +
                "<th align = 'center' style='width:40px'> 10kg </th> " +
                "<th align = 'center' style='width:40px'> 4kg </th> " +
                "<th align = 'center' style='width:40px'> 1kg </th> " +
            "</tr> ";

            // Filas !
            bool Alternador = false;
            string clase;
            string claseCentered = "centered";
           
            string x20, x10, x4, x1;
            string nombreAnterior = Lista[0].GetNombreCompleto().Substring(0,12);
            string nombre;
            
            foreach (var prod in Lista)
            {

                // Corte !
                nombre = prod.GetNombreCompleto().Substring(0,12);
                if (nombre != nombreAnterior)
                {
                    code += "<tr> <th colspan='5'> </th> </tr>";
                    nombreAnterior = nombre;
                    Alternador = Alternador ? false : true;
                }

                // Clases del CSS
                clase = "celda";
                if (Alternador)
                {
                    clase += "Alt";
                }
                

                x20 = prod.Get20() > 0 ? prod.Get20().ToString() : " ";
                x10 = prod.Get10() > 0 ? prod.Get10().ToString() : " ";
                x4  = prod.Get4()  > 0 ? prod.Get4().ToString()  : " ";
                x1  = prod.Get1()  > 0 ? prod.Get1().ToString()  : " ";


                // Nueva Fila
                code += "<tr>" +
                        $"  <td class='{clase}'>{ prod.GetNombreCompleto() }</td> " +
                        $"  <td class='{clase} {claseCentered}'>{ x20 }</td>" +
                        $"  <td class='{clase} {claseCentered}'>{ x10 }</td>" +
                        $"  <td class='{clase} {claseCentered}'>{ x4  }</td>" +
                        $"  <td class='{clase} {claseCentered}'>{ x1  }</td>" +
                        "</tr>";
            }
            
            // Ultima produccion! )
            code += "<tr>"+
                        "<th colspan='5'> </th>"+
                    "</tr>"+
 
                    "<tr>"+
                        $"<td colspan = '5' class='SubtituloTabla'> Ultima Produccion:<strong> {numProduccion} </strong> </td>" +
                    "</tr>";

            code += "</table>";



                return code;
        }

        private static string Tabla_StockActualMateriaPrima(List<MateriaPrima> Lista)
        {
            var UltimasReposiciones = new List<ReposicionDeStock>(Deserializador.ReposicionesDeStock(6));
            string code = "";

            code +=
            "<table style='float: left';>";

            // Titulo tabla
            code +=
            "<tr class='headVerde'>" +
                "<th colspan = '2' style='width:12cm' > Materia Prima </th>" +
            "</tr>";

            // Encabezado Tabla
            code +=
            "<tr class='headVerde2'>" +
                "<th style='width:10cm'> Nombre </th> " +
                "<th> Kgs. </th > " +
            "</tr> ";


            // Filas !
            int Alternador = 2;
            string nombreClass;
            string stockClass;
            foreach(var mat in Lista)
            {
                // Ex separador de tabla entre BAlDES y MATERIALES
                //if (!mat.EsUnBalde && bandera) { code += "<tr> <th class='col1' colspan='5'> </th> </tr>"; bandera = false; }
                //
                //
                //
                // Seteo las clases CSS
                if (mat.EsUnBalde)  nombreClass = "celdaLetraAzul";
                else  nombreClass = "celda";

                if (mat.Stock < mat.StockMinimo)  stockClass = "stockMinimo";
                else  stockClass = "celda";

                if (Alternador % 2 == 0)
                {
                    nombreClass += "Alt";
                    stockClass += "Alt";
                }
                Alternador++;
                //
                //
                //
                // Nueva fila de tabla codeadaaaa
                if (mat.Nombre != "Agua" && mat.Nombre != "Aguarras" && mat.Nombre != "zMaterial Ficticio" && mat.Nombre != "zMaterial Ficticio 2")
                {
                    code += "<tr>" +
                            $"  <td class='{nombreClass}'>{ mat.Nombre }</td> " +
                            $"  <td class='{stockClass}'>{ Math.Truncate(mat.Stock)  }</td>" +
                            "</tr>";
                }
            }
            //
            // Ultimas Reposiciones
            //
            // subtitulo
            code += 
            "<tr>" +
                "<th colspan='2'> </th>" +
            "</tr> " +
                    
            "<tr>" +
                "<td colspan='2' class='SubtituloTabla' style='border-bottom: hidden;'> Ultimas Reposiciones</td> " +
            "</tr>" +
            
            "<tr>" +
                "<th colspan='2'> </th>" +
            "</tr>";




            // las reposiciones
            foreach (var Repo in UltimasReposiciones)
            {
                string fecha = Fechas.Formato_Dia_Mes(Repo.Fecha);

                code +=
                "<tr>" +
                    $"<td class='SubfilaTabla'><strong>{fecha}</strong>   {Repo.Nombre}</td>" +
                    $"<td class='SubfilaTabla'>{Repo.CantidadIngreso}</td>" +
                "</tr>"; 
            }
            
            code+=
            "<tr>" +    
                "<th colspan='2'> </th>" +
            "</tr>";

            code += "</table>";


            return code;
        }


        // Render (code to .html)
        private static void RenderToHTML(string code)
        {
            var    currentTime = DateTime.Now;
            string rutaInforme = Rutas.DropboxInformesStock();
            string nombreInforme           = @"\Ultimo Stock.html";
            string nombreInformeSecundario = @"\Stock " + Fechas.Formato_Dia_Mes_Anio_Numeros(currentTime) + ".html";

            // Nombre de carpeta para el informe secundiario.
            string nombreCarpeta = @"\" + Fechas.Formato_Mes_Anio(currentTime);

            if (Directory.Exists(rutaInforme))
            {
                //Creo carpeta del mes si no existe. (Archivo secundario)
                if (!Directory.Exists( rutaInforme + nombreCarpeta ))
                {
                    Directory.CreateDirectory(rutaInforme + nombreCarpeta);
                }

                //Creo los Informes
                File.WriteAllText(rutaInforme + nombreInforme, code);
                File.WriteAllText(rutaInforme + nombreCarpeta + nombreInformeSecundario , code);

                //BackUps
                //BackUps.General();
            }
            else
            {
               File.WriteAllText("temps/" + nombreInformeSecundario, code);     
            }
        }

        // Estructura HTML (head, css , body)...
        private static string htmlCodeGenerator(string cssCode, string body, string Titulo)
        {
            string txt =
                "<!DOCTYPE html> " +
                "<html> " +
                "	<head> " +
               $"		<title> { Titulo } </title>" +
               $"       <style type='text/css'>" +
               $"       {cssCode}" +
               $"       </style>" +

                "   </head>" +
                "   <body> " +

                     body +

                "   </body > " +
                "</html >";


            return txt;
        }

        // CSS 
        private static string ReadStockActualCSS()
        {
            string path = "maquetador/InformeStock.css";
            string codecss = File.ReadAllText(path);

            return codecss;
        }

       
    }
}