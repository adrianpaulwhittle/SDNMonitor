using System;
using System.Threading;
using System.Xml;

namespace AML.SDNMonitorTest
{
    class SDNMonitorTest
    {
        static void Main(string[] args)
        {
            //XML file to be monitored
            string SDNFileName = "https://www.treasury.gov/ofac/downloads/sdn.xml";

            XmlDocument originalXML = new XmlDocument();
            XmlDocument currentXML = new XmlDocument();

            bool exit = false;

            //Load XML document to monitor for changes
            originalXML.Load(SDNFileName);

            while (exit == false)
            {
                //Check every minute
                Thread.Sleep(60000);
                //I am aware Thread.Sleep is not regarded as a good method
                //With more time, a service with a timer would be a better solution

                currentXML.Load(SDNFileName);

                //Compare current XML with XML on start of application
                if (originalXML.OuterXml != currentXML.OuterXml)
                {
                    //Write message to the console
                    //Obviously I would want this application to run silently in the background
                    //and have a more sophisticated way of indicating a change to the user than
                    //writing to console, but this is always a good start
                    Console.WriteLine("SDN list has changed");
                    Console.WriteLine("Press any key to exit");

                    Console.ReadKey();

                    //A obvious improvement would be the ability to detect more than 1 change,
                    //but this demonstrates the concept
                    exit = true;
                }
            }
        }
    }
}
