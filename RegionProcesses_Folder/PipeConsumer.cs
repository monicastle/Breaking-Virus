using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class Consumer{
    static object monitor = new object();

    static void Main(string[] args){
        string pipeName = "myPipe";
        string forwardPipeName = "forwardPipe";

        while (true){
            try{
                using (var pipeReader = new NamedPipeServerStream(pipeName, PipeDirection.In)){
                    pipeReader.WaitForConnection();
                    var buffer = new byte[1024];

                    Monitor.Enter(monitor); // acquire the monitor lock
                    pipeReader.Read(buffer, 0, buffer.Length);
                    var data = Encoding.UTF8.GetString(buffer).Trim('\0');
                    Console.WriteLine("Consumed: {0}", data);
                    Monitor.Exit(monitor); // release the monitor lock


                    // Forward data to server process
                    using (var forwardPipe = new NamedPipeClientStream(".", forwardPipeName, PipeDirection.Out)){
                        forwardPipe.Connect();
                        var forwardBuffer = Encoding.UTF8.GetBytes(data);
                        forwardPipe.Write(forwardBuffer, 0, forwardBuffer.Length);
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine("Consumer error: {0}", ex.Message);
            }
        }
    }
}
