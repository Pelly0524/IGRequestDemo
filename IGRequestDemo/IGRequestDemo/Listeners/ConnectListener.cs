using com.lightstreamer.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Listeners
{
    public class ConnectListener : ClientListener
    {
        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();
        private bool _isCompleted = false;

        public Task ConnectionTask => _tcs.Task;

        void ClientListener.onListenEnd(LightstreamerClient client)
        {
            Console.WriteLine("Listening ended.");
        }

        void ClientListener.onListenStart(LightstreamerClient client)
        {
            Console.WriteLine("Listening started.");
        }

        void ClientListener.onServerError(int errorCode, string errorMessage)
        {
            Console.WriteLine($"Server Error (from explicit interface): Code = {errorCode}, Message = {errorMessage}");
        }

        void ClientListener.onStatusChange(string status)
        {
            Console.WriteLine($"Connection Status (from explicit interface): {status}");
            if (status == "CONNECTED:WS-STREAMING" && !_isCompleted)
            {
                _tcs.SetResult(true);
                _isCompleted = true;
                Console.WriteLine("Connected Successfully!");
            }
            else if (status.StartsWith("DISCONNECTED") && !_isCompleted)
            {
                _tcs.SetException(new Exception("Failed to connect to Lightstreamer"));
                _isCompleted = true;
            }
        }

        void ClientListener.onPropertyChange(string property)
        {
            Console.WriteLine($"Property Changed: {property}");
        }
    }
}