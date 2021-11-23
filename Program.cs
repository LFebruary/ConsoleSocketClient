using System.Net;
using System.Net.Sockets;
using System.Text;

StartClient();

void StartClient()
{
    string? input = string.Empty;

    do
    {
        byte[] bytes = new byte[1024];

        try
        {
            //IPHostEntry host = Dns.GetHostEntry("192.168.1.37");
            IPAddress ipAddress = IPAddress.Parse("169.254.124.109");
            IPEndPoint remoteEP = new(ipAddress, 5050);

            Socket receiver = new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                receiver.Connect(remoteEP);

                Console.WriteLine($"Socket connected to {receiver.RemoteEndPoint}");

                int bytesRec = receiver.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
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
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
    while (string.IsNullOrWhiteSpace(input) && input != "Exit");
    
}