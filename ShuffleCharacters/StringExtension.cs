using System;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations is less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source string is null or empty or white spaces.", nameof(source));
            }
            else if (count < 0)
            {
                throw new ArgumentException("Count of iterations is less than 0.", nameof(count));
            }

            string shuffleChars = source;
            int iter = 0;
            while (iter < count)
            {
                string oddCharacters = string.Empty;
                string evenCharacters = string.Empty;
                for (int i = 0; i < shuffleChars.Length; i++)
                {
                    if ((i & 1) == 1)
                    {
                        evenCharacters = string.Concat(evenCharacters, shuffleChars[i]);
                    }
                    else
                    {
                        oddCharacters = string.Concat(oddCharacters, shuffleChars[i]);
                    }
                }

                shuffleChars = string.Concat(oddCharacters, evenCharacters);
                iter++;
                if (shuffleChars == source)
                {
                    count -= count / iter * iter;
                    iter = 0;
                }
            }

            return shuffleChars;
        }
    }
}
