UPDATE sys_log SET usuario=NULL WHERE usuario=0;
UPDATE sys_components SET estado=0 WHERE espacio='Lazaro.Mensajeria';

DROP FUNCTION IF EXISTS pvpIva;

CREATE FUNCTION pvpIva (idArt INT) RETURNS decimal(14,2)
	LANGUAGE SQL
	DETERMINISTIC
	CONTAINS SQL
	SQL SECURITY DEFINER
	COMMENT '' 
RETURN
  (SELECT IfNull(Round(a.pvp*(1+s.porcentaje/100),4),0) FROM articulos as a
	left outer join articulos_categorias as c on a.id_categoria=c.id_categoria 
	left outer join alicuotas s on c.id_alicuota=s.id_alicuota 
	Where a.id_articulo=idArt);

GRANT EXECUTE ON FUNCTION pvpIva To 'root';