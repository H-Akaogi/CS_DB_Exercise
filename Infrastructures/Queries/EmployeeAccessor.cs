/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/
using System.Security.Cryptography.X509Certificates;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
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

    // 演習-13 指定された氏名で社員と所属部署を取得する
    public EmployeeEntity? FindByEmployeeDepartment(string name)
    {
        var employee = _context.Employees
            .Include(e => e.Department) //表の結合(Department Column)
            .Where(e => e.Name == name) //nameと一致する場所を探す
            .SingleOrDefault(); //条件に一致するレコードが1件だけ取得する
        return employee;
    }
    /// <summary>
    /// 演習-16 データの有無を確認する
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<EmployeeEntity>? FindByNameContainsJoinDepartment(string name)
    // 複数件返る可能性があるものに対してはList<TEntity>を用いる
    {
        var employees = _context.Employees
        .Include(e => e.Department) // カテゴリを結合して取得する
        .Where(e => e.Name!.Contains(name)) // Where()メソッドで条件指定
        .ToList(); // ToList()メソッドを使用して、条件を満たすものすべてを取得する
        if (employees.Count == 0)//一致した結果が0件だった場合
        {
            return null;
        }
        return employees!;//employeesは検索結果の社員一覧（List）
    }

}