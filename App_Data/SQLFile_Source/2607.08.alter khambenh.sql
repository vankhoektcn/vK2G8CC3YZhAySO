alter table khambenh add IdChiTietDangKyKham bigint
update khambenh set IdChiTietDangKyKham =(select top 1 idchitietdangkykham from chitietdangkykham where khambenh.iddangkykham=iddangkykham)