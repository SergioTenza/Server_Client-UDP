using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Client_UDP
{
    public partial class Server_Main : Form
    {
        UDPSocket s;
        UDPSocket c;


        public Server_Main()
        {
            InitializeComponent();
            try
            {
                s = new UDPSocket();
                s.Server("127.0.0.1", 28450);
                textBox1.AppendText("Servidor iniciado en:"+Environment.NewLine+"IP: 127.0.0.1" + Environment.NewLine + "PORT: 28450" + Environment.NewLine); 

            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            c = new UDPSocket();
            c.Client("127.0.0.1", 28450);
            if (textBox2.Text != "")
            {
                c.Send(textBox2.Text);
                textBox1.AppendText(textBox2.Text + Environment.NewLine);
            }
            else
            {
                c.Send("TEST!");
                textBox1.AppendText("TEST!" + Environment.NewLine);
            }            
        }
        public void Server_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            s._socket.Close();
        }
    }
}
