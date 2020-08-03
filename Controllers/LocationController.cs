using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using xmlMVC.Models;

namespace xmlMVC.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            List<Location> Locations = new List<Location>();
            string xmlUrl = "https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-A0012-001?Authorization=CWB-BC2E6A08-130F-4DCA-B26C-8E5ADF09F133&downloadType=WEB&format=XML";
            //拔名稱空間
            XmlTextReader reader = new XmlTextReader(xmlUrl);
            reader.Namespaces = false;
            XmlDocument xml = new XmlDocument();
            xml.Load(reader);

            //string Wx = "";
            //string WindDir = "";
            //string WindSpeed = "";
            //string WaveHeight = "";

            //string[] wx=new string[5];
            //string[] windDir = new string[5];
            //string[] windSpeed= new string[5];
            //string[] waveHeight = new string[5];

            XmlNodeList locationList = xml.SelectNodes("//cwbopendata/dataset/location");

            foreach (XmlNode locationNode in locationList)//進入location
            {
                string locationname = "";
                locationname = locationNode["locationName"].InnerText;
                //data.LocationName = locationNode["locationName"].InnerText;
                XmlElement weatherElement = (XmlElement)locationNode;
                XmlNodeList weatherList = weatherElement.ChildNodes;

                foreach (XmlNode weatherNode in weatherList)
                {
                    if (weatherNode.Name == "weatherElement")//進入weatherElement
                    {
                        XmlElement WxElement = (XmlElement)weatherNode;
                        XmlNodeList WxList = WxElement.ChildNodes;

                        foreach (XmlNode WxNode in WxList)
                        {
                            Location data = new Location();
                            data.LocationName = locationname;

                            if (WxNode.Name == "time")//進入time
                            {
                                #region old
                                
                                XmlElement timeElement = (XmlElement)WxNode;
                                XmlNodeList timeList = timeElement.ChildNodes;

                                
                                foreach (XmlNode timeNode in timeList)
                                {
                                    
                                    if (timeNode.Name == "startTime")
                                    {
                                        data.StartTime = timeNode.InnerText;
                                    }
                                    else if (timeNode.Name == "endTime")
                                    {
                                        data.EndTime = timeNode.InnerText;
                                    }
                                    
                                    else
                                    {                                        
                                        if (WxList[0].InnerText == "Wx")
                                        {
                                            data.Wx = timeNode.ChildNodes[0].InnerText;
                                            Locations.Add(data);
                                            //Wx = timeNode.ChildNodes[0].InnerText;
                                        }
                                        else if (WxList[0].InnerText == "WindDir")
                                        {
                                            data.WindDir = timeNode.ChildNodes[0].InnerText;
                                            Locations.Add(data);
                                            //WindDir = timeNode.ChildNodes[0].InnerText;
                                        }
                                        else if (WxList[0].InnerText == "WindSpeed")
                                        {
                                            data.WindSpeed = timeNode.ChildNodes[0].InnerText;
                                            Locations.Add(data);
                                            //WindSpeed = timeNode.ChildNodes[0].InnerText;
                                        }
                                        else if (WxList[0].InnerText == "WaveHeight")
                                        {
                                            data.WaveHeight = timeNode.ChildNodes[0].InnerText;
                                            Locations.Add(data);
                                            //WaveHeight = timeNode.ChildNodes[0].InnerText;
                                        }
                                        else
                                        {
                                            //data.Wx = Wx;
                                            //data.WindDir = WindDir;
                                            //data.WindSpeed = WindSpeed;
                                            //data.WaveHeight = WaveHeight;
                                            data.WaveType = timeNode.ChildNodes[0].InnerText;
                                            Locations.Add(data);
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }

            ViewBag.allData = Locations;
            
            return View();
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
