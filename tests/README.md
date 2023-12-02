# Unit tests for Advent of Code 2023  

:christmas_tree:

This is me having a go at solving the puzzles in [Advent Of Code 2023](https://adventofcode.com/2023/)  
I'm using .NET 7 for the solutions.  
I also have some shellscripts and python scripts for "housekeeping" (managing downloads of input data, creating projects and stuff) just to keep the days looking alike, and not forgetting references and stuff like that.

- I have sorted the different days into subprojects in separate folders, but they should all be gathered together via the Solution file.  
- The inputs for each day are stored under the [/data](/data) folder, and when possible/feasible I store a file with the days testinputs as well.  
- Unit tests - if and when I'm a good boy - are stored under the [/tests](/tests) folder.  
- The [/common](/common) project is where I'll store things which might span several days/puzzles - as we have seen a few times, for example the INTCODE stuff from 2019.  
Or if I come up with some fantastic tool myself, for parsing or reinventing some other type of wheel.
