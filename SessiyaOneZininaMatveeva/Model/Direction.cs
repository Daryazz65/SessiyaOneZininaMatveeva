//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SessiyaOneZininaMatveeva.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direction
    {
        public Direction()
        {
            this.Event = new HashSet<Event>();
            this.Jury = new HashSet<Jury>();
            this.Moderator = new HashSet<Moderator>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Jury> Jury { get; set; }
        public virtual ICollection<Moderator> Moderator { get; set; }
    }
}