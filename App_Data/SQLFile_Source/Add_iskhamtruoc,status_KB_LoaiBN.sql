

alter table kb_loaiBN
 add iskhamtruoc bit
go
alter table kb_loaiBN
add status bit 

go
update  kb_loaiBN set status= 1