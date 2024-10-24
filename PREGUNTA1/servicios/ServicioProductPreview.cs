using PREGUNTA1.dao;
using PREGUNTA1.dao.daomlp;
using PREGUNTA1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PREGUNTA1.servicios
{
    public class ServicioProductPreview
    {
        // PROCESAR TODAS LAS OPERACIONES INSERT, CREATE, DELETE
        public int operacionesGenerales(string indicador, productPreview c)
        {
            IProductoPreviewDao dao = new ProductPreviewImlp();
            return dao.operacionesGenerales(indicador, c);
        }

        //SE REALIZARAN LAS CONSULTAS DE DATOS
        public List<productPreview> operacioneslectura(string indicador, int ProductReviewID)
        {
            IProductoPreviewDao dao = new ProductPreviewImlp();
            return dao.operacioneslectura(indicador, ProductReviewID);
        }
    }
}