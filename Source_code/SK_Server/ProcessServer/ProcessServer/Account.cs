//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcessServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public string Name_user { get; set; }
        public string Pass { get; set; }
        public Nullable<int> Id { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
