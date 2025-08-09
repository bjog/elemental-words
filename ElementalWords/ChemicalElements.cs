namespace ElementalWords
{
    /// <summary>
    /// Helper class for mapping from chemical symbol forms to 'elemental forms' of chemical elements.
    /// </summary>
    /// <remarks>
    /// The elemental form has the form <code>Chemical Name (Chemical Symbol)</code>
    /// </remarks>
    internal static class ChemicalElements
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

        /// <summary>
        /// Gets the mapping from chemical symbol to chemical name.
        /// </summary>
        /// <remarks>
        /// The chemical symbol key is represented in upper-case.
        /// </remarks>
        public static IReadOnlyDictionary<string, string> ElementSymbolToName
        {
            get
            {
                return elementsDictionary;
            }
        }

        public static IEnumerable<string> ConvertFromChemicalSymbolToElementalForm(IEnumerable<string> chemicalSymbolForm)
        {
            return chemicalSymbolForm
                .Select(ConvertFromChemicalSymbolToElementalForm);
        }
        
        private static string ConvertFromChemicalSymbolToElementalForm(string chemicalSymbolForm)
        {
            return ChemicalElements.ElementSymbolToName[chemicalSymbolForm];
        }
    }
}