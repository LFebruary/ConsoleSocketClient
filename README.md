### Program Description:

This C# program establishes a client connection to a specified IP address and port. It continuously prompts the user for an IP address and port number until valid inputs are provided. Once connected, it listens for incoming data from the server and displays it to the console.

### Requirements:

- .NET Framework or .NET Core SDK installed
- Basic understanding of TCP/IP networking

### Instructions:

1. Run the program.
2. Provide the IP address and port number to connect to.
3. Wait for incoming data from the server.
4. Optionally, type "Exit" to terminate the program.

### Code Overview:

- The program prompts the user to provide an IP address and port number.
- It establishes a TCP connection with the specified IP address and port.
- Upon successful connection, it receives data from the server and displays it.
- It handles exceptions gracefully and provides appropriate error messages.
- The program continues to run until the user types "Exit" or encounters an error.

### Code Improvements:

- Encapsulate socket operations within a class for better organization.
- Implement asynchronous socket operations for improved performance and responsiveness.
- Add input validation to ensure the correctness of user-provided IP addresses and port numbers.
- Consider implementing logging for better error tracking and debugging.

Feel free to enhance and customize the program according to your specific requirements and use case.
