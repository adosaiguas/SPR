//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPR.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServerPerformances
    {
        public System.Guid ServerPerformace_ID { get; set; }
        public string ServerPerformance_CPU { get; set; }
        public string ServerPerformance_RAM { get; set; }
        public string ServerPerformance_IO_DISK { get; set; }
        public string ServerPerformance_IIS_Sessions { get; set; }
    
        public virtual Emails Emails { get; set; }
    }
}