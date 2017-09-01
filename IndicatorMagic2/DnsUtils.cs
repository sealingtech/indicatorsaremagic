using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace IndicatorMagic2
{
    /// <summary>
    /// This is used for flushing the cache for DNS.  I found it was only making one request for a reasonable time period
    /// </summary>
    class DnsUtils
    {
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        static extern UInt32 DnsFlushResolverCache();

        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCacheEntry_A")]
        public static extern int DnsFlushResolverCacheEntry(string hostName);

        public static void FlushCache()
        {
            DnsFlushResolverCache();
        }

        public static void FlushCache(string hostName)
        {
            DnsFlushResolverCacheEntry(hostName);
        }
    }
}
