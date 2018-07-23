#region

using System;
using System.Web;

#endregion

namespace RedisDemo.Infrastructure
{
    public class CounterView
    {
        public CounterView()
        {
            MachineName = Environment.MachineName;
            MachineIp = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
        }

        public int Counter { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string MachineName { get; }
        public string MachineIp { get; }
    }
}