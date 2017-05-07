insert into chitietdichvu (
			idbanggiadichvu,
			tenchitiet,
			giatribinhthuong,
			donvi
			)
select idbanggiadichvu ,tendichvu,'','' 
 from banggiadichvu
where not exists (select idbanggiadichvu  from chitietdichvu where idbanggiadichvu =banggiadichvu.idbanggiadichvu )
and idphongkhambenh in (select idphongkhambenh from phongkhambenh where loaiphong=1)

