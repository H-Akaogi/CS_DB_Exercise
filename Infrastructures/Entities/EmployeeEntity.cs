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

    /// <summary>
    /// 演習-12 employeeテーブルとdepartmentテーブルを結合可能にする
    /// 所属部署
    /// </summary>
    [ForeignKey("DeptId")]//ForeignKeyを使用(DepartmentEntity側にも同様に)
    public DepartmentEntity? Department { get; set; }
    public override string ToString()
    {
        return $"社員Id={Id} , 社員名={Name} , 部署Id={DeptId}";
    }
}