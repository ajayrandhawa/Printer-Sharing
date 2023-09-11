using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Management;

namespace PrinterSharing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Create columns for the ListView
            LocalPrinterListView.Columns.Add("Printer");
            LocalPrinterListView.Columns.Add("Sharing");
            LocalPrinterListView.Columns.Add("Status");

            LocalPrinterListView.View = View.Details;

            int totalWidth = LocalPrinterListView.Width;
            int columnWidth = totalWidth / 3; // 33% of the total width

            // Assuming you want to set the width of the first column to 33%
            if (LocalPrinterListView.Columns.Count > 0)
            {
                LocalPrinterListView.Columns[0].Width = columnWidth;
                LocalPrinterListView.Columns[1].Width = columnWidth;
                LocalPrinterListView.Columns[2].Width = columnWidth - 5;
            }

            // Add the list of printers to a ListBox control
            // Get the list of installed local printers
            string[] printerList = PrinterSettings.InstalledPrinters.Cast<string>().ToArray();

            // Add the list of printers to the ListView
            foreach (string printerName in printerList)
            {

                // Check if the printer is shared
                string sharingStatus = IsPrinterShared(printerName) ? "Shared" : "Not Shared";
                string status = GetPrinterStatus(printerName);

                ListViewItem printerItem = new ListViewItem(printerName);
                printerItem.SubItems.Add(sharingStatus);
                printerItem.SubItems.Add(status);
                LocalPrinterListView.Items.Add(printerItem);
            };
        }


        private bool IsPrinterShared(string printerName)
        {
            bool isShared = false;
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    string name = printer["Name"].ToString();
                    if (name == printerName)
                    {
                        isShared = Convert.ToBoolean(printer["Shared"]);
                        break;
                    }
                }
            }
            return isShared;
        }


        private string GetPrinterStatus(string printerName)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer"))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    string name = printer["Name"].ToString();
                    if (name == printerName)
                    {
                        int status = Convert.ToInt32(printer["PrinterStatus"]);
                        if (status == 3) // Printer is idle
                        {
                            return "Online";
                        }
                    }
                }
            }
            return "Offline";
        }


    }
    
}
