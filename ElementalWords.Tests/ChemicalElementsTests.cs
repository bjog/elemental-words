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
}
