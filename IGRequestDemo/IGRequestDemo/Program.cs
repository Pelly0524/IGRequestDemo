using com.lightstreamer.client;
using IGRequestDemo;
using IGRequestDemo.Models.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

Console.WriteLine("Start connecting. Press Enter to exit...");

string account = "account";
string password = "password";

// Login
var restApiClient = new RestApiClient();
var loginResponse = await restApiClient.Login(account, password);

// SocketConnect
StreamingApiClient streamingApiClient = new StreamingApiClient(loginResponse.LightstreamerEndpoint);
await streamingApiClient.Connect(account, loginResponse.cst, loginResponse.xSecurityToken);

// SubscribeMarket
var epics = new List<string>() { "IX.D.SUNNAS.BMU.IP" };
streamingApiClient.SubscribeMarket(epics);

Console.WriteLine("\nPress Enter to disconnect\n");
Console.ReadLine();

// Disconnect
streamingApiClient.Disconnect();

Console.ReadLine();