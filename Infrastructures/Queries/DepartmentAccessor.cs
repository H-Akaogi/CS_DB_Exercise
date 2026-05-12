/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;*/
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class DepartmentAccessor
{
    private readonly AppDbContext _context;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public DepartmentAccessor(AppDbContext context)//AppDbContextクラスのcontext変数を引数とする
    {
        _context = context;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<DepartmentEntity> FindAll() // List<TEntity>インスタンスメソッド（ものに対して呼び出すメソッド）
    // 戻り値はList<>
    // FindAll()と()がついているのでメソッド
    // staticがないのでインスタンスメソッド
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var departments = _context.Departments.ToList();//データ取得
        return departments;
    }
    /// <summary>
    /// 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="departmentId">部署Id(主キー)</param>
    public DepartmentEntity? FindById(int departmentId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Departments.Find(departmentId);
        return department;
    }
}