namespace ElementalWords
{
    public static class ElementalWords
    {
        private const int CHEMICAL_SYMBOL_MAX_LENGTH = 3;

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
                    .Reverse()
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
