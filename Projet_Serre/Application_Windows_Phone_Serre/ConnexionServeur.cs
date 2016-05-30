using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Networking;
using Newtonsoft.Json;
using Windows.Web.Http;



namespace Application_Windows_Phone_Serre
{
    class ConnexionServeur
    {
        HttpClient httpc = new HttpClient();

        public async void LoadDataProfil()
        {
            HttpResponseMessage reponse = await httpc.GetAsync(new Uri("http://localhost:37768/api/Profil"));
            var temp = reponse.Content;
            
        }

        public async void LoadDataReglage(int idProfil)
        {
            HttpResponseMessage reponse = await httpc.GetAsync(new Uri("http://localhost:37768/api/Reglage"));
            var temp = reponse.Content;

        }

        public async void LoadDataProfilActuel()
        {
            HttpResponseMessage reponse = await httpc.GetAsync(new Uri("http://localhost:37768/api/ProfilActuel"));
            var temp = reponse.Content;
        }

        public async void LoadDataCapteur()
        {
            HttpResponseMessage reponse = await httpc.GetAsync(new Uri("http://localhost:37768/api/Capteur"));
            var temp = reponse.Content;
        }

        /*
        public async void SendDataProfilActuel()
        {
            
        }
        */


































        /*
         
        StreamSocket socket;
        String ipServeur = "192.02.01.01";
        String portServeur = "88";
        String message = "Je suis le Client";


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
    */
    }
}
