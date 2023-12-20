# exm-bayarind.net
Exampl integration bayarind payment gateway use .net API

## Scaffolding
```scaffold
dotnet ef dbcontext scaffold "Data Source=LAPTOP-VS457QBK\\SQLSEV_SERVER;Initial Catalog=bayarindTrans;User Id=sa;Password=saSqlDev;TrustServerCertificate=Yes" Microsoft.EntityFrameworkCore.SqlServer --output-dir "..\Homeplate.Data\Model" -c ApplicationDBContext --context-dir "..\Vleko.Bayarind.Data" --namespace "Vleko.Bayarind.Data.Model" --context-namespace "Vleko.Bayarind.Data" --no-pluralize -f --no-onconfiguring --schema "dbo"
```