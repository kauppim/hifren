/*
 * This class owes it's existance to the ZeroMQ Guide and the examples by metadings.
 * ZeroMQ guide:      http://zguide.zeromq.org/page:all#toc10
 * metadings samples: https://github.com/booksbyus/zguide/tree/master/examples/C%23
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using ZeroMQ;

namespace Hifren
{
    public static partial class Hifrend
    {
        /// <summary>
        /// Initiate a Hifrend service instance.
        /// 
        /// This should take as parameters also the tcp port id, to which this service will be bound to.
        /// </summary>
        /// <param name="name">Name of this server instance</param>
        public static void MsgServer(string name)
        {
            // int requestCount : This is for testing purposes only, remove when finished with testing
            int requestCount = 0;

            // add a list for client objects : holds information about addresses and such
            // add a list for group/channel objects : holds information about channel modes and their participants
            // add a FIFO queue for messages to be sent

            using (var context = new ZContext())
            using (var responder = new ZSocket(context, ZSocketType.REP))
            {
                // Check what can be defined during runtime in the Bind method.
                responder.Bind("tcp://*:5555");

                while (true)
                {
                    /*
                     * Receive request
                     * 
                     * In the future, what this loop should do is:
                     * 1. Receive a string request of the format: "<sender> <command> <parameters>", eg. "leakim MSG #group1 Hello World"
                     * 2a. Parse the command (add a separate parser)
                     * 2b. If there was a message to be sent, send that to proper subscribers
                     * NB. Can this be made to be a programmable API? Maybe then a command parser would prove to be futile, when the client can access commands programmatically
                     * 3. Send result of the operation (ACK/ERR/etc)
                     */
                    using (ZFrame request = responder.ReceiveFrame())
                    {
                        ++requestCount;
                        Console.WriteLine("Hifrend received request #{0}: {1}", requestCount, request.ReadString());

                        // Do some work
                        Thread.Sleep(1);

                        responder.Send(new ZFrame(name));
                    }
                }
            }
        }
    }
}
