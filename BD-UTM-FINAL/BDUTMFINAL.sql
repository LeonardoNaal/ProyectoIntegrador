/*
 * ER/Studio 8.0 SQL Code Generation
 * Company :      Studios
 * Project :      ModeloBDUTM.DM1
 * Author :       l123_leo_@hotmail.com
 *
 * Date Created : Friday, December 02, 2016 16:35:43
 * Target DBMS : Microsoft SQL Server 2008
 */

/* 
 * TABLE: Actividades 
 */

 CREATE DATABASE BDUTM

 use BDUTM
CREATE TABLE Actividades(
    IDActividad    int              IDENTITY(1,1),
    Nombre         varchar(50)      NOT NULL,
    Descripcion    varchar(5000)    NOT NULL,
    FechaIni       date             NOT NULL,
    FechaFin       date             NOT NULL,
    HoraInicio     time(0)          NOT NULL,
    HoraFin        time(0)          NOT NULL,
    CodUsuario     varchar(20)      NOT NULL,
    IDSitio        int              NULL,
    CONSTRAINT PK9 PRIMARY KEY CLUSTERED (IDActividad)
)
go



IF OBJECT_ID('Actividades') IS NOT NULL
    PRINT '<<< CREATED TABLE Actividades >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Actividades >>>'
go

/* 
 * TABLE: ActividadUsuario 
 */

CREATE TABLE ActividadUsuario(
    ID             int            IDENTITY(1,1),
    Asistencia     bit            NULL,
    IDActividad    int            NULL,
    CodUsuario     varchar(20)    NULL,
    CONSTRAINT PK15 PRIMARY KEY NONCLUSTERED (ID)
)
go



IF OBJECT_ID('ActividadUsuario') IS NOT NULL
    PRINT '<<< CREATED TABLE ActividadUsuario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE ActividadUsuario >>>'
go

/* 
 * TABLE: Horario 
 */

CREATE TABLE Horario(
    CodHora    int        IDENTITY(1,1),
    HoraIni    time(0)    NOT NULL,
    HoraFin    time(0)    NOT NULL,
    CONSTRAINT PK7 PRIMARY KEY CLUSTERED (CodHora)
)
go



IF OBJECT_ID('Horario') IS NOT NULL
    PRINT '<<< CREATED TABLE Horario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Horario >>>'
go

/* 
 * TABLE: Publicacion 
 */

CREATE TABLE Publicacion(
    IDPublicacion    int               IDENTITY(1,1),
    Titulo           varchar(50)       NULL,
    Fecha            smalldatetime     NOT NULL,
    Contenido        varchar(1000)     NOT NULL,
    Image            image             NULL,
    video            varbinary(max)    NULL,
    IDTipo           int               NOT NULL,
    CodUsuario       varchar(20)       NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY CLUSTERED (IDPublicacion)
)
go



IF OBJECT_ID('Publicacion') IS NOT NULL
    PRINT '<<< CREATED TABLE Publicacion >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Publicacion >>>'
go

/* 
 * TABLE: Sitio 
 */

CREATE TABLE Sitio(
    IDSitio     int            IDENTITY(1,1),
    Nombre      varchar(50)    NOT NULL,
    Planta      int            NOT NULL,
    IDTipo      int            NOT NULL,
    CONSTRAINT PK12 PRIMARY KEY NONCLUSTERED (IDSitio)
)
go



IF OBJECT_ID('Sitio') IS NOT NULL
    PRINT '<<< CREATED TABLE Sitio >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Sitio >>>'
go

/* 
 * TABLE: TipoPublicacion 
 */

CREATE TABLE TipoPublicacion(
    IDTipo     int         IDENTITY(1,1),
    NomTipo    char(10)    NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY CLUSTERED (IDTipo)
)
go



IF OBJECT_ID('TipoPublicacion') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoPublicacion >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoPublicacion >>>'
go

/* 
 * TABLE: TipoSitio 
 */

CREATE TABLE TipoSitio(
    IDTipo        int            IDENTITY(1,1),
    NombreTipo    varchar(50)    NOT NULL,
    CONSTRAINT PK13 PRIMARY KEY NONCLUSTERED (IDTipo)
)
go



IF OBJECT_ID('TipoSitio') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoSitio >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoSitio >>>'
go

/* 
 * TABLE: TipoUsuario 
 */

CREATE TABLE TipoUsuario(
    CodigoTipo    int            IDENTITY(1,1),
    NomTipo       varchar(50)    NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY CLUSTERED (CodigoTipo)
)
go



IF OBJECT_ID('TipoUsuario') IS NOT NULL
    PRINT '<<< CREATED TABLE TipoUsuario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE TipoUsuario >>>'
go

