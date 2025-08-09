namespace ElementalWords.Tests
{
    /// <summary>
    /// Unit test cases for <see cref="ChemicalElementsTests"/>.
    /// </summary>
    internal static class ChemicalElementsTestCases
    {
        public static IEnumerable<TestCaseData> ValidChemicalSymbolTestCases
        {
            get
            {
                yield return new TestCaseData(
                    [new string[] { "H" }, new string[] { "Hydrogen (H)" }]);

                yield return new TestCaseData(
                    [new string[] { "Ac" }, new string[] { "Actinium (Ac)" }]);

                yield return new TestCaseData(
                    [new string[] { "H", "Ac" }, new string[] { "Hydrogen (H)", "Actinium (Ac)" }]);
            }
        }

        public static IEnumerable<TestCaseData> InvalidChemicalSymbolTestCases
        {
            get
            {
                yield return new TestCaseData(
                    [new string[] { "X" }]);

                yield return new TestCaseData(
                    [new string[] { "123" }]);

                yield return new TestCaseData(
                    [new string[] { "H", "?" }]);
            }
        }

        public static IEnumerable<TestCaseData> ChemicalSymbolCompletenessTestCases
        {
            get
            {
                string[] allChemicalSymbols = [
                    "H",
                    "He",
                    "Li",
                    "Be",
                    "B",
                    "C",
                    "N",
                    "O",
                    "F",
                    "Ne",
                    "Na",
                    "Mg",
                    "Al",
                    "Si",
                    "P",
                    "S",
                    "Cl",
                    "Ar",
                    "K",
                    "Ca",
                    "Sc",
                    "Ti",
                    "V",
                    "Cr",
                    "Mn",
                    "Fe",
                    "Co",
                    "Ni",
                    "Cu",
                    "Zn",
                    "Ga",
                    "Ge",
                    "As",
                    "Se",
                    "Br",
                    "Kr",
                    "Rb",
                    "Sr",
                    "Y",
                    "Zr",
                    "Nb",
                    "Mo",
                    "Tc",
                    "Ru",
                    "Rh",
                    "Pd",
                    "Ag",
                    "Cd",
                    "In",
                    "Sn",
                    "Sb",
                    "Te",
                    "I",
                    "Xe",
                    "Cs",
                    "Ba",
                    "La",
                    "Ce",
                    "Pr",
                    "Nd",
                    "Pm",
                    "Sm",
                    "Eu",
                    "Gd",
                    "Tb",
                    "Dy",
                    "Ho",
                    "Er",
                    "Tm",
                    "Yb",
                    "Lu",
                    "Hf",
                    "Ta",
                    "W",
                    "Re",
                    "Os",
                    "Ir",
                    "Pt",
                    "Au",
                    "Hg",
                    "Tl",
                    "Pb",
                    "Bi",
                    "Po",
                    "At",
                    "Rn",
                    "Fr",
                    "Ra",
                    "Ac",
                    "Th",
                    "Pa",
                    "U",
                    "Np",
                    "Pu",
                    "Am",
                    "Cm",
                    "Bk",
                    "Cf",
                    "Es",
                    "Fm",
                    "Md",
                    "No",
                    "Lr",
                    "Rf",
                    "Db",
                    "Sg",
                    "Bh",
                    "Hs",
                    "Mt",
                    "Ds",
                    "Rg",
                    "Cn",
                    "Nh",
                    "Fl",
                    "Mc",
                    "Lv",
                    "Ts",
                    "Og"];

                yield return new TestCaseData([allChemicalSymbols]);
            }
        }
    }
}
