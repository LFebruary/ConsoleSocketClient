// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleSocketClient
{
    public static class SocketConsoleClient
    {
        /// <summary>
        /// Initiates the client connection process.
        /// </summary>
        /// <param name="ipAddressInput">The IP address to connect to.</param>
        /// <param name="portInput">The port number to connect to.</param>
        public static void StartClient(string ipAddressInput, int portInput)
        {
            string? input = string.Empty;

            do
            {
                byte[] bytes = new byte[1024];

                try
                {
                    // Connection setup
                    IPAddress ipAddress = IPAddress.Parse(ipAddressInput);
                    IPEndPoint remoteEP = new(ipAddress, portInput);
                    Socket receiver = new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    // Connection establishment
                    EstablishConnection(receiver, remoteEP);

                    // Data reception
                    ReceiveData(receiver, bytes);
                }
                catch (Exception e)
                {
                    HandleException(e);
                }
            } while (string.IsNullOrWhiteSpace(input) && input != "Exit");
        }

        /// <summary>
        /// Establishes the connection with the server.
        /// </summary>
        /// <param name="receiver">The Socket object for communication.</param>
        /// <param name="remoteEP">The remote endpoint to connect to.</param>
        private static void EstablishConnection(Socket receiver, IPEndPoint remoteEP)
        {
            try
            {
                receiver.Connect(remoteEP);
                Console.WriteLine($"Socket connected to {receiver.RemoteEndPoint}");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                HandleSocketException(se);
            }
        }

        /// <summary>
        /// Receives data from the server.
        /// </summary>
        /// <param name="receiver">The Socket object for communication.</param>
        /// <param name="bytes">The buffer to store received data.</param>
        private static void ReceiveData(Socket receiver, byte[] bytes)
        {
            try
            {
                int bytesRec = receiver.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        /// <summary>
        /// Handles socket-related exceptions.
        /// </summary>
        /// <param name="se">The SocketException to handle.</param>
        private static void HandleSocketException(SocketException se)
        {
            if (se.ErrorCode == 10054 || se.ErrorCode == 10061)
            {
                Console.WriteLine("Server is currently offline.\nPress any key to retry");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
        }

        /// <summary>
        /// Handles general exceptions.
        /// </summary>
        /// <param name="e">The Exception to handle.</param>
        private static void HandleException(Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e.ToString());
        }
    }
}
