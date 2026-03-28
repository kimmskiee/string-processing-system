using System;

using StringProcessingApp.Services;

namespace StringProcessingApp.Views
{
    public class StringView
    {
        private readonly StringService _stringService;

        public StringView()
        {
            _stringService = new StringService();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        EnterText();
                        break;
                    case "2":
                        ViewCurrentText();
                        break;
                    case "3":
                        ConvertToUppercase();
                        break;
                    case "4":
                        ConvertToLowercase();
                        break;
                    case "5":
                        CountCharacters();
                        break;
                    case "6":
                        CheckContainsWord();
                        break;
                    case "7":
                        ReplaceWord();
                        break;
                    case "8":
                        ExtractSubstring();
                        break;
                    case "9":
                        TrimSpaces();
                        break;
                    case "10":
                        ResetText();
                        break;
                    case "11":
                        running = false;
                        Console.WriteLine("Thank you for using String Processing System!");
                        break;
                    default:
                        Console.WriteLine("❌ Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("             MAIN MENU");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine(" 1.  Enter Text");
            Console.WriteLine(" 2.  View Current Text");
            Console.WriteLine(" 3.  Convert to UPPERCASE");
            Console.WriteLine(" 4.  Convert to lowercase");
            Console.WriteLine(" 5.  Count Characters");
            Console.WriteLine(" 6.  Check if Contains Word");
            Console.WriteLine(" 7.  Replace Word");
            Console.WriteLine(" 8.  Extract Substring");
            Console.WriteLine(" 9.  Trim Spaces");
            Console.WriteLine(" 10. Reset Text");
            Console.WriteLine(" 11. Exit");
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Enter your choice: ");
        }

        private void EnterText()
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            _stringService.SetText(text);
            Console.WriteLine("✓ Text entered successfully!");
        }

        private void ViewCurrentText()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
            }
            else
            {
                Console.WriteLine("Current Text:");
                Console.WriteLine($"─────────────────────────────────────");
                Console.WriteLine(_stringService.GetCurrentText());
                Console.WriteLine($"─────────────────────────────────────");
            }
        }

        private void ConvertToUppercase()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            string result = _stringService.ConvertToUppercase();
            Console.WriteLine("✓ Converted to UPPERCASE:");
            Console.WriteLine(result);
        }

        private void ConvertToLowercase()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            string result = _stringService.ConvertToLowercase();
            Console.WriteLine("✓ Converted to lowercase:");
            Console.WriteLine(result);
        }

        private void CountCharacters()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            int count = _stringService.CountCharacters();
            Console.WriteLine($"✓ Character count: {count}");
        }

        private void CheckContainsWord()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            Console.Write("Enter word to search: ");
            string word = Console.ReadLine();

            bool contains = _stringService.ContainsWord(word);
            if (contains)
            {
                Console.WriteLine($"✓ The text CONTAINS the word '{word}'");
            }
            else
            {
                Console.WriteLine($"✗ The text DOES NOT contain the word '{word}'");
            }
        }

        private void ReplaceWord()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            Console.Write("Enter word to replace: ");
            string oldWord = Console.ReadLine();
            Console.Write("Enter new word: ");
            string newWord = Console.ReadLine();

            string result = _stringService.ReplaceWord(oldWord, newWord);
            Console.WriteLine("✓ Word replaced successfully:");
            Console.WriteLine(result);
        }

        private void ExtractSubstring()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            Console.WriteLine($"Current text length: {_stringService.CountCharacters()}");
            Console.Write("Enter start index (0-based): ");

            if (!int.TryParse(Console.ReadLine(), out int startIndex))
            {
                Console.WriteLine("❌ Invalid input. Please enter a number.");
                return;
            }

            Console.Write("Enter length: ");
            if (!int.TryParse(Console.ReadLine(), out int length))
            {
                Console.WriteLine("❌ Invalid input. Please enter a number.");
                return;
            }

            string result = _stringService.ExtractSubstring(startIndex, length);
            Console.WriteLine("✓ Extracted substring:");
            Console.WriteLine(result);
        }

        private void TrimSpaces()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            string result = _stringService.TrimSpaces();
            Console.WriteLine("✓ Spaces trimmed:");
            Console.WriteLine($"'{result}'");
        }

        private void ResetText()
        {
            if (_stringService.IsTextEmpty())
            {
                Console.WriteLine("⚠ No text entered yet. Please enter text first.");
                return;
            }

            string result = _stringService.ResetText();
            Console.WriteLine("✓ Text reset to original:");
            Console.WriteLine(result);
        }
    }
}