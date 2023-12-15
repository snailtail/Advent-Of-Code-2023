# Advent of Code 2023 Day11  

## Part 1  

Not that complicated. Parse the data, today I used a string for the data, and calculated column and row positions using indexes. This (in my opinion) made adding columns and rows kind of easier.
After extending the map, it was just a matter of scanning for the galaxies coordinates, calculating the manhattan distances between all possible pairs and printing the sum of those distances.  

