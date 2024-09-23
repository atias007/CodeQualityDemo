using System;
using System.Linq;
using System.Management;

namespace TestSourceGenerator;

public partial class Program
{
    static void Main()
    {
        GeneratedCode.HelloWorld.SayHello();
        return;
#pragma warning disable CA1416 // Validate platform compatibility
        ConnectionOptions connection = new()
        {
            //Username = "User",
            //Password = "AStrongPassword",
            //Authority = "ntlmdomain:DOMAINNAME",
            EnablePrivileges = true,
            Authentication = AuthenticationLevel.Default,
            Impersonation = ImpersonationLevel.Impersonate
        };

        var scope = new ManagementScope($"\\\\localhost\\root\\CIMV2", connection);
        scope.Connect();

        var query = new ObjectQuery("SELECT * FROM Win32_Volume");
        var searcher = new ManagementObjectSearcher(scope, query);

        foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
        {
            Console.WriteLine("Drive Name :" +
                               managementObject["DriveLetter"].ToString());
            Console.WriteLine("Volume Size :" +
                               managementObject["Size"].ToString());
            Console.WriteLine("Free Space :" +
                               managementObject["SizeRemaining"].ToString());
        }

        ////var query = new ObjectQuery("SELECT * FROM Win32_Service");
        ////var searcher = new ManagementObjectSearcher(scope, query);

        ////foreach (ManagementObject managementObject in searcher.Get().Cast<ManagementObject>())
        ////{
        ////    Console.WriteLine($"{managementObject["DisplayName"]}: {managementObject["State"]}");
        ////}

        Console.WriteLine("------------------");
#pragma warning restore CA1416 // Validate platform compatibility
    }
}