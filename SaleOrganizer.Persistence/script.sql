﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE TABLE "Photos" (
        "Id" text NOT NULL,
        "Url" text NULL,
        CONSTRAINT "PK_Photos" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE TABLE "Clothes" (
        "Id" text NOT NULL,
        "Name" text NULL,
        "Description" text NULL,
        "Status" integer NOT NULL,
        "PhotoId" text NULL,
        "StorageInfo" text NULL,
        "DetailedStorageInfo" text NULL,
        CONSTRAINT "PK_Clothes" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Clothes_Photos_PhotoId" FOREIGN KEY ("PhotoId") REFERENCES "Photos" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE TABLE "Offerings" (
        "Id" text NOT NULL,
        "ClothId" text NULL,
        "ReferenceLink" text NULL,
        "Price" numeric NOT NULL,
        "TradeType" integer NOT NULL,
        "DeliveryType" integer NOT NULL,
        "OfferingDate" timestamp without time zone NOT NULL,
        "OrderedDate" timestamp without time zone NULL,
        "SendDate" timestamp without time zone NULL,
        CONSTRAINT "PK_Offerings" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Offerings_Clothes_ClothId" FOREIGN KEY ("ClothId") REFERENCES "Clothes" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE TABLE "Purchases" (
        "Id" text NOT NULL,
        "ClothId" text NULL,
        "ReferenceLink" text NULL,
        "Price" numeric NOT NULL,
        "TradeType" integer NOT NULL,
        "DeliveryType" integer NOT NULL,
        "PurchaseDate" timestamp without time zone NOT NULL,
        "PaymentDate" timestamp without time zone NULL,
        "DeliveryDate" timestamp without time zone NULL,
        CONSTRAINT "PK_Purchases" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Purchases_Clothes_ClothId" FOREIGN KEY ("ClothId") REFERENCES "Clothes" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE INDEX "IX_Clothes_PhotoId" ON "Clothes" ("PhotoId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE INDEX "IX_Offerings_ClothId" ON "Offerings" ("ClothId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    CREATE INDEX "IX_Purchases_ClothId" ON "Purchases" ("ClothId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210922223346_StringIds') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210922223346_StringIds', '3.1.18');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetRoles" (
        "Id" text NOT NULL,
        "Name" character varying(256) NULL,
        "NormalizedName" character varying(256) NULL,
        "ConcurrencyStamp" text NULL,
        CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetUsers" (
        "Id" text NOT NULL,
        "UserName" character varying(256) NULL,
        "NormalizedUserName" character varying(256) NULL,
        "Email" character varying(256) NULL,
        "NormalizedEmail" character varying(256) NULL,
        "EmailConfirmed" boolean NOT NULL,
        "PasswordHash" text NULL,
        "SecurityStamp" text NULL,
        "ConcurrencyStamp" text NULL,
        "PhoneNumber" text NULL,
        "PhoneNumberConfirmed" boolean NOT NULL,
        "TwoFactorEnabled" boolean NOT NULL,
        "LockoutEnd" timestamp with time zone NULL,
        "LockoutEnabled" boolean NOT NULL,
        "AccessFailedCount" integer NOT NULL,
        "Services" text[] NULL,
        CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetRoleClaims" (
        "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "RoleId" text NOT NULL,
        "ClaimType" text NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetUserClaims" (
        "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "UserId" text NOT NULL,
        "ClaimType" text NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetUserLogins" (
        "LoginProvider" text NOT NULL,
        "ProviderKey" text NOT NULL,
        "ProviderDisplayName" text NULL,
        "UserId" text NOT NULL,
        CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
        CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetUserRoles" (
        "UserId" text NOT NULL,
        "RoleId" text NOT NULL,
        CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
        CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE TABLE "AspNetUserTokens" (
        "UserId" text NOT NULL,
        "LoginProvider" text NOT NULL,
        "Name" text NOT NULL,
        "Value" text NULL,
        CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
        CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924211146_IdentityAdded') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210924211146_IdentityAdded', '3.1.18');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924223818_UserClothesRelationDefined') THEN
    ALTER TABLE "Clothes" ADD "UserId" text NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924223818_UserClothesRelationDefined') THEN
    CREATE INDEX "IX_Clothes_UserId" ON "Clothes" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924223818_UserClothesRelationDefined') THEN
    ALTER TABLE "Clothes" ADD CONSTRAINT "FK_Clothes_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE RESTRICT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924223818_UserClothesRelationDefined') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210924223818_UserClothesRelationDefined', '3.1.18');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924224937_ConfigurationConstraint') THEN
    ALTER TABLE "Clothes" DROP CONSTRAINT "FK_Clothes_AspNetUsers_UserId";
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924224937_ConfigurationConstraint') THEN
    ALTER TABLE "Clothes" ALTER COLUMN "UserId" TYPE text;
    ALTER TABLE "Clothes" ALTER COLUMN "UserId" SET NOT NULL;
    ALTER TABLE "Clothes" ALTER COLUMN "UserId" DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924224937_ConfigurationConstraint') THEN
    ALTER TABLE "Clothes" ADD CONSTRAINT "FK_Clothes_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20210924224937_ConfigurationConstraint') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210924224937_ConfigurationConstraint', '3.1.18');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20211101172910_RefreshTokens') THEN
    CREATE TABLE "RefreshToken" (
        "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        "UserId" text NULL,
        "Token" text NULL,
        "ExpiryDate" timestamp without time zone NOT NULL,
        "Revoked" timestamp without time zone NULL,
        CONSTRAINT "PK_RefreshToken" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_RefreshToken_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20211101172910_RefreshTokens') THEN
    CREATE INDEX "IX_RefreshToken_UserId" ON "RefreshToken" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20211101172910_RefreshTokens') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211101172910_RefreshTokens', '3.1.18');
    END IF;
END $$;
