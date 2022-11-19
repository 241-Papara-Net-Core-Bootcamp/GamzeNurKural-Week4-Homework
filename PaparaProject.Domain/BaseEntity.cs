using System;

namespace PaparaProject.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Status { get; set; } //Active=1, Passive=0
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdateAt { get; set; }
        public string LastUpdateBy { get; set; }
    }
}
