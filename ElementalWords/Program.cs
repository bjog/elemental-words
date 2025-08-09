namespace ElementalWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input a word: ");
                var input = Console.ReadLine();

                var elementalForms = ElementalWords.FindElementalForms(input ?? string.Empty);

                Console.WriteLine("Elemental Forms: ");

                foreach (var elementalForm in elementalForms)
                {
                    Console.WriteLine(string.Join(", ", elementalForm));
                }
            }
        }
    }
}