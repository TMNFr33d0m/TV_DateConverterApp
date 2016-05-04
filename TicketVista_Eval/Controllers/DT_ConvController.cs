using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketVista_Eval.Models;

namespace TicketVista_Eval.Controllers
{
    public class DT_ConvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DT_Conv
         public ActionResult Convert()
        {
            return View();
        }

        // Overload handler for "Convert" 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Convert([Bind(Include = "DTKey,LocalTimeField")] DT_Conv dT_Conv)
        {
            // Check is input is valid for type defined in Model 
            if (ModelState.IsValid)
            {
                // If it is, tell the user he is waiting for a response..
                ViewBag.Status = "Waiting for response...";

                // Perform conversion, pushing DateTime entered to the appropriate string type 
                DateTime DateToConvert = dT_Conv.LocalTimeField.ToUniversalTime();
                string ConvertedDate = DateToConvert.ToLongDateString();
                string ConvertedTime = DateToConvert.ToLongTimeString();

                // Print converted results to view. 
                ViewBag.Result = (dT_Conv.LocalTimeField + " Local Time is "+ConvertedDate + " " + ConvertedTime+" UTC");

                // Indicate to the user that the operation is complete. 
                ViewBag.Status = "Submission Converted!";


            }
            else
            {
               // Show user invalid message...
                ViewBag.Result = ("An invalid date format was used.");
                ViewBag.Status = "Submission Failed!";
            }
            // Return view for ActionResult 
            return View(dT_Conv);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
