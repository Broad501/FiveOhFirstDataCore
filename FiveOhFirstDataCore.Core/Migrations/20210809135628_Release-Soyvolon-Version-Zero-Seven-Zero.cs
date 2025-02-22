﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FiveOhFirstDataCore.Core.Migrations
{
    public partial class ReleaseSoyvolonVersionZeroSevenZero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankUpdates_AspNetUsers_ChangedById",
                table: "RankUpdates");

            migrationBuilder.RenameColumn(
                name: "ChangedById",
                table: "RankUpdates",
                newName: "RequestedById");

            migrationBuilder.RenameIndex(
                name: "IX_RankUpdates_ChangedById",
                table: "RankUpdates",
                newName: "IX_RankUpdates_RequestedById");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "RankUpdates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DeniedById",
                table: "RankUpdates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BilletedCShopLeadership",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCShopCommand",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CShopClaims",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false),
                    ClaimData = table.Column<string>(type: "text", nullable: false),
                    CShopLeadership = table.Column<List<string>>(type: "text[]", nullable: false),
                    CShopCommand = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CShopClaims", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "CShopRoles",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CShopRoles", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DiscordRoles",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: false),
                    RoleGrants = table.Column<decimal[]>(type: "numeric(20,0)[]", nullable: false),
                    RoleReplaces = table.Column<decimal[]>(type: "numeric(20,0)[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordRoles", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "PromotionRequirements",
                columns: table => new
                {
                    RequirementsFor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequiredRank = table.Column<List<int>>(type: "integer[]", nullable: false),
                    InherentRankAuth = table.Column<List<int>>(type: "integer[]", nullable: false),
                    RankOrHigher = table.Column<bool>(type: "boolean", nullable: false),
                    RequiredTimeInGrade = table.Column<int>(type: "integer", nullable: false),
                    TiGWaivedFor = table.Column<List<int>>(type: "integer[]", nullable: false),
                    RequiredBillet = table.Column<int[]>(type: "integer[]", nullable: false),
                    RequiredTimeInBillet = table.Column<int>(type: "integer", nullable: false),
                    DivideEqualsZero = table.Column<int>(type: "integer", nullable: true),
                    SlotMin = table.Column<int>(type: "integer", nullable: true),
                    SlotMax = table.Column<int>(type: "integer", nullable: true),
                    TeamMustBeNull = table.Column<bool>(type: "boolean", nullable: false),
                    RequiredQualifications = table.Column<long>(type: "bigint", nullable: false),
                    RequiresCShop = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresCShopLeadership = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresCShopCommand = table.Column<bool>(type: "boolean", nullable: false),
                    NeededLevel = table.Column<int>(type: "integer", nullable: false),
                    CanPromoteTo = table.Column<List<int>>(type: "integer[]", nullable: false),
                    DoesNotRequireLinearProgression = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionRequirements", x => x.RequirementsFor);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PromotionForId = table.Column<int>(type: "integer", nullable: false),
                    RequestedById = table.Column<int>(type: "integer", nullable: true),
                    NeededBoard = table.Column<int>(type: "integer", nullable: false),
                    CurrentBoard = table.Column<int>(type: "integer", nullable: false),
                    PromoteFrom = table.Column<int>(type: "integer", nullable: false),
                    PromoteTo = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    Forced = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_AspNetUsers_PromotionForId",
                        column: x => x.PromotionForId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promotions_AspNetUsers_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RankUpdateTrooper",
                columns: table => new
                {
                    ApprovedById = table.Column<int>(type: "integer", nullable: false),
                    ApprovedRankUpdatesChangeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankUpdateTrooper", x => new { x.ApprovedById, x.ApprovedRankUpdatesChangeId });
                    table.ForeignKey(
                        name: "FK_RankUpdateTrooper_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RankUpdateTrooper_RankUpdates_ApprovedRankUpdatesChangeId",
                        column: x => x.ApprovedRankUpdatesChangeId,
                        principalTable: "RankUpdates",
                        principalColumn: "ChangeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CShopDepartmentBinding",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    ParentKey = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CShopDepartmentBinding", x => x.Key);
                    table.ForeignKey(
                        name: "FK_CShopDepartmentBinding_CShopRoles_ParentKey",
                        column: x => x.ParentKey,
                        principalTable: "CShopRoles",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromotionTrooper",
                columns: table => new
                {
                    ApprovedById = table.Column<int>(type: "integer", nullable: false),
                    ApprovedPendingPromotionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionTrooper", x => new { x.ApprovedById, x.ApprovedPendingPromotionsId });
                    table.ForeignKey(
                        name: "FK_PromotionTrooper_AspNetUsers_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionTrooper_Promotions_ApprovedPendingPromotionsId",
                        column: x => x.ApprovedPendingPromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CShopRoleData",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Roles = table.Column<decimal[]>(type: "numeric(20,0)[]", nullable: false),
                    ParentKey = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CShopRoleData", x => x.Key);
                    table.ForeignKey(
                        name: "FK_CShopRoleData_CShopDepartmentBinding_ParentKey",
                        column: x => x.ParentKey,
                        principalTable: "CShopDepartmentBinding",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankUpdates_DeniedById",
                table: "RankUpdates",
                column: "DeniedById");

            migrationBuilder.CreateIndex(
                name: "IX_CShopDepartmentBinding_ParentKey",
                table: "CShopDepartmentBinding",
                column: "ParentKey");

            migrationBuilder.CreateIndex(
                name: "IX_CShopRoleData_ParentKey",
                table: "CShopRoleData",
                column: "ParentKey");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromotionForId",
                table: "Promotions",
                column: "PromotionForId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_RequestedById",
                table: "Promotions",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionTrooper_ApprovedPendingPromotionsId",
                table: "PromotionTrooper",
                column: "ApprovedPendingPromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_RankUpdateTrooper_ApprovedRankUpdatesChangeId",
                table: "RankUpdateTrooper",
                column: "ApprovedRankUpdatesChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RankUpdates_AspNetUsers_DeniedById",
                table: "RankUpdates",
                column: "DeniedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RankUpdates_AspNetUsers_RequestedById",
                table: "RankUpdates",
                column: "RequestedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankUpdates_AspNetUsers_DeniedById",
                table: "RankUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_RankUpdates_AspNetUsers_RequestedById",
                table: "RankUpdates");

            migrationBuilder.DropTable(
                name: "CShopClaims");

            migrationBuilder.DropTable(
                name: "CShopRoleData");

            migrationBuilder.DropTable(
                name: "DiscordRoles");

            migrationBuilder.DropTable(
                name: "PromotionRequirements");

            migrationBuilder.DropTable(
                name: "PromotionTrooper");

            migrationBuilder.DropTable(
                name: "RankUpdateTrooper");

            migrationBuilder.DropTable(
                name: "CShopDepartmentBinding");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "CShopRoles");

            migrationBuilder.DropIndex(
                name: "IX_RankUpdates_DeniedById",
                table: "RankUpdates");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "RankUpdates");

            migrationBuilder.DropColumn(
                name: "DeniedById",
                table: "RankUpdates");

            migrationBuilder.DropColumn(
                name: "BilletedCShopLeadership",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsCShopCommand",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RequestedById",
                table: "RankUpdates",
                newName: "ChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_RankUpdates_RequestedById",
                table: "RankUpdates",
                newName: "IX_RankUpdates_ChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_RankUpdates_AspNetUsers_ChangedById",
                table: "RankUpdates",
                column: "ChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
