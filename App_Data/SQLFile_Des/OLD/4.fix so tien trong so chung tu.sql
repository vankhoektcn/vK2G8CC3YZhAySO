update khambenhcanlamsan set dongia=(select giadichvu from banggiadichvu where idbanggiadichvu=khambenhcanlamsan.idcanlamsan),thanhtien=(select giadichvu from banggiadichvu where idbanggiadichvu=khambenhcanlamsan.idcanlamsan)  where dongia is null or dongia=0
update sochungtu set sotien=(select top 1 dongia from khambenhcanlamsan where maphieucls=sochungtu.SophieuCT) where sotien is null or sotien=0
update sochungtu set sotien=(select sum(a.soluong*a.dongia*((100.0 -isnull(giamgia,0))/100))  from chitietdangkykham a left join dangkykham b on a.iddangkykham=b.iddangkykham  where maphieudangky=sochungtu.SophieuCT) where sotien is null or sotien=0

