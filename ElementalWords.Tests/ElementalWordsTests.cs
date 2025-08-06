namespace ElementalWords.Tests
{
    public class ElementalWordsTests
    {
        [Test]
        public void FindElementalForms_WhenWordIsEmptyString_ReturnsEmpty()
        {
            // Act
            var results = ElementalWords.FindElementalForms(string.Empty);

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        [TestCase("X")]
        [TestCase("XA")]
        [TestCase("1")]
        [TestCase("123")]
        [TestCase("?")]
        public void FindElementalForms_WhenWordHasNoElementalForm_ReturnsEmpty(string word)
        {
            // Act
            var results = ElementalWords.FindElementalForms(word);

            // Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        [TestCase("H", "Hydrogen (H)")]
        [TestCase("Xe", "Xenon (Xe)")]
        [TestCase("Ac", "Actinium (Ac)" )]
        public void FindElementalForms_WhenWordHasSingleElementalForm_ReturnsElementalForm(string word, string expectedResult)
        {
            // Act
            var results = ElementalWords.FindElementalForms(word);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(results.Count, Is.EqualTo(1));
                
                var result = results.First();
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result.First(), Is.EqualTo(expectedResult));
            });
        }

        [Test]
        public void FindElementalForms_WhenWordHasMultipleElementalForms_ReturnsElementalForms()
        {
            // Arrange
            IEnumerable<IEnumerable<string>> expectedResults =
                [
                    ["Boron (B)", "Actinium (Ac)", "Oxygen (O)", "Nitrogen (N)"],
                    ["Barium (Ba)", "Cobalt (Co)", "Nitrogen (N)"],
                    ["Barium (Ba)", "Carbon (C)", "Oxygen (O)", "Nitrogen (N)"]
                ];

            // Act
            var results = ElementalWords.FindElementalForms("Bacon");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(results.Count, Is.EqualTo(3));
                Assert.That(results, Is.EquivalentTo(expectedResults));
            });
        }

        [Test]
        [TestCase("Ac")]
        [TestCase("AC")]
        [TestCase("ac")]
        [TestCase("aC")]
        public void FindElementalForms_IsCaseInsensitive(string word)
        {
            // Arrange
            var expectedResult = "Actinium (Ac)";

            // Act
            var results = ElementalWords.FindElementalForms(word);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(results.Count, Is.EqualTo(1));

                var result = results.First();
                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result.First(), Is.EqualTo(expectedResult));
            });
        }
    }
}