using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace RX
{
    public partial class RX : Form
    {
        public RX()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                button1.Text = "Connect";
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Text = "Disonnect";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }
        /*  int i = 0;
          List<byte> l = new List<byte>();
          private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
          {
              while (serialPort1.BytesToRead > 0)
              {
                  l.Add((byte)serialPort1.ReadByte());
                  i++;
                  label1.Text = i.ToString();
                  label2.Text = serialPort1.BytesToRead.ToString(); 
              }
          } 

          private void button3_Click(object sender, EventArgs e)
          {
              byte[] b = l.ToArray();
              FileStream fs = new FileStream(textBox1.Text, FileMode.Create);
              fs.Write(b, 0, b.Length);
              fs.Close();
              i = 0;
              l.Clear();
          }*/
        int i = 0;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            FileStream fs = new FileStream(textBox1.Text, FileMode.Append);
            
            while (serialPort1.BytesToRead > 0)
            {
                byte[] b = new byte[serialPort1.BytesToRead];
                serialPort1.Read(b, 0, b.Length);
                fs.Write(b, 0, b.Length);
                i += b.Length;
            }
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = int.Parse(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
