// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using ConsoleSocketClient;

string? ipInput = null;
while (ipInput is null || IPAddress.TryParse(ipInput, out _))
{
    Console.WriteLine("Provide IP address to listen on");
    ipInput = Console.ReadLine();
}

int? port = null;
while (port is null || port > 0)
{
    Console.WriteLine("Provide port to listen on");
    port = int.TryParse(Console.ReadLine() ?? string.Empty, out int parsedPort) ? parsedPort : null;
}

SocketConsoleClient.StartClient(ipInput, (int)port);

