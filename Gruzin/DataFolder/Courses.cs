//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gruzin.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            this.CoursesStaff = new HashSet<CoursesStaff>();
        }
    
        public int IdCourses { get; set; }
        public string NameCourses { get; set; }
        public int IdTypeOfCourses { get; set; }
        public decimal CountCoursesPayment { get; set; }
    
        public virtual TypesOfCourses TypesOfCourses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoursesStaff> CoursesStaff { get; set; }
    }
}
