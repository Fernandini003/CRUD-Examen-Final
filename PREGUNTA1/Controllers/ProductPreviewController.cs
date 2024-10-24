using PREGUNTA1.Models;
using PREGUNTA1.servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;         
using System.Web.Mvc;



namespace PREGUNTA1.Controllers
{
    public class ProductPreviewController : Controller
    {
        [HttpGet]
        public ActionResult Crear()
        {
            return View(new productPreview());
        }

        [HttpPost]
        public ActionResult Crear(productPreview objPrd)
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            int procesar = servicio.operacionesGenerales("Insertar", objPrd);
            if (procesar >= 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            List<productPreview> lista = servicio.operacioneslectura("consultar_todo", 0);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int ProductReviewID)
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            List<productPreview> lista = servicio.operacioneslectura("consultar_por_id", ProductReviewID);
            return View(lista.First());
        }
        [HttpPost]
        public ActionResult Editar(productPreview c)
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            try
            {
                int procesar = servicio.operacionesGenerales("Actualizar", c);
                if (procesar > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return View(c);
        }


        [HttpGet]
        public ActionResult Detalles (int ProductReviewID)
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            List<productPreview> lista = servicio.operacioneslectura("consultar_por_id", ProductReviewID);
            return View(lista.First());
        }


        [HttpGet]
        public ActionResult Eliminar(int ProductReviewID)
        {
            ServicioProductPreview servicio = new ServicioProductPreview();
            List<productPreview> lista = servicio.operacioneslectura("consultar_por_id", ProductReviewID);
            return View(lista.First());
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult Eliminar_Confirmar(int ProductReviewID)
        {
            Debug.WriteLine("Codigo : " + ProductReviewID);
            ServicioProductPreview servicio = new ServicioProductPreview();
            productPreview prd = new productPreview();
            prd.ProductReviewID = ProductReviewID;
            prd.ProductID = 0;
            prd.ReviewerName = "";
            prd.ReviewDate = new DateTime(2024, 10, 23);
            prd.EmailAddress = "";
            prd.Rating = 0;
            prd.Comments = "";
            prd.ModifiedDate = new DateTime(2024, 10, 23);

            int procesar = servicio.operacionesGenerales("Eliminar", prd);
            if (procesar >= 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}