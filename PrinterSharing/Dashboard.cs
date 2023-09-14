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

using System.Diagnostics;
using System.Security.Principal;

namespace PrinterSharing
{
    public partial class Dashboard : Form
    {
        public Dashboard()
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
                LocalPrinterListView.Columns[0].Width = columnWidth + 100;
                LocalPrinterListView.Columns[1].Width = columnWidth - 40;
                LocalPrinterListView.Columns[2].Width = columnWidth - 70;
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


        private void btnSharePrinter_Click(object sender, EventArgs e)
        {
            string printerName = "YourPrinterName"; // Replace with the actual name of your printer

            // Check if the user has administrative privileges
            if (!IsUserAdministrator())
            {
                stsLabel.Text = "Administrator rights required to share the printer.";
                return;
            }

            // Enable printer sharing using the "net share" command
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            process.Start();

            // Run the "net share" command to share the printer
            string command = "";
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");

            process.WaitForExit();
            
            // Check the exit code to see if sharing was successful
            if (process.ExitCode == 0)
            {
                stsLabel.Text = "Printer '{printerName}' is now shared.";
            }
            else
            {
                stsLabel.Text = "Failed to share printer '{printerName}'.";
            }
        }

        // Check if the user has administrative privileges
        private bool IsUserAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


    }
    
}
