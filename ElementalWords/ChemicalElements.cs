using System.ComponentModel.DataAnnotations;

namespace ElementalWords
{
    /// <summary>
    /// Helper class for mapping from chemical symbol forms to 'elemental forms' of chemical elements.
    /// </summary>
    /// <remarks>
    /// The elemental form has the form: <code>Chemical Name (Chemical Symbol)</code>
    /// </remarks>
    public static class ChemicalElements
    {
        /// <summary>
        /// Maps from chemical symbol to its elemental form.
        /// </summary>
        /// <remarks>
        /// The chemical symbol key is represented in upper-case.
        /// </remarks> 
        private static readonly IReadOnlyDictionary<string, string> elementsDictionary = new Dictionary<string, string>()
        {
            {"H", "Hydrogen (H)"},
            {"XE", "Xenon (Xe)" },
            {"AC", "Actinium (Ac)"},
            {"B", "Boron (B)"},
            {"O", "Oxygen (O)"},
            {"N", "Nitrogen (N)"},
            {"BA", "Barium (Ba)"},
            {"CO", "Cobalt (Co)"},
            {"C", "Carbon (C)"}
        };

        public static bool IsValidChemicalSymbol(string chemicalSymbol)
        {
            return elementsDictionary.ContainsKey(chemicalSymbol.ToUpper());
        }

        /// <summary>
        /// Converts the given chemical symbols to their elemental forms.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when any of the given <paramref name="chemicalSymbolForms"/> is not a valid chemical symbol.
        /// </exception>
        public static IEnumerable<string> ConvertFromChemicalSymbolToElementalForm(IEnumerable<string> chemicalSymbolForms)
        {
            return chemicalSymbolForms
                .Select(ConvertFromChemicalSymbolToElementalForm)
                .ToList();
        }
        
        /// <summary>
        /// Converts the given chemical symbol to its elemental form.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the given <paramref name="chemicalSymbolForm"/> is not a valid chemical symbol.
        /// </exception>
        private static string ConvertFromChemicalSymbolToElementalForm(string chemicalSymbolForm)
        {
            if(elementsDictionary.TryGetValue(chemicalSymbolForm.ToUpper(), out var elementalForm))
            {
                return elementalForm;
            }

            throw new ArgumentException($"Unable to convert the chemical symbol '{chemicalSymbolForm}' as it was not a valid chemical symbol.");
        }
    }
}