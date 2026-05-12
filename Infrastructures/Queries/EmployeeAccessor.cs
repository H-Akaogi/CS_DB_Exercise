/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class EmployeeAccessor
{
    private readonly AppDbContext _context;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<EmployeeEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var employees = _context.Employees.ToList();
        return employees;
    }
    /// <summary>
    /// 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="DeptId">部署Id(主キー)</param>
    public EmployeeEntity? FindById(int DeptId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var employee = _context.Employees.Find(DeptId);
        return employee;
    }
}