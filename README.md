# README

This is a solution to the CodeWars Kata problem, 'Elemental Words' found here: https://www.codewars.com/kata/56fa9cd6da8ca623f9001233

The problem description has also been included in the file `PROBLEM.md`.

This solution is implemented using .NET 8.

## Running the application

From the root directory you can build the application from the terminal using `dotnet build`, or building the solution in Visual Studio.

Then run the application using `dotnet run --project .\ElementalWords\`, or by running the `ElementalWords` project in Visual Studio.

This starts the interactive mode, where you can input a word, press `Enter` and the elemental forms of the word will be outputted to the terminal.

## Notes 

The main functionality is in the `ElementalWords` class, it uses a recursive algorithm to build solutions for the elemental forms of a given word. Specifically, it splits a word up into its 'chemical symbol forms', then converts the chemical symbol forms into the elemental forms. 

A helper class `ChemicalElements` provides a mapping of all chemical element symbols to its elemental form, as well as some conversion methods.

Unit tests are stored in the `ElementWords.Tests` project, and can be run in the terminal using the `dotnet test` command, or by using the test runner within Visual Studio.

My implementation assumes that we are using the current periodic table (c. 2025), where the maximum length of a chemical symbol is `2`. In older periodic tables there were symbols that had `3` characters. 

In addition, the names of some elements have changed in history and may have different spellings based on whether its the UK or US spelling. I am using the current names of the elements and opting to use the UK spelling.