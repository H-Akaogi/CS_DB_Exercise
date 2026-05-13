using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // Accessorを生成する
        var departmentAccessor = new DepartmentAccessor(context);
        var accessor = new EmployeeAccessor(context);

        // 演習用クラス名
        Exercise05(departmentAccessor);
        Exercise06(departmentAccessor);
        Exercise07(accessor);
        Exercise08(accessor);

        // 演習-05 すべての部署を取得する
        static void Exercise05(DepartmentAccessor departmentAccessor)
        {
            var departments = departmentAccessor.FindAll();
            Console.WriteLine("すべての部署を取得する");
            foreach (var d in departments)
            {
                Console.WriteLine(d);
            }
        }

        // 演習-06 departmentテーブルから主キー値で部署を取得する
        // 指定した部署Idの部署を取得する(存在する部署Id)
        static void Exercise06(DepartmentAccessor departmentAccessor)
        {
            var department = departmentAccessor.FindById(1);
            Console.WriteLine($"存在する部署[{department!.ToString()}]");

            // 指定した部署Idの部署を取得する(存在しない部署Id)
            department = departmentAccessor.FindById(101);
            if (department == null)
            {
                Console.WriteLine($"部署Id:101の部署は存在しません。");
            }
        }

        /// Employees
        /// 演習-07
        /// すべての社員を取得する
        static void Exercise07(EmployeeAccessor accessor)
        {
            var employees = accessor.FindAll();
            Console.WriteLine("すべての社員を取得する");
            foreach (var d in employees)
            {
                Console.WriteLine(d);
            }
        }
        // 指定した社員Idの社員を取得する(存在する社員Id)
        var employee = accessor.FindByDeptId(4);
        Console.WriteLine($"存在する社員[{employee!.ToString()}]");

        // 指定した社員Idの社員を取得する(存在しない社員Id)
        employee = accessor.FindByDeptId(404);
        if (employee == null)
        {
            Console.WriteLine($"社員Id:404の社員は存在しません。");
        }
    }

    // 演習-08
    // Employeeテーブルから社員名の部分一致検索で該当社員を取得する
    static void Exercise08(EmployeeAccessor accessor)
    {
        Console.Write("キーワードを入力してください -> ");
        var keyword = Console.ReadLine()!;
        var employeenames = accessor.FindByNameContains(keyword);
        // 入力した文字をvar keywordsとして格納
        Console.WriteLine($"演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");
        foreach (var employeename in employeenames)
        {
            Console.WriteLine($"[{employeename!.ToString()}]");
        }

    }
}

