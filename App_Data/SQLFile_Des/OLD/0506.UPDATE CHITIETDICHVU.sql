delete chitietdichvu where idchitietdichvu in (
select distinct   (select top 1 idchitietdichvu from chitietdichvu where tenchitiet=t.tenchitiet and idbanggiadichvu=t.idbanggiadichvu order by idchitietdichvu desc)
from chitietdichvu t
group by tenchitiet,idbanggiadichvu
having count(*)>1
)