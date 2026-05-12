using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("employee")]
public class EmployeeEntity //Entityはテーブルの構造を決める
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("dept_id")]
    public int DeptId { get; set; }
    public override string ToString()
    {
        return $"社員Id: {Id}, 社員名name: {Name}, 部署Id: {DeptId}";
    }
}