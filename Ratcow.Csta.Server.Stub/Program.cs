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

namespace Ratcow.Csta.Server.Stub
{
    using Engine;
    using Logs.Initialization;
    using Ecma323.Ed3;

    /// <summary>
    /// This is a server stub, purely here to test connections and collect the passed XML
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            LogInitialiser.InitLog4Net();

            var rm = new DummyResourceManager
            {
                SwitchIpAddress = "127.0.0.1",
                SwitchName = "RATCOW",
            };

            rm.AddExtension("1003");
            rm.AddExtension("1007");
            rm.AddVdn("1315");


            var server = new ServerManager(new DummyEventProcessor(), rm)
            {
                CallServerName = rm.SwitchName,
                CallServerIpAddress = rm.SwitchIpAddress,
                Address = "127.0.0.1",
                Port = 4721,
                Secure = false
            };

            server.Start();

            Console.ReadLine();


            server.Stop();
        }
    }
}
