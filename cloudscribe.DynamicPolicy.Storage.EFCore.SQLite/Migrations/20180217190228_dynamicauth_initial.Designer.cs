﻿// <auto-generated />
using cloudscribe.DynamicPolicy.Storage.EFCore.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace cloudscribe.DynamicPolicy.Storage.EFCore.SQLite.Migrations
{
    [DbContext(typeof(DynamicPolicyDbContext))]
    [Migration("20180217190228_dynamicauth_initial")]
    partial class dynamicauth_initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AllowedClaimValueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllowedValue")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid?>("ClaimRequirementId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClaimRequirementId");

                    b.ToTable("csp_AuthPolicyClaimValue");
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AllowedRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllowedRole")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid?>("PolicyId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("csp_AuthPolicyRole");
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthenticationSchemeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthenticationScheme")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid?>("PolicyId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("csp_AuthPolicyScheme");
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthorizationPolicyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<bool>("RequireAuthenticatedUser");

                    b.Property<string>("RequiredUserName");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("TenantId");

                    b.ToTable("csp_AuthPolicy");
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.ClaimRequirementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid?>("PolicyId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("csp_AuthPolicyClaim");
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AllowedClaimValueEntity", b =>
                {
                    b.HasOne("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.ClaimRequirementEntity", "ClaimRequirement")
                        .WithMany("AllowedValues")
                        .HasForeignKey("ClaimRequirementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AllowedRoleEntity", b =>
                {
                    b.HasOne("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthorizationPolicyEntity", "Policy")
                        .WithMany("AllowedRoles")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthenticationSchemeEntity", b =>
                {
                    b.HasOne("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthorizationPolicyEntity", "Policy")
                        .WithMany("AuthenticationSchemes")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.ClaimRequirementEntity", b =>
                {
                    b.HasOne("cloudscribe.DynamicPolicy.Storage.EFCore.Common.Entities.AuthorizationPolicyEntity", "Policy")
                        .WithMany("RequiredClaims")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
