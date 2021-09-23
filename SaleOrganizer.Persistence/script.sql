CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
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
    VALUES ('20210922223346_StringIds', '3.1.4');
    END IF;
END $$;
