
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ApplyUkraine.Models
{

using System;
    using System.Collections.Generic;
    
public partial class UsersForm
{

    public int Id { get; set; }

    public Nullable<int> UserId { get; set; }

    public Nullable<int> AppFormId { get; set; }

    public Nullable<int> LetterId { get; set; }



    public virtual ApplicationForm ApplicationForm { get; set; }

    public virtual Letter Letter { get; set; }

    public virtual User User { get; set; }

}

}
