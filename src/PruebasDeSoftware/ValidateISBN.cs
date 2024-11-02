using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasDeSoftware
{
    public class ValidateISBN
    {
        public const int ISBN_SHORT = 10;
        public const int ISBN_LONG = 13;
        public const int ISBN_SHORT_VALIDATOR = 11;
        public const int ISBN_LONG_VALIDATOR = 10;

        public bool CheckISBN(string isbn)
        {
            if (isbn.Length == ISBN_SHORT || isbn.Length == ISBN_LONG)
            {
                if (isbn.Length == ISBN_LONG)
                {
                    return CheckISBNThirteenDigits(isbn);
                }
                else
                {
                    return CheckISBNTenDigits(isbn);
                }
            }
            else
            {
                throw new FormatException("ISBN number should have a length of 10 or 13.");
            }
        }

        private bool CheckISBNTenDigits(string isbn)
        {
            int total = 0;
            for (int i = 0; i < ISBN_SHORT; i++)
            {
                if (!char.IsDigit(isbn[i]))
                {
                    if (i == 9 && isbn[i] == 'X')
                    {
                        total += 10;
                    }
                    else
                    {
                        throw new FormatException("ISBN numbers can only have digits.");
                    }
                }
                else
                {
                    total += (isbn[i] - '0') * (ISBN_SHORT - i);
                }
            }
            return total % ISBN_SHORT_VALIDATOR == 0;
        }

        private bool CheckISBNThirteenDigits(string isbn)
        {
            int total = 0;
            for (int i = 0; i < ISBN_LONG; i++)
            {
                if (char.IsDigit(isbn[i]))
                {
                    int digit = isbn[i] - '0';
                    total += (i % 2 == 0) ? digit : digit * 3;
                }
                else
                {
                    throw new FormatException("ISBN numbers can only have digits.");
                }
            }
            return total % ISBN_LONG_VALIDATOR == 0;
        }
    }
}
