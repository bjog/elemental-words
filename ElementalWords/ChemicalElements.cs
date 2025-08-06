namespace ElementalWords
{
    internal static class ChemicalElements
    {
        /// <summary>
        /// Dictionary mapping from the chemical symbol to chemical name.
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
        /// Gets the dictionary mapping from chemical symbol to chemical name.
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
    }
}