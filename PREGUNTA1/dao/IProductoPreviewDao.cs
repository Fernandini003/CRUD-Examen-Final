using PREGUNTA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PREGUNTA1.dao
{
    internal interface IProductoPreviewDao
    {
        // PROCESAR TODAS LAS OPERACIONES INSERT, CREATE, DELETE
        int operacionesGenerales(string indicador, productPreview c);

        //SE REALIZARAN LAS CONSULTAS DE DATOS
        List<productPreview> operacioneslectura(string indicador, int IdCitas);
    }
}
