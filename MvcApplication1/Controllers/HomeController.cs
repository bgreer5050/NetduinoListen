using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
       

            public HomeController()
            {

            }

            public ActionResult Index()
            {

                MachineEvent _event = new MachineEvent();
                _event.assetID = "94200";
                _event.state = "RUNNING";
                _event.ticks = DateTime.Now.Ticks.ToString();
               

                context db = new context();
                db.machineEvents.Add(_event);
                db.SaveChanges();



                return Json(_event, JsonRequestBehavior.AllowGet);



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

                            return Json(ex.ToString());
                        }


                    }
                    else
                    {
                        return Json(0);
                    }
                }
                catch (Exception ex)
                {
                    return Json(ex.ToString());

                }

            }


          public ActionResult X()
            {
                return Json("here i am");
            }

            public ActionResult PostMachineEvent2(string assetID, string state, string ticks)
            {
                try
                {
                    if (assetID != null && state != null && ticks != null)
                    {
                        MachineEvent _mEvent = new MachineEvent();
                        _mEvent.assetID = assetID;
                        _mEvent.state = state;
                        _mEvent.ticks = ticks;

                        //context db = new context();
                        //db.machineEvents.Add(_mEvent);
                        //db.SaveChanges();

                        Random rnd = new Random(600000);
                        string recordID = rnd.NextDouble().ToString();
                        return Json(recordID);
                    }
                    else
                    {
                        return Json("-1");

                    }
                    
                }
                catch (Exception ex)
                {
                    return Json(ex.ToString());

                }

            }


        public ActionResult GetSettings(string MACAddress)
        {
            DeviceConfiguration dc = new DeviceConfiguration();

            switch(MACAddress)
            {
                case "5C864A01124D":
                    dc.macAddress = MACAddress;
                    break;

                case "111111111111":
                    dc.macAddress = MACAddress;
                    break;

                case "222222222222":
                    dc.macAddress = MACAddress;
                    break;

                case "5C864A011246":
                    dc.macAddress = MACAddress;
                    break;

                default:
                    return Json(null,JsonRequestBehavior.AllowGet);
            }

            dc.assetNumber = "9999";
            dc.checkinIntervalMs = "100000";
            dc.cycleLengthMs = "3000";
            dc.enabled = "Y";
            dc.firmware = "4.3";
            dc.heartbeatsRequiredToChangeState = "2";
            dc.ipAddress = "10.0.0.121";
            dc.lastCheckin = "true";
            dc.modelNumber = "Netduino Plus 2";
            dc.ntpServer = "time.nist.gov";
            dc.revision = "A";
            dc.softwareHash = "Unknown";

            return Json(dc,JsonRequestBehavior.AllowGet);
            

        }
       
    }

    public class DeviceConfiguration
    {
        public string assetNumber { get; set; }
        public string checkinIntervalMs { get; set; }
        public string cycleLengthMs { get; set; }
        public string enabled { get; set; }
        public string firmware { get; set; }
        public string heartbeatsRequiredToChangeState { get; set; }
        public string ipAddress { get; set; }
        public string lastCheckin { get; set; }  //true or false string
        public string macAddress { get; set; }
        public string modelNumber { get; set; }
        public string ntpServer { get; set; }
        public string revision { get; set; }
        public string softwareHash { get; set; }



    }

}

