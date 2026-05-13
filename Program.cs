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
        Exercise06(departmentAccessor);/*
        Exercise07(accessor);
        Exercise08(accessor);
        /*
        Exercise09(accessor, departmentAccessor);
        Exercise10(accessor, departmentAccessor);
       Exercise11(accessor);*/
        Exercise13(accessor);
    }

    /// <summary>
    /// 演習-05 すべての部署を取得する
    /// </summary>
    /// <param name="departmentAccessor"></param>
    static void Exercise05(DepartmentAccessor departmentAccessor)
    {
        var departments = departmentAccessor.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach (var d in departments)
        {
            Console.WriteLine(d);
        }
    }

    /// <summary>
    /// 演習-06 departmentテーブルから主キー値で部署を取得する
    /// </summary>
    /// <param name="departmentAccessor"></param>
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
    /*
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

        /// <summary>
        /// 演習-08
        /// </summary>
        /// <param name="accessor"></param>
        // Employeeテーブルから社員名の部分一致検索で該当社員を取得する
        static void Exercise08(EmployeeAccessor accessor)
        {
            Console.Write("キーワードを入力してください -> ");
            var keyword = Console.ReadLine()!;
            var employeenames = accessor.FindByNameContains(keyword);
            // 入力した文字をvar keywordsとして格納
            Console.WriteLine($"演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");
            if (employeenames != null)
            {
                foreach (var employeename in employeenames)
                {
                    Console.WriteLine($"[{employeename!.ToString()}]");
                }
            }
            else
            {
                Console.WriteLine($"キーワード:{keyword}が含まれる社員は存在しません");
            }
            return;
        }

        /*
        /// <summary>
        /// 演習-09 employeeテーブルに新しい社員の情報を登録する
        /// </summary>
        /// <param name="accessor"></param>
        /// <param name="departmentAccessor"></param>
        static void Exercise09(EmployeeAccessor accessor, DepartmentAccessor departmentAccessor)
        {
            Console.Write("社員名を入力してください -> ");
            var newname = Console.ReadLine()!;
            Console.WriteLine();
            Console.Write("部署Idを入力してください -> ");
            var newdeptid = int.Parse(Console.ReadLine()!);
            // 入力された部署が存在するか確認する
            if (departmentAccessor.FindById(newdeptid) == null!)
            {
                Console.WriteLine("入力された部署は存在しません");
                return;
            }
            var newEmployee = new EmployeeEntity
            {
                Name = newname,
                DeptId = newdeptid
            };
            // 商品を登録する
            Console.WriteLine("演習-09 employeeテーブルに新しい社員の情報を登録する");
            accessor.Create(newEmployee);
            Console.WriteLine($"社員名:{newname}, 部署id:{newdeptid}の社員を登録しました");
        }

        /// 演習-10 指定された社員Idの社員名を変更する
        static void Exercise10(EmployeeAccessor accessor, DepartmentAccessor departmentAccessor)
        {
            Console.Write("社員Idを入力してください-> ");
            var changeId = int.Parse(Console.ReadLine()!);
            // 入力された部署が存在するか確認する
            if (departmentAccessor.FindById(changeId) == null!)
            {
                Console.WriteLine("入力された部署は存在しません");
                return;
            }
            Console.WriteLine();
            Console.Write("社員名を入力してください-> ");
            var changeName = Console.ReadLine();

            var newEmployee = new EmployeeEntity
            {
                Name = changeName,
                DeptId = changeId
            };
            Console.Write("演習-10 指定された社員Idの社員名を変更する");
            accessor.UbdateById(newEmployee);
            Console.WriteLine($"社員名:{changeName}, 部署id:{changeId}の社員を登録しました");
        }

        /// 演習-11 指定された社員Idの社員を削除する
        static void Exercise11(EmployeeAccessor accessor)
        {
            Console.Write("社員Idを入力してください-> ");
            var deleteId = int.Parse(Console.ReadLine()!);
            Console.WriteLine();
            var result = accessor.DeleteById(deleteId);
            Console.WriteLine("演習-11 指定された社員Idの社員を削除する");
            // 削除結果がnullの場合は該当社員が存在しないため削除できなかった旨を表示する
            if (result == null)
            {
                Console.WriteLine($"社員Id:{deleteId}の社員は存在しないため削除できませんでした");
                return;
            }
            Console.WriteLine($"社員Id:{deleteId}の社員を削除しました");
        }
        */
    /// <summary>
    /// 演習-13 指定された氏名で社員と所属部署を取得する
    /// </summary>
    /// <param name="accessor"></param>
    static void Exercise13(EmployeeAccessor accessor)//EmployeeAccessorのみでOK
    {
        Console.Write("社員名を入力してください-> ");
        var name = Console.ReadLine()!;
        Console.WriteLine("演習-13 指定された氏名で社員と所属部署を取得する");

        var result = accessor.FindByEmployeeDepartment(name);
        if (result.Department != null)
        {

            Console.WriteLine(result.Department);
        }
        else
        {
            Console.WriteLine($"社員名:{name}が含まれる社員は存在しませんでした");
        }
        return;
    }
    /// 演習-14 指定された部署Idの部署と所属社員を取得する
    /// </summary>
    /// <param name="departmentAccessor">Departmentテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise14(DepartmentAccessor departmentAccessor)
    {
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-14 指定された部署Idの部署と所属社員を取得する");
        // departmentテーブルアクセスクラスのFindByIdJoinEmployeeメソッドを呼び出して、指定された部署Idの部署と所属社員を取得する
        var result = departmentAccessor.FindByIdJoinEmployee(deptId);
        if (result == null)
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しませんでした");
            return;
        }
        Console.WriteLine(result);

        // 取得した部署に所属する社員を出力する
        foreach (var employee in result.Employees!)
        {
            Console.WriteLine(employee);
        }
    }
}

