using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentEntity.Entities;

[Table("department")]
public class DepartmentEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    public string? Name { get; set; }
    public override string ToString()
    {
        return $"部署Id: {Id}, 部署名Name: {Name}";
    }

}