library(lubridate)

#
# Note: examples only, no data!
#

Sys.getlocale("LC_TIME")
# Set to Sys.setlocale("LC_COLLATE", "C").

this_day <- today()
# "2015-09-28"

day(this_day)
# [1] 28

wday(this_day)
# [1] 2

wday(this_day, label = TRUE)
# [1] Mon
# Levels: Sun < Mon < Tues < Wed < Thurs < Fri < Sat

this_moment <- now()
# [1] "2015-09-28 12:29:07 MSK"

hour(this_moment)
# [1] 12

# ymd(), dmy(), hms(), ymd_hms()

my_date<- ymd("1989-05-17")
# "1989-05-17 UTC"

class(my_date)
# [1] "POSIXct" "POSIXt"

mdy("March 12, 1975")
#  "2075-12-19 UTC"

dmy(25081985)
# [1] "1985-08-25 UTC"

ymd("1920/1/2")
# [1] "1920-01-02 UTC"

# 2014-08-23 17:23:02
ymd_hms(dt1)
# [1] "2014-08-23 17:23:02 UTC"

hms("03:22:14")
# [1] "3H 22M 14S"

update(this_moment, hours = 8, minutes = 34, seconds = 55).

# To find the current date in New York, we'll use the now() function again.
nyc <- now("America/New_York")

depart <- nyc + days(2)

# Get date-time in a different time zone.
?with_tz

arrive <- with_tz(arrive, "Asia/Hong_Kong")
# [1] "2015-10-01 21:24:15 HKT"
last_time <- mdy("June 17, 2008", tz = "Singapore")

# new_interval {lubridate}
# interval creates an Interval-class object with the specified start and end dates.
how_long <- new_interval(last_time, arrive)

as.period(how_long)
