library(tidyr)

#
# Note: examples only, no data!
#

# Gather takes multiple columns and collapses into key-value pairs, duplicating 
# all other columns as needed.

# Each row of the data now represents exactly one observation, characterized by 
# a unique combination of the grade and sex variables. Each of our variables 
# (grade, sex, and count) occupies exactly one column. That's tidy data!

gather(students, sex, count,-grade)


# Given either regular expression or a vector of character positions, 
# separate() turns a single character column into multiple columns.
separate(res, sex_class, c("sex", "class"))

students2 %>%
  gather( sex_class, count, -grade ) %>%
  separate( sex_class, c("sex", "class")) %>%
  print


# Call gather() to gather the columns class1
# through class5 into a new variable called class.
# The 'key' should be class, and the 'value'
# should be grade.
gather(class , grade, class1:class5 , na.rm= TRUE)

# spread {tidyr}	R Documentation
# Spread a key-value pair across multiple columns.

# This script builds on the previous one by appending
# a call to spread(), which will allow us to turn the
# values of the test column, midterm and final, into
# column headers (i.e. variables).

students3 %>%
  gather(class, grade, class1:class5, na.rm = TRUE) %>%
  spread( test, grade) %>%
  print

# Use the mutate() function from dplyr along with
# extract_numeric(). Hint: You can "overwrite" a column
# with mutate() by assigning a new value to the existing
# column instead of creating a new column.
students3 %>%
  gather(class, grade, class1:class5, na.rm = TRUE) %>%
  spread(test, grade) %>%
  mutate(class = extract_numeric(class)) %>%
  print

# Add a call to unique() below, which will remove
# duplicate rows from student_info.
student_info <- students4 %>%
  select(id, name, sex) %>%
  unique() %>%
  print

# add a new column to the passed table. The column should be called status and
# the value, "passed".
passed <- passed %>% mutate(status="passed")

# Efficiently bind multiple data frames by row and column.
bind_rows(passed,failed)







