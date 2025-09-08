using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acc.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ACC");

            migrationBuilder.EnsureSchema(
                name: "IDN");

            migrationBuilder.EnsureSchema(
                name: "STR");

            migrationBuilder.EnsureSchema(
                name: "PRS");

            migrationBuilder.CreateTable(
                name: "AspRoles",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspUsers",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "char(18)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "IDN",
                        principalTable: "AspRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "ACC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "ACC",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "char(18)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "char(18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(18)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspUserRoles",
                schema: "IDN",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(18)", nullable: false),
                    RoleId = table.Column<string>(type: "char(18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspUserRoles_AspRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "IDN",
                        principalTable: "AspRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspUserRoles_AspUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargoes",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargoes_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cargoes_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CostCenters",
                schema: "ACC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostCenters_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CostCenters_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "PRS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialPeriods",
                schema: "ACC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPeriods_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialPeriods_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Modules_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_Specifications_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "STR",
                        principalTable: "Specifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stores_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "ACC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    FinancialPeriodId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CostCenterId = table.Column<string>(type: "char(18)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "ACC",
                        principalTable: "CostCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_Documents_ReferenceId",
                        column: x => x.ReferenceId,
                        principalSchema: "ACC",
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documents_FinancialPeriods_FinancialPeriodId",
                        column: x => x.FinancialPeriodId,
                        principalSchema: "ACC",
                        principalTable: "FinancialPeriods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleModules",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    ModuleId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    RoleId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModules_AspRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "IDN",
                        principalTable: "AspRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModules_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModules_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "IDN",
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoSpecifics",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    ParentId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    SpecificationId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoSpecifics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoSpecifics_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoSpecifics_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoSpecifics_CargoSpecifics_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "STR",
                        principalTable: "CargoSpecifics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoSpecifics_Cargoes_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "STR",
                        principalTable: "Cargoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoSpecifics_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalSchema: "STR",
                        principalTable: "Specifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoLocations",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    StoreId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoLocations_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoLocations_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoLocations_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "STR",
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "PRS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonType = table.Column<int>(type: "int", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "STR",
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentDetails",
                schema: "ACC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    DocumentId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    AccountId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    ReferenceId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDetails_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "ACC",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDetails_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDetails_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDetails_DocumentDetails_ReferenceId",
                        column: x => x.ReferenceId,
                        principalSchema: "ACC",
                        principalTable: "DocumentDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDetails_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "ACC",
                        principalTable: "Documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleModulePermissions",
                schema: "IDN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    RoleModuleId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    PermissionId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModulePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModulePermissions_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModulePermissions_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModulePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "IDN",
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleModulePermissions_RoleModules_RoleModuleId",
                        column: x => x.RoleModuleId,
                        principalSchema: "IDN",
                        principalTable: "RoleModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoStores",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    StoreId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoLocationId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Serials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoStores_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoStores_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoStores_CargoLocations_CargoLocationId",
                        column: x => x.CargoLocationId,
                        principalSchema: "STR",
                        principalTable: "CargoLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoStores_Cargoes_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "STR",
                        principalTable: "Cargoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "STR",
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoRequests",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    RequesterId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApproverId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoRequests_AspUsers_ApproverId",
                        column: x => x.ApproverId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequests_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequests_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequests_Departments_RequesterId",
                        column: x => x.RequesterId,
                        principalSchema: "PRS",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequests_Persons_RequesterId",
                        column: x => x.RequesterId,
                        principalSchema: "PRS",
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    PersonId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    FactorNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactorType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factors_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "PRS",
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoRequestItems",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoRequestId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoRequestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoRequestItems_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequestItems_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequestItems_CargoRequests_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "STR",
                        principalTable: "CargoRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoRequestItems_Cargoes_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "STR",
                        principalTable: "Cargoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoRequestId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_CargoRequests_CargoRequestId",
                        column: x => x.CargoRequestId,
                        principalSchema: "STR",
                        principalTable: "CargoRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CargoFactors",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CargoId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    FactorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoFactors_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoFactors_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoFactors_Cargoes_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "STR",
                        principalTable: "Cargoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CargoFactors_Factors_FactorId",
                        column: x => x.FactorId,
                        principalSchema: "STR",
                        principalTable: "Factors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                schema: "STR",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    TransactionId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    CreatorId = table.Column<string>(type: "char(18)", fixedLength: true, maxLength: 18, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionItems_AspUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionItems_AspUsers_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "IDN",
                        principalTable: "AspUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionItems_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "STR",
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreatorId",
                schema: "ACC",
                table: "Accounts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ModifierId",
                schema: "ACC",
                table: "Accounts",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ParentId",
                schema: "ACC",
                table: "Accounts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "IDN",
                table: "AspRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspUserRoles_RoleId",
                schema: "IDN",
                table: "AspUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "IDN",
                table: "AspUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "IDN",
                table: "AspUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_CreatorId",
                schema: "STR",
                table: "Cargoes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_ModifierId",
                schema: "STR",
                table: "Cargoes",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoFactors_CargoId",
                schema: "STR",
                table: "CargoFactors",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoFactors_CreatorId",
                schema: "STR",
                table: "CargoFactors",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoFactors_FactorId",
                schema: "STR",
                table: "CargoFactors",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoFactors_ModifierId",
                schema: "STR",
                table: "CargoFactors",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLocations_CreatorId",
                schema: "STR",
                table: "CargoLocations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLocations_ModifierId",
                schema: "STR",
                table: "CargoLocations",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoLocations_StoreId",
                schema: "STR",
                table: "CargoLocations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequestItems_CargoId",
                schema: "STR",
                table: "CargoRequestItems",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequestItems_CreatorId",
                schema: "STR",
                table: "CargoRequestItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequestItems_ModifierId",
                schema: "STR",
                table: "CargoRequestItems",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequests_ApproverId",
                schema: "STR",
                table: "CargoRequests",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequests_CreatorId",
                schema: "STR",
                table: "CargoRequests",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequests_ModifierId",
                schema: "STR",
                table: "CargoRequests",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequests_RequesterId",
                schema: "STR",
                table: "CargoRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoSpecifics_CargoId",
                schema: "STR",
                table: "CargoSpecifics",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoSpecifics_CreatorId",
                schema: "STR",
                table: "CargoSpecifics",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoSpecifics_ModifierId",
                schema: "STR",
                table: "CargoSpecifics",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoSpecifics_ParentId",
                schema: "STR",
                table: "CargoSpecifics",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoSpecifics_SpecificationId",
                schema: "STR",
                table: "CargoSpecifics",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStores_CargoId",
                schema: "STR",
                table: "CargoStores",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStores_CargoLocationId",
                schema: "STR",
                table: "CargoStores",
                column: "CargoLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStores_CreatorId",
                schema: "STR",
                table: "CargoStores",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStores_ModifierId",
                schema: "STR",
                table: "CargoStores",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoStores_StoreId",
                schema: "STR",
                table: "CargoStores",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenters_CreatorId",
                schema: "ACC",
                table: "CostCenters",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCenters_ModifierId",
                schema: "ACC",
                table: "CostCenters",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorId",
                schema: "PRS",
                table: "Departments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifierId",
                schema: "PRS",
                table: "Departments",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_AccountId",
                schema: "ACC",
                table: "DocumentDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_CreatorId",
                schema: "ACC",
                table: "DocumentDetails",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_DocumentId",
                schema: "ACC",
                table: "DocumentDetails",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_ModifierId",
                schema: "ACC",
                table: "DocumentDetails",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDetails_ReferenceId",
                schema: "ACC",
                table: "DocumentDetails",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CostCenterId",
                schema: "ACC",
                table: "Documents",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatorId",
                schema: "ACC",
                table: "Documents",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FinancialPeriodId",
                schema: "ACC",
                table: "Documents",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ModifierId",
                schema: "ACC",
                table: "Documents",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceId",
                schema: "ACC",
                table: "Documents",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_CreatorId",
                schema: "STR",
                table: "Factors",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_ModifierId",
                schema: "STR",
                table: "Factors",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Factors_PersonId",
                schema: "STR",
                table: "Factors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPeriods_CreatorId",
                schema: "ACC",
                table: "FinancialPeriods",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPeriods_ModifierId",
                schema: "ACC",
                table: "FinancialPeriods",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CreatorId",
                schema: "IDN",
                table: "Modules",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ModifierId",
                schema: "IDN",
                table: "Modules",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreatorId",
                schema: "IDN",
                table: "Permissions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ModifierId",
                schema: "IDN",
                table: "Permissions",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatorId",
                schema: "PRS",
                table: "Persons",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ModifierId",
                schema: "PRS",
                table: "Persons",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_StoreId",
                schema: "PRS",
                table: "Persons",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissions_CreatorId",
                schema: "IDN",
                table: "RoleModulePermissions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissions_ModifierId",
                schema: "IDN",
                table: "RoleModulePermissions",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissions_PermissionId",
                schema: "IDN",
                table: "RoleModulePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissions_RoleModuleId",
                schema: "IDN",
                table: "RoleModulePermissions",
                column: "RoleModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_CreatorId",
                schema: "IDN",
                table: "RoleModules",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_ModifierId",
                schema: "IDN",
                table: "RoleModules",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_ModuleId",
                schema: "IDN",
                table: "RoleModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModules_RoleId",
                schema: "IDN",
                table: "RoleModules",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CreatorId",
                schema: "STR",
                table: "Specifications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ModifierId",
                schema: "STR",
                table: "Specifications",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ParentId",
                schema: "STR",
                table: "Specifications",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CreatorId",
                schema: "STR",
                table: "Stores",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ModifierId",
                schema: "STR",
                table: "Stores",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_CreatorId",
                schema: "STR",
                table: "TransactionItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_ModifierId",
                schema: "STR",
                table: "TransactionItems",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_TransactionId",
                schema: "STR",
                table: "TransactionItems",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CargoRequestId",
                schema: "STR",
                table: "Transactions",
                column: "CargoRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreatorId",
                schema: "STR",
                table: "Transactions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ModifierId",
                schema: "STR",
                table: "Transactions",
                column: "ModifierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspUserRoles",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "CargoFactors",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "CargoRequestItems",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "CargoSpecifics",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "CargoStores",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "DocumentDetails",
                schema: "ACC");

            migrationBuilder.DropTable(
                name: "RoleModulePermissions",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "TransactionItems",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "Factors",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "Specifications",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "CargoLocations",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "Cargoes",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "ACC");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "ACC");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "RoleModules",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "CostCenters",
                schema: "ACC");

            migrationBuilder.DropTable(
                name: "FinancialPeriods",
                schema: "ACC");

            migrationBuilder.DropTable(
                name: "AspRoles",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "IDN");

            migrationBuilder.DropTable(
                name: "CargoRequests",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "PRS");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "PRS");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "STR");

            migrationBuilder.DropTable(
                name: "AspUsers",
                schema: "IDN");
        }
    }
}
