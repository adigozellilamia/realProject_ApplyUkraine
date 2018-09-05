
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
    
public partial class ApplicationForm
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ApplicationForm()
    {

        this.UsersForms = new HashSet<UsersForm>();

    }


    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Nullable<System.DateTime> Birthday { get; set; }

    public string Email { get; set; }

    public string MobilPhone { get; set; }

    public string SocialNetworks { get; set; }

    public string Skype { get; set; }

    public string InvitationLetterAddress { get; set; }

    public string ZipCode { get; set; }

    public string Language { get; set; }

    public Nullable<int> CoursToUniversityId { get; set; }

    public string Passport { get; set; }

    public string Certificate { get; set; }

    public string CountryCitizen { get; set; }

    public string CountryLiving { get; set; }

    public string Cities { get; set; }

    public Nullable<int> DegreeId { get; set; }

    public Nullable<System.DateTime> SubmitDate { get; set; }



    public virtual ApplicationForm ApplicationForms1 { get; set; }

    public virtual ApplicationForm ApplicationForm1 { get; set; }

    public virtual Degree Degree { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UsersForm> UsersForms { get; set; }

}

}