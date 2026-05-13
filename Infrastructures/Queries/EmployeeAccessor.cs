/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/
using System.Security.Cryptography.X509Certificates;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.VisualBasic;

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
    /// すべての社員を取得する
    /// </summary>
    public List<EmployeeEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての社員を取得する
        var employees = _context.Employees.ToList();
        return employees;
    }
    /// <summary>
    /// 指定した社員Idの部署を取得する
    /// </summary>
    /// <param name="DeptId">部署Id(主キー)</param>
    public EmployeeEntity? FindByDeptId(int deptId)
    {
        // Find()メソッドを使用して、指定した社員Idの部署を取得する
        var employee = _context.Employees.Find(deptId);
        return employee;
    }
    public List<EmployeeEntity> FindByNameContains(string keyword)
    //List<>型にする
    {
        // Where(), ToList()メソッドを使用して、指定した社員Idの部署を取得する
        return _context.Employees
       .Where(i => i.Name!.Contains(keyword))
       .ToList();
    }
    // 新規社員の登録
    public EmployeeEntity Create(EmployeeEntity employee)
    {
        // 新規社員の追加
        var result = _context.Employees.Add(employee);
        // 変更を永続化する
        _context.SaveChanges();
        return result.Entity;
    }
    // 社員名の変更
    public EmployeeEntity? UbdateById(EmployeeEntity employee)
    {
        // 社員IDの取得
        var result = _context.Employees.Find(employee.Id);
        if (employee == null)
        {
            return null;
        }
        result!.Name = employee.Name;
        result.DeptId = employee.DeptId;
        // 変更を永続化する
        _context.SaveChanges();
        return employee;
    }
    public EmployeeEntity? DeleteById(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return employee;
    }
}