using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Xml;
using System.Timers;




namespace IndicatorMagic2
{
    public partial class Form1 : Form, Output_Interface
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        Actions actions;
        delegate void writeToLogCallback(String Text, String Mode);
        delegate void setTextCallBack(string text);
        public Form1()
        {
            actions = new Actions(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Writes output to text file and the screen
        public void writeToLog(string s)
        {
            setText(s + "\n");
        }

        /// <summary>
        /// Used to marshal the thread for the form to allow thread to access the text box on the form
        /// </summary>
        /// <param name="text">String to print to richTextBox1</param>
        public void setText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                setTextCallBack d = new setTextCallBack(setText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
                richTextBox1.ScrollToCaret();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actions.do_things();
            actions.Http_Client_Get("http://google.com/", "my ponies","en-us");
            actions.Dns_Request("blah.com");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            dlg.ShowDialog();
            txtbx_xml_filepath.Text = dlg.FileName;
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            setText("Begin process!, if you selected repeat ever X seconds, the process will begin in that many seconds\n");
            //This will handle the function to repeat every X seconds
            if (chkbx_repeat.Checked == true)
            {
                
                int milliseconds = Convert.ToInt32(txtbx_seconds.Text) * 1000;
                aTimer.Interval = milliseconds;
                aTimer.Enabled = true;
                aTimer.Elapsed += new ElapsedEventHandler(go_xml);
                GC.KeepAlive(aTimer);
            } else
            {
                XmlReader reader = XmlFunctions.openXml(txtbx_xml_filepath.Text);
                XmlFunctions.executeXml(reader, actions);
            }
        }
        /// <summary>
        /// This is the function that will be added to the timer for repeating tasks
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void go_xml(object source, ElapsedEventArgs e)
        {
            XmlReader reader;
            reader = XmlFunctions.openXml(txtbx_xml_filepath.Text);
            XmlFunctions.executeXml(reader, actions);
        }
        /// <summary>
        /// This will stop the timer for the repeating tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_stop_Click(object sender, EventArgs e)
        {
            aTimer.Enabled = false;
        }
    }
}
