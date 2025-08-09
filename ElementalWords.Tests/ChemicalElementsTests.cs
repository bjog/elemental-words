namespace ElementalWords.Tests;

/// <summary>
/// Unit tests for <see cref="ChemicalElements"/>.
/// </summary>
[TestFixture]
public class ChemicalElementsTests
{
    private const int NUMBER_OF_ELEMENTS = 118;

    [Test]
    [TestCaseSource(typeof(ChemicalElementsTestCases), nameof(ChemicalElementsTestCases.ValidChemicalSymbolTestCases))]
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
    [TestCaseSource(typeof(ChemicalElementsTestCases), nameof(ChemicalElementsTestCases.InvalidChemicalSymbolTestCases))]
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
    [TestCaseSource(typeof(ChemicalElementsTestCases), nameof(ChemicalElementsTestCases.ChemicalSymbolCompletenessTestCases))]
    public void ChemicalElements_ContainsAllElements(IEnumerable<string> allChemicalSymbols)
    {
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