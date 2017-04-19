using System.ComponentModel.DataAnnotations.Schema;

namespace Interfile.Framework.Model
{
    [Table("Service")]
    public class Service : BaseModel
    {
        public string Name { get; set; }
    }
}
