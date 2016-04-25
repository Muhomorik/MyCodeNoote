# Load packages from list.
packages <- c("dplyr", "data.table")
sapply(packages, require, character.only = TRUE, quietly = TRUE)

# System config - package versions.
sessionInfo()
install.packages("quanteda",repos="http://cran.r-project.org",type="binary")
remove.packages(pkgs = c("quanteda"))

# Must set locale for dates and correct sorting.
Sys.setlocale("LC_COLLATE", "C")

#basename removes all of the path up to and including the last path 
basename("C:/test/file.r")
# [1] "file.r"
dirname("C:/test/file.r")
# w[1] "C:/test"

# create path
file.path(directory, paste(id, ".csv", sep=""))

# counts at each combination of factor levels.
table(flags$landmass)
# 1  2  3  4  5  6 
# 31 17 35 52 39 20

# Unset (remove) all variables in the workspace.
rm(list=ls())

tmp <- 1:4
rm(tmp)

# Function temlate.
myfunction <- function(arg1, arg2, ... ){
statements
return(object)
}

# Control flow.
if (!npar) {
	center <- mean(x); spread <- sd(x)
} else {
	center <- median(x); spread <- mad(x)
}
if (print & !npar) {
	cat("Mean=", center, "\n", "SD=", spread, "\n")
} else if (print & npar) {
	cat("Median=", center, "\n", "MAD=", spread, "\n")
}
  
# Provides an estimate of the memory that is being used to store an R object.
object.size(plants)
# 644232 bytes
data.size <- object.size(dataAll)                 
data.size <- format(data.size, quote = FALSE, units = "MB") # Appr. 42Mb.
message("Merged table size = ", data.size)
  
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

start.time <- Sys.time()
# ...Relevent codes...
end.time <- Sys.time()
time.taken <- end.time - start.time
time.taken

# Formar number.
format(round(as.numeric(1000.64), 1), nsmall=1, big.mark=",")  # 1,000.6


# function documentation
CalculateSampleCovariance <- function(x, y, verbose = TRUE) {
  # Computes the sample covariance between two vectors.
  #
  # Args:
  #   x: One of two vectors whose sample covariance is to be calculated.
  #   y: The other vector. x and y must have the same length, greater than one,
  #      with no missing values.
  #   verbose: If TRUE, prints sample covariance; if not, not. Default is TRUE.
  #
  # Returns:
  #   The sample covariance between x and y.
}


# Command line
## myScript.R
args <- commandArgs(trailingOnly = TRUE)
rnorm(n=as.numeric(args[1]), mean=as.numeric(args[2]))

# And here is what invoking it from the command line looks like
> Rscript myScript.R 5 100
[1]  98.46435 100.04626  99.44937  98.52910 100.78853


# Wait for key press
# Wrapping into a function:

readkey <- function()
{
    cat ("Press [enter] to continue")
    line <- readline()
}

readkey <- function()
{
    cat("[press [enter] to continue]")
    number <- scan(n=1)
}


# Progress bar.
# use txtProgressBar for console.
total <- 150
pb <- winProgressBar(title = "progress bar", min = 0,
                     max = total, width = 300)
for(i in 1:total){
  Sys.sleep(0.1)
  setWinProgressBar(pb, i, title=paste( round(i/total*100, 0),
                                        "% done"))
}
close(pb)

# text progress bar.
total <- 20
# create progress bar
pb <- txtProgressBar(min = 0, max = total, style = 3)
for(i in 1:total){
  Sys.sleep(0.1)
  # update progress bar
  setTxtProgressBar(pb, i)
}
close(pb)
