namespace ElementalWords.Tests;

public class ChemicalElementsTests
{
    private static IEnumerable<TestCaseData> ValidChemicalSymbolTestCases
    {
        get
        {
            yield return new TestCaseData(
                [new string[] { "H" }, new string[] { "Hydrogen (H)" }]);

            yield return new TestCaseData(
                [new string[] { "Ac" }, new string[] { "Actinium (Ac)" }]);

            yield return new TestCaseData(
                [new string[] { "H", "Ac" }, new string[] { "Hydrogen (H)", "Actinium (Ac)"}]);
        }
    }

    private static IEnumerable<TestCaseData> InvalidChemicalSymbolTestCases
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

    private static IEnumerable<TestCaseData> ChemicalSymbolCompletenessTestCases
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

    [Test]
    [TestCaseSource(nameof(ValidChemicalSymbolTestCases))]
    public void ConvertingChemicalSymbols_WhenChemicalSymbolsValid_ReturnsElementalForms(
        IEnumerable<string> chemicalSymbols, 
        IEnumerable<string> expectedElementalForms)
    {
        // Act
        var results = ChemicalElements.ConvertFromChemicalSymbolToElementalForm(chemicalSymbols);

        // Assert
        Assert.That(results, Is.EquivalentTo(expectedElementalForms));
    }

    [Test]
    [TestCaseSource(nameof(InvalidChemicalSymbolTestCases))]
    public void ConvertingChemicalSymbols_WhenAnyChemicalSymbolsInvalid_ThrowsArgumentException(
        IEnumerable<string> chemicalSymbols)
    {
        // Act + Assert
        Assert.Throws<ArgumentException>(() => ChemicalElements.ConvertFromChemicalSymbolToElementalForm(chemicalSymbols));
    }

    [Test]
    [TestCase("Ac")]
    [TestCase("AC")]
    [TestCase("ac")]
    [TestCase("aC")]
    public void ConvertingChemicalSymbols_IsCaseInsensitive_ReturnsElementalForms(string chemicalSymbol)
    {
        // Arrange
        IEnumerable<string> expectedResult = ["Actinium (Ac)"];

        // Act
        var result = ChemicalElements.ConvertFromChemicalSymbolToElementalForm([chemicalSymbol]);

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    [Test]
    [TestCase("H")]
    [TestCase("Ac")]
    [TestCase("Xe")]
    [TestCase("Co")]
    public void IsValidChemicalSymbol_WhenValid_ReturnsTrue(string symbol)
    {
        // Act
        var result = ChemicalElements.IsValidChemicalSymbol(symbol);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    [TestCase("Hi")]
    [TestCase("X")]
    [TestCase("1")]
    [TestCase("?")]
    public void IsValidChemicalSymbol_WhenInvalid_ReturnsFalse(string symbol)
    {
        // Act
        var result = ChemicalElements.IsValidChemicalSymbol(symbol);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    [TestCase("Ac")]
    [TestCase("AC")]
    [TestCase("ac")]
    [TestCase("aC")]
    public void IsValidChemicalSymbol_IsCaseInsensitive(string symbol)
    {
        // Act
        var result = ChemicalElements.IsValidChemicalSymbol(symbol);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    [TestCaseSource(nameof(ChemicalSymbolCompletenessTestCases))]
    public void ChemicalElements_ContainsAllElements(IEnumerable<string> allChemicalSymbols)
    {
        // Arrange
        const int NUMBER_OF_ELEMENTS = 118;

        // Act + Assert
        foreach (var symbol in allChemicalSymbols)
        {
            Assert.That(
                ChemicalElements.IsValidChemicalSymbol(symbol),
                Is.True);
        }

        Assert.That(allChemicalSymbols.Count(), Is.EqualTo(NUMBER_OF_ELEMENTS));
        Assert.That(allChemicalSymbols.Distinct().Count(), Is.EqualTo(NUMBER_OF_ELEMENTS));
    }
}