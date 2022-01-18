using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeHomeTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            try
            {
                string input = tbxInput.Text;
                if (!TwitterString.checkInput(input))
                {
                    MessageBox.Show("Input not in correct format.");
                    return;
                }
                TwitterString twitter = new TwitterString(input);
                StringBuilder html = twitter.convertToHtml();
                twitter.PrintReport(html);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog1.InitialDirectory = @path + "\\HtmlOutput\\";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var onlyFileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                    System.Diagnostics.Process.Start(@path + "\\HtmlOutput\\" + onlyFileName); //Open the report in the default web browser

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Tests test = new Tests();
            string test1 = test.test1;
            string test2 = test.test2;
            string test3 = test.test3;
            string test4 = test.test4;
            TwitterString twitter = new TwitterString(test1);
            TwitterString twitter1 = new TwitterString(test2);
            TwitterString twitter2 = new TwitterString(test3);
            TwitterString twitter3 = new TwitterString(test4);
            StringBuilder html = twitter.convertToHtml();
            twitter.PrintReport(html);
            StringBuilder html1 = twitter1.convertToHtml();
            twitter1.PrintReport(html1);
            StringBuilder html2 = twitter2.convertToHtml();
            twitter2.PrintReport(html2);
            StringBuilder html3 = twitter3.convertToHtml();
            twitter3.PrintReport(html3);
        }
    }
}
