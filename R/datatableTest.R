rm(list=ls())

# Load packages
library(data.table)


DT = data.table(a=LETTERS[c(1,1:3)],b=4:7,key="a")

DT = data.table(a=LETTERS[c(1,1:3)],b=4:7)

DT  
DT[,c:=8]        # add a numeric column, 8 for all rows
DT[,d:=9L]       # add an integer column, 9L for all rows
DT[,c:=NULL]     # remove column c
DT[2,d:=10L]     # subassign by reference to column d
DT               # DT changed by reference

DT[b>4,b:=d*2L]  # subassign to b using d, where b>4
DT[a == "A", b:=0L]    # binary search for group "A" and set column b

DT[,e:=mean(d),by=a]  # add new column by group by reference
DT["B",f:=mean(d)]    # subassign to new column, NA initialized
