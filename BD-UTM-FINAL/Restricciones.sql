USE BDUTM
GO

ALTER TABLE Publicacion
ADD CONSTRAINT Def_DatePub 
DEFAULT GETDATE() FOR Fecha ;  
GO

ALTER TABLE UsuarioPublicacion
ADD CONSTRAINT Def_DateCom 
DEFAULT GETDATE() FOR Fecha ;  
GO

ALTER TABLE TipoPublicacion
ADD UNIQUE(NomTipo)
GO

ALTER TABLE TipoSitio
ADD UNIQUE(NombreTipo)
GO

ALTER TABLE TipoUsuario
ADD UNIQUE(NomTipo)
GO