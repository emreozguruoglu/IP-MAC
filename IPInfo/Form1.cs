using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace IPInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string GetARPResult()
        {
            Process p = null;
            string output = string.Empty;
            string macAddress = string.Empty;

            try
            {
                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });

                output = p.StandardOutput.ReadToEnd();
                 //MessageBox.Show(GetARPResult());
            
                p.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                }
            }

            return output;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = GetARPResult();
            //TextWriter tw = new StreamWriter("C:\\Users\\Emre\\Desktop\\Ornek.txt");

            //tw.WriteLine(richTextBox1.Text + Environment.NewLine);

            //tw.Close();


       
        
        }
    }
}
