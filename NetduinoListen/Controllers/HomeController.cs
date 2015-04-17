using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;


namespace NetduinoListen.Controllers
{
    public class HomeController : Controller
    {

        private static readonly ILog logger =
    LogManager.GetLogger(typeof(HomeController));


        public HomeController()
        {
            DOMConfigurator.Configure();
        }

        public ActionResult Index()
        {

            MachineEvent _event = new MachineEvent();
            _event.MachineID = 94200;
            _event.numberOfBeatsSinceLastChange = 100;
            _event.systemState = 1;
            _event.timeOfEvent = DateTime.Now;
            _event.timeOfLastStateChange = DateTime.Now;


            return Json(_event,JsonRequestBehavior.AllowGet);

         

        }

        public ActionResult PostMachineEvent(MachineEvent machineEvent)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    try
                    {
                        context db = new context();
                        db.machineEvents.Add(machineEvent);
                        db.SaveChanges();
                        return Json(1);
                    }
                    catch (Exception ex)
                    {

                        return Json(0);
                    }

                   
                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
                return Json(ex.Message);

            }

        }

        //public ActionResult PostMachineEvent()
        //{

        //    return Json(1);


        //}

    
    }

    public class MachineEvent
    {
        public int MachineID { get; set; }
        public DateTime timeOfEvent { get; set; }
        public DateTime timeOfLastStateChange { get; set; }
        public long numberOfBeatsSinceLastChange { get; set; }
        public int systemState { get; set; }

    }
}
