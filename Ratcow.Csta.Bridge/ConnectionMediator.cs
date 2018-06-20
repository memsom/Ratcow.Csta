﻿/* Ratcow.Csta is an ECMA-323/ECMA-354 XML API integration for MS.Net.
 * Copyright (C) 2018 Ratcow Software and Matt Emson. 
 * 
 * This software is dual licensed. It may be freely used under the GPL3,
 * but any for any proprietary commercial use, it must me licensed under 
 * the terms of a commercial license, and may only be included in any 
 * release after the appropriate fees have been paid.
 * 
 * The GPL3 license is as follows:
 *
 
    This file is part of the Ratcow.Csta namespace..

    Ratcow.Csta is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Ratcow.Csta is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Ratcow.Csta.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

using System;

namespace Ratcow.Csta.Bridge
{
    using Engine.Core;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;

    public class ConnectionMediator
    {
        public TcpClient Server { get; set; }
        public TcpClient Client { get; set; }

        bool running;
        Task serverTask = null;
        Task clientTask = null;
        TcpCommsClient clientComms = null;
        TcpCommsServer serverComms = null;
        ManualResetEvent clientWait = new ManualResetEvent(false);

        public void Start()
        {
            if(Client != null && Server != null)
            {
                running = true;
                clientComms = new TcpCommsClient { Client = Client };
                clientTask = Task.Factory.StartNew(() => ClientRunLoop());
                serverComms = new TcpCommsServer { Client = Server };
                serverTask = Task.Factory.StartNew(() => ServerRunLoop());
            }
        }

        void ClientRunLoop()
        {
            while (running)
            {
                //init
                clientWait.WaitOne();

                //process....
            }
        }

        void ServerRunLoop()
        {
            while (running)
            {
                //init
                clientWait.Set();

                //process....
            }
        }

        public void Stop()
        {
            running = false;
        }
    }
}
