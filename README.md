# SQLiteAdminUTF8CI
SQLite Manager with UTF8CI support

This is a small and simple SQLite Database Manager

Primarily it is created to solve Tuskish Collation problem in SQLite.Net
If you want to use Turkish Collation with your application in Visual Studio C# you have do following steps in your project:

1. Put this code somewhere in your NameSpace
<code>
[SQLiteFunction(FuncType = FunctionType.Collation, Name = "UTF8CI")]
    public class SQLiteCaseInsensitiveCollation : SQLiteFunction
    {
        private static readonly System.Globalization.CultureInfo _cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR");
        public override int Compare(string x, string y)
        {
            return string.Compare(x, y, _cultureInfo, System.Globalization.CompareOptions.IgnoreCase);
        }
    }
</code>

2. Insert folllowing name in your program.cs just before open main form.
<code>System.Data.SQLite.SQLiteFunction.RegisterFunction(typeof(SQLiteCaseInsensitiveCollation));</code>

3. Now create your SQLite tables with something like this:
<code>
CREATE TABLE `mytablename` (
`id` INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
`myfield2` TEXT NULL COLLATE UTF8CI,
`myfield3` TEXT)
</code>

Note: If SQLite.Net does not understand "COLLATE UTF8CI" and gives this error: "No such collation: UTF8CI" run you query like this "select * from mytable order by fieldname1 COLLATE BINARY"

Any help is welcome.
Also if someone found better solution, please write as comment.

Thanks,
