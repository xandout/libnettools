using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;

namespace libnettools
{
	public class dns
	{

		public static string[] getIP (string hostname)
		{


			try{
				IPAddress[] ips;
				ips = Dns.GetHostAddresses(hostname);
				int ArraySize = ips.Length;
				string[] addresses = new string[ArraySize];
				int x = 0;
				foreach (IPAddress ip in ips)
				    {
				        
						addresses[x] = Convert.ToString(ip);
						x = x + 1;
					}
				return addresses;
				}
			catch(System.Exception e){
				string[] err = new string[3];
				err[0] = e.Message;
				return err;
			}

		}

		public static string[] rDNS(string hostname)
		{
		    try{

				IPHostEntry host;

			    host = Dns.GetHostEntry(hostname);

			    
				string[] hosts = new string[1];
				int x = 0;
			    foreach (IPAddress ip in host.AddressList)
				    {
						hosts[x] = host.HostName;
						x = x + 1;
				    }
				return hosts;
			}
			catch(System.Exception e){
				string[] err = new string[1];
				err[0] = e.Message;
				return err;

			}
		}
	}

    
}

