using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;


namespace libnettools
{
    public class icmp
    {
        public static string[] ping(string host)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128, e
                // but change the fragmentation behavior.
                options.DontFragment = true;


                // Create a buffer of 32 bytes of data to be transmitted. 
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(host, timeout, buffer, options);
                string[] ping = new string[2];
                if (reply.Status == IPStatus.Success)
                {


                    ping[0] = reply.RoundtripTime.ToString();
                    ping[1] = reply.Options.Ttl.ToString();

                }
                else { ping[0] = "Error"; }

                return ping;
            }
            catch
            {
                string[] err = new string[1];
                err[0] = "Error\n Possibly you entered a malformed IP or domain.";
                return err;
            }
        }
    }
}