/* 
 * TABLE: Usuario 
 */

CREATE TABLE Usuario(
    CodUsuario    varchar(20)    NOT NULL,
    Nombres       varchar(50)    NOT NULL,
    ApePat        varchar(50)    NOT NULL,
    ApeMat        varchar(50)    NULL,
    Password      varchar(30)    NOT NULL,
    CodigoTipo    int            NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY CLUSTERED (CodUsuario)
)
go



IF OBJECT_ID('Usuario') IS NOT NULL
    PRINT '<<< CREATED TABLE Usuario >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Usuario >>>'
go

/* 
 * TABLE: UsuarioHora 
 */

CREATE TABLE UsuarioHora(
    ID            int            IDENTITY(1,1),
    Dia           varchar(20)    NOT NULL,
    IDSitio       int            NULL,
    CodHora       int            NULL,
    CodUsuario    varchar(20)    NULL,
    CONSTRAINT PK10 PRIMARY KEY NONCLUSTERED (ID)
)
go



IF OBJECT_ID('UsuarioHora') IS NOT NULL
    PRINT '<<< CREATED TABLE UsuarioHora >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE UsuarioHora >>>'
go

/* 
 * TABLE: UsuarioPublicacion 
 */

CREATE TABLE UsuarioPublicacion(
    CodComentario    int              IDENTITY(1,1),
    Fecha            smalldatetime    NOT NULL,
    Contenido        varchar(5000)    NOT NULL,
    IDPublicacion    int              NOT NULL,
    CodUsuario       varchar(20)      NOT NULL,
    CONSTRAINT PK14 PRIMARY KEY NONCLUSTERED (CodComentario)
)
go



IF OBJECT_ID('UsuarioPublicacion') IS NOT NULL
    PRINT '<<< CREATED TABLE UsuarioPublicacion >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE UsuarioPublicacion >>>'
go

/* 
 * TABLE: Actividades 
 */

ALTER TABLE Actividades ADD CONSTRAINT RefUsuario27 
    FOREIGN KEY (CodUsuario)
    REFERENCES Usuario(CodUsuario)
go

ALTER TABLE Actividades ADD CONSTRAINT RefSitio35 
    FOREIGN KEY (IDSitio)
    REFERENCES Sitio(IDSitio)
go


/* 
 * TABLE: ActividadUsuario 
 */

ALTER TABLE ActividadUsuario ADD CONSTRAINT RefActividades48 
    FOREIGN KEY (IDActividad)
    REFERENCES Actividades(IDActividad)
go

ALTER TABLE ActividadUsuario ADD CONSTRAINT RefUsuario49 
    FOREIGN KEY (CodUsuario)
    REFERENCES Usuario(CodUsuario)
go


/* 
 * TABLE: Publicacion 
 */

ALTER TABLE Publicacion ADD CONSTRAINT RefTipoPublicacion28 
    FOREIGN KEY (IDTipo)
    REFERENCES TipoPublicacion(IDTipo)
go

ALTER TABLE Publicacion ADD CONSTRAINT RefUsuario30 
    FOREIGN KEY (CodUsuario)
    REFERENCES Usuario(CodUsuario)
go


/* 
 * TABLE: Sitio 
 */

ALTER TABLE Sitio ADD CONSTRAINT RefTipoSitio33 
    FOREIGN KEY (IDTipo)
    REFERENCES TipoSitio(IDTipo)
go


/* 
 * TABLE: Usuario 
 */

ALTER TABLE Usuario ADD CONSTRAINT RefTipoUsuario29 
    FOREIGN KEY (CodigoTipo)
    REFERENCES TipoUsuario(CodigoTipo)
go


/* 
 * TABLE: UsuarioHora 
 */

ALTER TABLE UsuarioHora ADD CONSTRAINT RefSitio43 
    FOREIGN KEY (IDSitio)
    REFERENCES Sitio(IDSitio)
go

ALTER TABLE UsuarioHora ADD CONSTRAINT RefHorario44 
    FOREIGN KEY (CodHora)
    REFERENCES Horario(CodHora)
go

ALTER TABLE UsuarioHora ADD CONSTRAINT RefUsuario45 
    FOREIGN KEY (CodUsuario)
    REFERENCES Usuario(CodUsuario)
go


/* 
 * TABLE: UsuarioPublicacion 
 */

ALTER TABLE UsuarioPublicacion ADD CONSTRAINT RefPublicacion36 
    FOREIGN KEY (IDPublicacion)
    REFERENCES Publicacion(IDPublicacion)
go

ALTER TABLE UsuarioPublicacion ADD CONSTRAINT RefUsuario38 
    FOREIGN KEY (CodUsuario)
    REFERENCES Usuario(CodUsuario)
go


