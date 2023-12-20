# exm-bayarind.net
Exampl integration bayarind payment gateway use .net API

## Scaffolding
```scaffold
dotnet ef dbcontext scaffold "Data Source=mediaindoteknologi.com,5031;Initial Catalog=bayarind-exm;User Id=sa;Password=antapani@1b;TrustServerCertificate=Yes" Microsoft.EntityFrameworkCore.SqlServer --output-dir "..\Vleko.SiPeneliti.Data\Model" -c ApplicationDBContext --context-dir "..\Vleko.SiPeneliti.Data" --namespace "Vleko.Bayarind.Data.Model" --context-namespace "Vleko.Bayarind.Data" --no-pluralize -f --no-onconfiguring --schema "dbo"
```