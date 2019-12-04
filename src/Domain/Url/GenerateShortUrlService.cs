using System.Linq;

namespace Domain.Url
{
    // https://en.wikipedia.org/wiki/Bijection
    public static class GenerateShortUrlService
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int Base = Alphabet.Length;

        public static string Encode(int i)
        {
            if (i == 0)
            {
                return Alphabet[0].ToString();
            }

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i /= Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }
    }
}