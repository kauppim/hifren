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
        public static void MsgServer(string name)
        {
            int requestCount = 0;

            using (var context = new ZContext())
            using (var responder = new ZSocket(context, ZSocketType.REP))
            {
                responder.Bind("tcp://*:5555");

                while (true)
                {
                    // Receive
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
