//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rgpharmacyy.Models
{
    using System;
    
    public partial class covid_Result
    {
        public int pid { get; set; }
        public string p_name { get; set; }
        public string c_name { get; set; }
        public Nullable<System.DateTime> manufacture_date { get; set; }
        public Nullable<System.DateTime> expiry_date { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string img { get; set; }
        public string des { get; set; }
    }
}
