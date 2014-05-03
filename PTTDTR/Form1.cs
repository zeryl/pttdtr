using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTTDTR
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in theSerialPortNames)
            {
                this.listBox1.Items.Add(port);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comport = this.listBox1.SelectedItem.ToString();

            if (port.IsOpen)
            {
                port.Close();
            }

            port = new SerialPort(comport);
            try
            {
                port.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open port " + comport + ".  Please make sure it is not in use!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (port.DtrEnable)
            {
                port.DtrEnable = false;
                this.label1.Text = "Off";
            }
            else
            {
                port.DtrEnable = true;
                this.label1.Text = "On";
            }
        }

        private void ptt_event_handler_down(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                port.DtrEnable = true;
                this.label1.Text = "On";
            }
        }

        private void ptt_event_handler_up(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                port.DtrEnable = false;
                this.label1.Text = "Off";
            }
        }
    }
}
