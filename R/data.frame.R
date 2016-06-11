  
  
df_names <- c(
  "nGram", "skipGram", "GramsSize", "scaling", "runtime")

# Empty df with column types.
df = data.frame(nGrams = integer(), skipGram = integer(), GramsSize = integer(),
                scaling = integer(), runtime = numeric())

# df row.
df.new = data.frame(nGrams, 
                    paste(skipGrams, collapse = ","),
                    round(gramsSize, digits = 0),
                    scaling, runtime
)
names(df.new) <- df_names
df.new

# Add to df.
df <- rbind(df, df.new)