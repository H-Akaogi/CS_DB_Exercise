using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("department")]
public class DepartmentEntity
{
    [Key]
    [Column("id")]//大文字・小文字で間違えないように注意
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    public override string ToString()
    {
        return $"部署Id: {Id}, 部署名Name: {Name}";
    }

}