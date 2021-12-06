using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MorseTranslate.Model;

namespace MorseTranslate.Translate
{
    public class CodeMorse
    {

        private const string separatorCode = " ";
        private const string separatorText = " ";
        private const string separatorWordCode = "/ ";

        private readonly string dot = ".";
        private readonly string dash = "-";

        private readonly List<Morse> morses;

        public CodeMorse()
        {
            morses = new List<Morse>();
            morses.AddRange(GenerateLetters());
            morses.AddRange(GenerateNumbers());
        }

        public string Encode(string text)
        {

            StringBuilder textShurffle = new StringBuilder();
            StringBuilder wordShurfle;

            IEnumerable<string> words = text.ToUpper().Split(separatorText);
            
            foreach (var word in words)
            {
                wordShurfle = new StringBuilder();
                foreach(var letter in word)
                {
                    wordShurfle.Append(SearchCharacter(letter.ToString(), true) + separatorCode);
                }

                textShurffle.Append(wordShurfle + separatorWordCode);
            }

            return textShurffle.ToString();
        }

        public string Decode(string text)
        {

            StringBuilder textUnscramble = new StringBuilder();
            StringBuilder wordUnscramble;

            IEnumerable<string> words = text.Split(separatorWordCode);

            foreach (var word in words)
            {
                wordUnscramble = new StringBuilder();
                foreach (var letter in word.Split(separatorCode))
                {
                    wordUnscramble.Append(SearchCharacter(letter.ToString(), false));
                }
                textUnscramble.Append(wordUnscramble + separatorText);
            }

            return textUnscramble.ToString();
        }

        private string SearchCharacter(string text, bool shurfle = true)
        {
            Morse morse;

            if (shurfle)
            {
                morse = morses.FirstOrDefault(m => m.Letter.Equals(text));
                return (morse != null ) ? morse.Cod : "";
            }

            morse = morses.FirstOrDefault(m => m.Cod.Equals(text));
            return (morse != null) ? morse.Letter : "";
        }

        private IEnumerable<Morse> GenerateLetters()
        {
            return new List<Morse>()
            {
                new Morse(){ Cod = string.Concat(dot, dash), Letter = "A" },
                new Morse(){ Cod = string.Concat(dash, dot, dot, dot), Letter = "B" },
                new Morse(){ Cod = string.Concat(dash, dot, dash, dot), Letter = "C" },
                new Morse(){ Cod = string.Concat(dash, dot, dot), Letter = "D" },
                new Morse(){ Cod = dot, Letter = "E" },
                new Morse(){ Cod = string.Concat(dot, dot, dash, dot), Letter = "F" },
                new Morse(){ Cod = string.Concat(dash, dash, dot), Letter = "G" },
                new Morse(){ Cod = string.Concat(dot, dot, dot, dot), Letter = "H" },
                new Morse(){ Cod = string.Concat(dot, dot), Letter = "I" },
                new Morse(){ Cod = string.Concat(dot, dash, dash, dash), Letter = "J" },
                new Morse(){ Cod = string.Concat(dash, dot, dash), Letter = "K" },
                new Morse(){ Cod = string.Concat(dot, dash, dot, dot), Letter = "L" },
                new Morse(){ Cod = string.Concat(dash, dash), Letter = "M" },
                new Morse(){ Cod = string.Concat(dash, dot), Letter = "N" },
                new Morse(){ Cod = string.Concat(dash, dash, dash), Letter = "O" },
                new Morse(){ Cod = string.Concat(dot, dash, dash, dot), Letter = "P" },
                new Morse(){ Cod = string.Concat(dash, dash, dot, dash), Letter = "Q" },
                new Morse(){ Cod = string.Concat(dot, dash, dot), Letter = "R" },
                new Morse(){ Cod = string.Concat(dot, dot, dot), Letter = "S" },
                new Morse(){ Cod = dash, Letter = "T" },
                new Morse(){ Cod = string.Concat(dot, dot, dash), Letter = "U" },
                new Morse(){ Cod = string.Concat(dot, dot, dot, dash), Letter = "V" },
                new Morse(){ Cod = string.Concat(dot, dash, dash), Letter = "W" },
                new Morse(){ Cod = string.Concat(dash, dot, dot, dash), Letter = "X" },
                new Morse(){ Cod = string.Concat(dash, dot, dash, dash), Letter = "Y" },
                new Morse(){ Cod = string.Concat(dash, dash, dot, dot), Letter = "Z" }
            };
        }

        private IEnumerable<Morse> GenerateNumbers()
        {
            return new List<Morse>()
            {
                new Morse(){ Cod = string.Concat(dot, dash, dash, dash, dash), Letter = "1" },
                new Morse(){ Cod = string.Concat(dot, dot, dash, dash, dash), Letter = "2" },
                new Morse(){ Cod = string.Concat(dot, dot, dot, dash, dash), Letter = "3" },
                new Morse(){ Cod = string.Concat(dot, dot, dot, dot, dash), Letter = "4" },
                new Morse(){ Cod = string.Concat(dot, dot, dot, dot, dot), Letter = "5" },
                new Morse(){ Cod = string.Concat(dash, dot, dot, dot, dot), Letter = "6" },
                new Morse(){ Cod = string.Concat(dash, dash, dot, dot, dot), Letter = "7" },
                new Morse(){ Cod = string.Concat(dash, dash, dash, dot, dot), Letter = "8" },
                new Morse(){ Cod = string.Concat(dash, dash, dash, dash, dot), Letter = "9" },
                new Morse(){ Cod = string.Concat(dash, dash, dash, dash, dash), Letter = "10" }
            };
        }
    }
}
