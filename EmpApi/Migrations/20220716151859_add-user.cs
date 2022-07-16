using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpApi.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "AspNetUsers",
              columns: new[] { "Id", "FirstName", "LastName", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash" 
              , "SecurityStamp", "ConcurrencyStamp" , "PhoneNumber" ,"PhoneNumberConfirmed","TwoFactorEnabled","LockoutEnd","LockoutEnabled","AccessFailedCount" },
              values: new object[] { "b300d53b-d02e-4b26-8069-86930edb1fe2","helmy", "mohamed", "helmy2022", "HELMY2022", "helmy@gmail.com", "HELMY@GMAIL.COM",
             false,"AQAAAAEAACcQAAAAEH9uPvLKsvtIG+eOgkCha5XfslIwN2A2rKPJi+RPXNSSoF869PadikF/vJS9duPgmg==","7XHAHKOZGBHQMFTE3SL5ZB3X7TQUQMYI" 
              ,"5b36fb8f-2ad9-4396-b3d3-a355d1a61ce5","",false,false,"",true,0}
          );
            migrationBuilder.InsertData(
             table: "AspNetUserRoles",
             columns: new[] { "UserId", "RoleId" },
             values: new object[] { "b300d53b-d02e-4b26-8069-86930edb1fe2","7b74cfe9-9d9d-463c-8701-c0f37b8e22e6"}
         );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUsers]");
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles]");
        }
    }
}
