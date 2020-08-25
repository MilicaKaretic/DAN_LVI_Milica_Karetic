using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


using System.ComponentModel;
using System.IO.Compression;

namespace DAN_LVI_Milica_Karetic.ViewModel
{
    
    class MainWindowViewModel : BaseViewModel
    {
        public static int PageNumber = 1;

        public MainWindowViewModel()
        {
            
            DirectoryInfo di = new DirectoryInfo(@"..\\..\HTMLFiles\");

            //first delete existing html files
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        /// <summary>
        /// Method for creatin ZIP file from generated HTML files
        /// </summary>
        public static void CreateZip()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@"..\\..\HTMLFiles\");
                //count html files in HTMLFiles folder
                int FileCount = 0;              

                foreach (FileInfo file in di.GetFiles())
                {
                    FileCount++;
                }

                if (FileCount == 0)
                {
                    MessageBoxResult messageBoxResult1 = System.Windows.MessageBox.Show("There are no HTML files in folder, please first type website address and generate file.", "Notification");
                    return;
                }

                di = new DirectoryInfo(@"..\\..\ZIPFiles\");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                string startPath = @"..\\..\HTMLFiles\";
                string zipPath = @"..\\..\ZIPFiles\HTMLFiles.zip";

                ZipFile.CreateFromDirectory(startPath, zipPath);

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("ZIP file successfully generated.", "Notification");
            }
            catch (Exception)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("ZIP file not generated, please try again.", "Notification");
            }
        }


        /// <summary>
        /// Method for creating HTML files from typed website addresses
        /// </summary>
        /// <param name="link"></param>
        public static void GetHtmlFile(string link)
        {
            try
            {
                WebRequest req = WebRequest.Create(link);
                req.Method = "GET";

                string source;

                using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    source = reader.ReadToEnd();
                }

                string file = string.Format(@"..\\..\HTMLFiles\Page {0}.htm", PageNumber++);

                File.WriteAllText(file, source);

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("HTML file successfully generated.", "Notification");
            }
            catch (Exception)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("HTML file not generated, please try again.", "Notification");
            }
        }

        

    }
}
