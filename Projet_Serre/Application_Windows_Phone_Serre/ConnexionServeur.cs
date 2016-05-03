using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Networking;



namespace Application_Windows_Phone_Serre
{
    class ConnexionServeur
    {

        StreamSocket socket;

        public async Task connect(string host, string port, string message)
        {
            HostName hostName;

            using (socket = new StreamSocket())
            {
                hostName = new HostName(host);

                socket.Control.NoDelay = false;

                try
                {
                    await socket.ConnectAsync(hostName, port);
                    await this.send(message);
                    await this.read();
                }
                catch (Exception exception)
                {
                    switch (SocketError.GetStatus(exception.HResult))
                    {
                        case SocketErrorStatus.HostNotFound:
                            throw;
                        default:
                            throw;
                    }
                }
            }
        }

        public async Task send(string message)
        {
            DataWriter writer;

            using (writer = new DataWriter(socket.OutputStream))
            {
                writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                writer.ByteOrder = Windows.Storage.Streams.ByteOrder.LittleEndian;

                writer.MeasureString(message);
                writer.WriteString(message);

                try
                {
                    await writer.StoreAsync();
                }
                catch (Exception exception)
                {
                    switch (SocketError.GetStatus(exception.HResult))
                    {
                        case SocketErrorStatus.HostNotFound:
                            throw;
                        default:
                            throw;
                    }
                }

                await writer.FlushAsync();
                writer.DetachStream();
            }
        }

        public async Task<String> read() 
        {
            DataReader reader;
            StringBuilder strBuilder;

            using (reader = new DataReader(socket.InputStream))
            {
                strBuilder = new StringBuilder();

                reader.InputStreamOptions = Windows.Storage.Streams.InputStreamOptions.Partial;
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                reader.ByteOrder = Windows.Storage.Streams.ByteOrder.LittleEndian;

                await reader.LoadAsync(256);

                while (reader.UnconsumedBufferLength > 0)
                {
                    strBuilder.Append(reader.ReadString(reader.UnconsumedBufferLength));
                    await reader.LoadAsync(256);
                }

                reader.DetachStream();
                return strBuilder.ToString();
            }
        }
    }
}
