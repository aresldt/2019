insert into  v61df.gdzc(ZCID, ZCSTAT, ZCNAME, ZCZJGC, ZCBM, ZCCWFL, ZCFL, ZCUF1,
ZCUF3, ZCUF4, ZCUF5, ZCUF6, ZCUF7, ZCUF8, ZCUF9, ZCZJZ, ZCZJZZ, ZCNX, ZCSYNX,     
ZCDTE, ZCYZ, ZCLJZJ, ZCNZJ, ZCYZJ, ZCJC, ZCCZ, ZCMNTH, ZCENUSR,    
ZCENDT, ZCENTM, ZCMNUSR, ZCMNDT, ZCMNTM, ZCTNUSR, ZCTNDT, ZCTNTM )

select trim(case when ascii(substr(atprim,5,1))-64<10 then '0' else '' end||char(ascii(substr(atprim,5,1))-64))||substr(atprim,1,4)||'00'||substr(atprim,6,4), integer(dbstat), atdesc, integer(substr(atogst,3,1)),
integer(substr(atogst,4,2)), substr(atogst,6,3), substr(atogst,9,9), TRIM(UFAL1)||TRIM(UFAL2), UFAL3, UFAL4,UFAL5, UFAL6, UFAL7, UFAL8,UFAL9, case when UFNM3>0 then 1 else 0 end, ufnm3, Integer(DBLIFE/100)*12 + mod(DBLIFE, 100) - 1,
integer(DBRLIF/100)*12+mod(DBRLIF,100), DBDTIN, dbcost, dbresv, DBYRDP,  dbcurr, DBBAS, dbsalv, 201312, 'CUIL', 20140401, 0, 'CUIL', 20140401, 0, 'CUIL', 20140401, 0
from v61df.qdb inner join v61df.qat on dbassn=atassn and dbstat in ('01', '08', '30') and atstat='01'
inner join v61df.quf on atassn=ufassn and ufstus='01'
