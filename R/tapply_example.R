setwd("~/GitHub/MyCodeNote/R")
# Apply a Function Over a2 Ragged Array

headers <- c("name", "landmass", "zone", "area", "population", "language", 
             "religion", "bars", "stripes", "colours", "red", "green", "blue",
             "gold", "white", "black", "orange", "mainhue", "circles", "crosses",
             "saltires", "quarters", "sunstars", "crescent", "triangle", "icon",
             "animate", "text", "topleft", "botright")
flags <- read.csv("flag.data", header = FALSE, col.names =  headers)

pplation <- flags$population
# pplation
# [1]   16    3   20    0    0    7    0    0   28   28   15    8    0    0   90    0
# [17]   10    0    3    0    1    6    1  119    0    0    9    7   35    4    8   24

flags_red <- flags$red
# flags_red
# [1] 1 1 1 1 1 1 0 1 0 0 1 1 0 1 1 0 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1
# [42] 1 1 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 0 1 1 1 0 1 1 1 1 1 0 1 1 1 0 1 1 1 1 0 1 1 1 0

tapply(flags$population, flags$red, summary)
# $`0`
# Min. 1st Qu.  Median    Mean 3rd Qu.    Max. 
# 0.00    0.00    3.00   27.63    9.00  684.00 

# $`1`
# Min. 1st Qu.  Median    Mean 3rd Qu.    Max. 
# 0.0     0.0     4.0    22.1    15.0  1008.0 
