using System.ComponentModel.DataAnnotations;
using Worker_CRUD.Enums;

namespace Worker_CRUD.Models
{
    public class WorkerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public OfficeEnum Office { get; set; }
        public bool Activity { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime();
    }
}
