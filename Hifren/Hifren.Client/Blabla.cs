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

namespace Hifren.Client
{
    public partial class Blabla
    {
        /*
         * Make this to be a graphical interface; maybe then a separate command parser is not required here.
         */
        public void ChatClient(string endpoint, string clientId, string requestText)
        {
            using (var context = new ZContext())
            using (var requester = new ZSocket(context, ZSocketType.REQ))
            {
                requester.Connect(endpoint);

                for (int n = 0; n < 5; ++n)
                {
                    Console.WriteLine("{0}: Sending {1}...", clientId, requestText);

                    requester.Send(new ZFrame(requestText));

                    // Receive
                    using (ZFrame reply = requester.ReceiveFrame())
                    {
                        Console.WriteLine("{0}: Received: {1} {2}!", clientId, requestText, reply.ReadString());
                    }
                }
            }
        }
    }
}
