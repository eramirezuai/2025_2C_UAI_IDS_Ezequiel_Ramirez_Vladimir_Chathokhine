--user_family
--user
--vvd --vertical verification digit, faltaria la 
--patent
--family_patent
--family
--select * from audit


-----entrega 2
--multiidioma
--translation_string
--translation_code
--select * from language




USE [Australis]
GO







SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[password] [char](64) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[vvd](
	[table_name] [nvarchar](50) NOT NULL,
	[digit] [char](64) NOT NULL,
 CONSTRAINT [PK_vvd] PRIMARY KEY CLUSTERED 
(
	[table_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[patent](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_patent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO









SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[family](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[code] [varchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_family] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[family_patent](
	[family_id] [bigint] NOT NULL,
	[patent_id] [bigint] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[family_patent]  WITH CHECK ADD  CONSTRAINT [FK_famiy_patent_family] FOREIGN KEY([family_id])
REFERENCES [dbo].[family] ([id])
GO

ALTER TABLE [dbo].[family_patent] CHECK CONSTRAINT [FK_famiy_patent_family]
GO

ALTER TABLE [dbo].[family_patent]  WITH CHECK ADD  CONSTRAINT [FK_famiy_patent_patent] FOREIGN KEY([patent_id])
REFERENCES [dbo].[patent] ([id])
GO

ALTER TABLE [dbo].[family_patent] CHECK CONSTRAINT [FK_famiy_patent_patent]
GO





SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_family](
	[user_id] [bigint] NOT NULL,
	[family_id] [bigint] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[user_family]  WITH CHECK ADD  CONSTRAINT [FK_user_family_family] FOREIGN KEY([family_id])
REFERENCES [dbo].[family] ([id])
GO

ALTER TABLE [dbo].[user_family] CHECK CONSTRAINT [FK_user_family_family]
GO

ALTER TABLE [dbo].[user_family]  WITH CHECK ADD  CONSTRAINT [FK_user_family_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO

ALTER TABLE [dbo].[user_family] CHECK CONSTRAINT [FK_user_family_user]
GO






SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[audit](
	[audit_id] [bigint] IDENTITY(1,1) NOT NULL,
	[previous_audit_id] [bigint] NULL,
	[next_audit_id] [bigint] NULL,
	[entity_table] [nvarchar](50) NOT NULL,
	[entity_id] [bigint] NOT NULL,
	[snapshot] [nvarchar](max) NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_audit] PRIMARY KEY CLUSTERED 
(
	[audit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


--********************************************************procedures

CREATE PROCEDURE [dbo].[sp_user_family_insert]
    @user_id   BIGINT,
    @family_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[user_family] (user_id, family_id)
    VALUES (@user_id, @family_id);
END
GO


CREATE PROCEDURE [dbo].[sp_user_family_delete]
    @user_id   BIGINT,
    @family_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[user_family]
    WHERE user_id = @user_id
      AND family_id = @family_id;
END
GO



CREATE PROCEDURE [dbo].[sp_user_insert]
    @name NVARCHAR(100),
    @password CHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[user] ([name], [password])
    VALUES (@name, @password);

    -- devolver el id generado
    SELECT SCOPE_IDENTITY() AS NewUserId;
END
GO



CREATE PROCEDURE [dbo].[sp_user_delete]
    @id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[user]
    WHERE id = @id;
END
GO



CREATE PROCEDURE [dbo].[sp_vvd_insert]
    @table_name NVARCHAR(50),
    @digit CHAR(64)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[vvd] (table_name, digit)
    VALUES (@table_name, @digit);
END
GO



CREATE PROCEDURE [dbo].[sp_vvd_delete]
    @table_name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[vvd]
    WHERE table_name = @table_name;
END
GO


CREATE PROCEDURE [dbo].[sp_patent_insert]
    @code VARCHAR(100),
    @description NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[patent] ([code], [description])
    VALUES (@code, @description);

    -- Devolver el id generado
    SELECT SCOPE_IDENTITY() AS NewPatentId;
END
GO



CREATE PROCEDURE [dbo].[sp_patent_delete]
    @id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[patent]
    WHERE id = @id;
END
GO


CREATE PROCEDURE [dbo].[sp_family_patent_insert]
    @family_id BIGINT,
    @patent_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[family_patent] (family_id, patent_id)
    VALUES (@family_id, @patent_id);
END
GO


CREATE PROCEDURE [dbo].[sp_family_patent_delete]
    @family_id BIGINT,
    @patent_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[family_patent]
    WHERE family_id = @family_id
      AND patent_id = @patent_id;
END
GO


CREATE PROCEDURE [dbo].[sp_family_insert]
    @code VARCHAR(100),
    @description NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[family] ([code], [description])
    VALUES (@code, @description);

    -- Devolver el id generado
    SELECT SCOPE_IDENTITY() AS NewFamilyId;
END
GO


CREATE PROCEDURE [dbo].[sp_family_delete]
    @id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[family]
    WHERE id = @id;
END
GO


CREATE PROCEDURE [dbo].[sp_audit_insert]
    @previous_audit_id BIGINT = NULL,
    @next_audit_id     BIGINT = NULL,
    @entity_table      NVARCHAR(50),
    @entity_id         BIGINT,
    @snapshot          NVARCHAR(MAX),
    @date              DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[audit] (
        previous_audit_id,
        next_audit_id,
        entity_table,
        entity_id,
        snapshot,
        [date]
    )
    VALUES (
        @previous_audit_id,
        @next_audit_id,
        @entity_table,
        @entity_id,
        @snapshot,
        @date
    );

    -- Devolver el id generado
    SELECT SCOPE_IDENTITY() AS NewAuditId;
END
GO


CREATE PROCEDURE [dbo].[sp_audit_delete]
    @audit_id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[audit]
    WHERE audit_id = @audit_id;
END
GO
