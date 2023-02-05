﻿using System;
using System.Net;
using System.Net.NetworkInformation;
class ExtendNetworkInfo
{
    [STAThread]
    static void Main(string[] args)
    {
        DisplayNetworkInfo();
    }

    public static void DisplayNetworkInfo()
    {
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adapter in adapters)
        {
            IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
            GatewayIPAddressInformationCollection Gatewayaddresses =
                    adapterProperties.GatewayAddresses;
            IPAddressCollection dhcpServers = adapterProperties.DhcpServerAddresses;
            IPAddressCollection dnsServers = adapterProperties.DnsAddresses;

            Console.WriteLine("네트워크 카드 : " + adapter.Description); // 네트워크 정보
            Console.WriteLine("  Physical Address ........... : " + adapter.GetPhysicalAddress());
            Console.WriteLine("  IP Address ................. : " + Get_MyIP());

            // Gateway 정보 출력
            if (Gatewayaddresses.Count > 0)
            {
                foreach (GatewayIPAddressInformation address in Gatewayaddresses)
                {
                    Console.WriteLine("  Gateway Address ............ : " + address.Address.ToString());
                }
            }
            // DHCP 정보 출력
            if (dhcpServers.Count > 0)
            {
                foreach (IPAddress dhcp in dhcpServers)
                {
                    Console.WriteLine("  DHCP Servers ............... : " + dhcp.ToString());
                }
            }
            // DNS 정보 출력
            if (dnsServers.Count > 0)
            {
                foreach (IPAddress dns in dnsServers)
                {
                    Console.WriteLine("  DNS Servers ................ : " + dns.ToString());
                }
            }
        }
    }
    // 자기 자신의 IP 정보 출력
    public static string Get_MyIP()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        string myip = host.AddressList[0].ToString();
        return myip;
    }
}
