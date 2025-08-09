namespace ElementalWords
{
    /// <summary>
    /// Represents a class for converting words into their 'elemental forms'.
    /// </summary>
    /// <remarks>
    /// The elemental form of the word 'Hi' would be: <code>Hydrogen (H), Iodine (I))</code>
    /// </remarks>
    public static class ElementalWords
    {
        private const int CHEMICAL_SYMBOL_MAX_LENGTH = 2; // note: in the current periodic table element symbols have a max length of 2.

        /// <summary>
        /// Finds all possible elemental forms for the given <paramref name="word"/>.
        /// </summary>
        /// <param name="word">
        /// The input word.
        /// </param>
        /// <returns>
        /// The elemental forms of <paramref name="word"/>, or empty if none were found.
        /// </returns>
        public static IEnumerable<IEnumerable<string>> FindElementalForms(string word)
        {
            if (word == string.Empty)
            {
                return [];
            }

            List<IEnumerable<string>> foundChemicalSymbolForms = [];

            FindChemicalSymbolForms(foundChemicalSymbolForms, word, 0, []);

            var foundElementalForms = foundChemicalSymbolForms
                .Select(ChemicalElements.ConvertFromChemicalSymbolToElementalForm);

            return foundElementalForms;
        }

        /// <summary>
        /// Recursively finds all 'chemical symbol forms' of the given <paramref name="word"/> and populates <paramref name="foundChemicalSymbolForms"/> with the results.
        /// </summary>
        /// <param name="foundChemicalSymbolForms">
        /// The found chemical symbol forms of <paramref name="word"/>, empty if none have been found.
        /// </param>
        /// <param name="word">
        /// The input word.
        /// </param>
        /// <param name="characterPosition">
        /// The start position in <paramref name="word"/> from which to find the chemical symbol forms.
        /// </param>
        /// <param name="currentChemicalSymbolFormCandidate">
        /// The current partial solution candidate for a valid chemical symbol form.
        /// </param>
        /// <remarks>
        /// The 'chemical symbol form' of a word is its representation as a collection of chemical symbols. <br/>
        /// For example, the chemical symbol forms of the word 'Cob' would be: <c>C,O,B</c> and <c>Co,B</c> <br/>
        /// </remarks>
        private static void FindChemicalSymbolForms(
            ICollection<IEnumerable<string>> foundChemicalSymbolForms,
            string word,
            int characterPosition,
            Stack<string> currentChemicalSymbolFormCandidate)
        {
            if (characterPosition >= word.Length)
            {
                foundChemicalSymbolForms.Add(
                    currentChemicalSymbolFormCandidate
                    .Reverse() // note: since we are using a stack, we have to reverse the ordering, otherwise the resulting chemical symbol form will be reversed.
                    .ToList());

                return;
            }

            var nextChemicalSymbolCandidates = GetNextChemicalSymbolCandidates(word, characterPosition);

            foreach (var chemicalSymbolCandidate in nextChemicalSymbolCandidates)
            {
                currentChemicalSymbolFormCandidate.Push(chemicalSymbolCandidate);

                FindChemicalSymbolForms(foundChemicalSymbolForms, word, characterPosition + chemicalSymbolCandidate.Length, currentChemicalSymbolFormCandidate);
                currentChemicalSymbolFormCandidate.Pop();
            }
        }

        /// <summary>
        /// Finds the next valid chemical symbols at the current <paramref name="characterPosition"/> in the given <paramref name="word"/>.
        /// </summary>
        /// <param name="word">
        /// The input word.
        /// </param>
        /// <param name="characterPosition">
        /// The position in <paramref name="word"/> from which to find the next valid chemical symbol.
        /// </param>
        /// <returns>
        /// The next valid chemical symbols, empty if none were found.
        /// </returns>
        private static IEnumerable<string> GetNextChemicalSymbolCandidates(string word, int characterPosition)
        {
            List<string> nextChemicalSymbolCandidates = [];

            int remainingCharacterCount = word.Length - characterPosition;
            int substringMaxLength = Math.Min(remainingCharacterCount, CHEMICAL_SYMBOL_MAX_LENGTH);

            for (int substringLength = 1; substringLength <= substringMaxLength; substringLength++)
            {
                var possibleChemicalSymbol = word
                    .Substring(characterPosition, substringLength);

                if (ChemicalElements.IsValidChemicalSymbol(possibleChemicalSymbol))
                {
                    nextChemicalSymbolCandidates.Add(possibleChemicalSymbol);
                }
            }

            return nextChemicalSymbolCandidates;
        }
    }
}
