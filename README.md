# hifren - a tryout with instant messaging

This project is intended as my personal C\# showcase, and also as a demo for a chat client/server. It's still in a very early phase, and maturation should be expected over the next year.

Thanks for HiQ Finland's IEX team for providing the project day, where to develop this, and for the ZeroMQ community for their neat networking library. -Mikael, Aug 2017

## Iteration 2, March 2018 - Server side improvements

Roadmap to future:

- Server should allow one-to-one or group conversations
- Messages should be seen only by sender and defined recipients (another client or a pre-defined list of clients), not by any other clients
- Groups (channels) may set rules, like (in)visible, invite only, and group admin rights only with specified clients
- Servers should be allowed to send messages to all clients
- Servers should be able to inter-connect to serve all clients in the same network

To be considered later on:
- Message logging (client or server side?)
- Client authentication
- Web client and server console