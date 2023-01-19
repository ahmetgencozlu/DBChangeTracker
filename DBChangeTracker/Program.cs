using DBChangeTracker;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

internal class Program
{

    private static void Main(string[] args)
    {
        var builder = new SqlConnectionStringBuilder("data source=.;initial catalog=DBChangeTracker;integrated security=true;");
        using (var tableDependecy = new SqlTableDependency<Customer>(builder.ConnectionString, "Customer"))
        {
            tableDependecy.OnChanged += TableDependency_Changed;
            tableDependecy.OnError += TableDependency_OnError;

            tableDependecy.Start();

            Console.WriteLine("Waiting");

            Console.ReadKey();
            tableDependecy.Stop();
        }
    }

    static void TableDependency_Changed(object sender, RecordChangedEventArgs<Customer> e)
    {
        Console.WriteLine(Environment.NewLine);
        if (e.ChangeType != ChangeType.None)
        {
            var changeEntity = e.Entity;
            Console.WriteLine("ChangeType: " + e.ChangeType);
            Console.WriteLine("Id: " + changeEntity.Id);
            Console.WriteLine("Name: " + changeEntity.FirstName +" "+ changeEntity.LastName);
            Console.WriteLine("PhoneNumber: " + changeEntity.PhoneNumber);
            Console.WriteLine("E-mail: " + changeEntity.Email);
            Console.WriteLine("Permissions ------------------------------");
            Console.WriteLine($"{nameof(changeEntity.IsPhoneAllowed)}:{changeEntity.IsPhoneAllowed}");
            Console.WriteLine($"{nameof(changeEntity.IsEmailAllowed)}:{changeEntity.IsEmailAllowed}");
            Console.WriteLine($"{nameof(changeEntity.IsCallAllowed)}:{changeEntity.IsCallAllowed}");
            Console.WriteLine(Environment.NewLine);
        }
    }

    static void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
    {
        Console.WriteLine(e.Message);
    }

}