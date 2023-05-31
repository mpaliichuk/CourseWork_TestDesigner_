using DALTestSystemDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class Form1 : Form
    {
        private const string multicastAddress = "234.5.5.11";
        private const int multicastPort = 7778;
        private const int timeToLive = 32;
        private UdpClient udpClient;
        private bool isRunning = true;
        private List<User> userToInitialize = new List<User>();
        private List<UserTest> userTestToInitialize = new List<UserTest>();
        private List<Test> testForClient = new List<Test>();
        private List<Question> questionForClients = new List<Question>();
        private List<Answer> answersForClients = new List<Answer>();
        private ManualResetEvent dataReceivedEvent = new ManualResetEvent(false);
        private User userToAdd = new User();

        public Form1()
        {
            InitializeComponent();
            InitializeUdpClient();
             udpClient.Client.ReceiveBufferSize = 65536;
            StartListening();
        }

        private void InitializeUdpClient()
        {
            udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, multicastPort));
            udpClient.JoinMulticastGroup(IPAddress.Parse(multicastAddress), timeToLive);
        }

        private async void StartListening()
        {
            await Task.Run(() =>
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, multicastPort);
                while (isRunning)
                {
                    try
                    {
                        byte[] buffer = udpClient.Receive(ref remoteEndPoint);
                        byte[] buffer2 = udpClient.Receive(ref remoteEndPoint);
                        byte[] buffer3 = udpClient.Receive(ref remoteEndPoint);
                        byte[] buffer4 = udpClient.Receive(ref remoteEndPoint);
                        byte[] buffer5 = udpClient.Receive(ref remoteEndPoint);
                        var binaryFormatter = new BinaryFormatter();
                        using (var memoryStream = new MemoryStream(buffer))
                        {
                            userToInitialize = binaryFormatter.Deserialize(memoryStream) as List<User>;
                            
                        }
                        using (var memoryStream = new MemoryStream(buffer2))
                        {
                           
                            

                            userTestToInitialize = binaryFormatter.Deserialize(memoryStream) as List<UserTest>;

                        }
                        using (var memoryStream = new MemoryStream(buffer3))
                        {
                            testForClient = binaryFormatter.Deserialize(memoryStream) as List<Test>;
                            
                        }
                        using (var memoryStream = new MemoryStream(buffer4))
                        {
                            questionForClients = binaryFormatter.Deserialize(memoryStream) as List<Question>;
                        }
                        using (var memoryStream = new MemoryStream(buffer5))
                        {
                            answersForClients = binaryFormatter.Deserialize(memoryStream) as List<Answer>;
                        }

                        // Signal that the data has been received and processed
                        dataReceivedEvent.Set();
                    }
                    catch (SocketException ex)
                    {
                        // Handle the exception if necessary
                        // Log or display the error message
                        Console.WriteLine(ex.Message);
                    }
                }
            });
        }

        // Rest of your code...

        private async void button1_Click(object sender, EventArgs e)
        {
            // Wait until the data has been received and processed
            await Task.Run(() => dataReceivedEvent.WaitOne());

            // Check the login credentials on a separate thread
            bool isCredentialsValid = await Task.Run(() =>
            {
                foreach (var item in userToInitialize)
                {
                    if (textBox1.Text == item.Login && textBox2.Text == item.Password)
                    {
                        return true;
                    }
                }
               
                return false;
            });

            // Update UI based on the result on the UI thread
            if (isCredentialsValid)
            {
             
                foreach (var item in userToInitialize)
                {
                    if (textBox1.Text == item.Login && textBox2.Text == item.Password)
                    {
                        userToAdd = item;
                        break;
                    }
                    
                }
                User toTest = new User();
              //  UserTest tests = (UserTest)toTest.UserTests;
                
                TestsForClient testsForClient = new TestsForClient(testForClient[1], userToAdd, userTestToInitialize,questionForClients,answersForClients);
                testsForClient.ShowDialog();
            }
            else
            {
                label3.Text = "Incorrect login or password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}