# Load packages from list.
packages <- c("dplyr", "data.table")
sapply(packages, require, character.only = TRUE, quietly = TRUE)

# Must set locale for dates and correct sorting.
Sys.setlocale("LC_COLLATE", "C")

# counts at each combination of factor levels.
table(flags$landmass)
# 1  2  3  4  5  6 
# 31 17 35 52 39 20

# Unset (remove) all variables in the workspace.
rm(list=ls())

tmp <- 1:4
rm(tmp)

# Provides an estimate of the memory that is being used to store an R object.
object.size(plants)
# 644232 bytes

# to get memory usage for your namespace, by object type, use memory.profile()
memory.profile()
#    NULL      symbol    pairlist     closure environment     promise    language 
#       1        9434      183964        4125        1359        6963       49425 
# special     builtin        char     logical     integer      double     complex 
#     173        1562       20652        7383       13212        4137           1 

# names(plants) will return a character vector of column (i.e. variable) names.
names(plants)
# [1] "Scientific_Name"      "Duration"             "Active_Growth_Period"
# [4] "Foliage_Color"        "pH_Min"               "pH_Max"              
# [7] "Precip_Min"           "Precip_Max"           "Shade_Tolerance"     
# [10] "Temp_Min_F" 

# add leading zeroes
sprintf("%06d", 1)
# 000001   
