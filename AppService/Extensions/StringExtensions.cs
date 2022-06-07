using System;

namespace Teste.API.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets int value from char at any index of a string. Can see more about GetNumericValue here <see href="https://docs.microsoft.com/pt-br/dotnet/api/system.char.getnumericvalue?view=net-6.0"/>
        /// </summary>
        /// 
        /// <remarks>
        /// Because of Unicode inside of char we can't just use the index normally from an string
        /// if we intend to work with numbers we need use a specfic method for it, for example
        /// the char value of an int 1 is <code>49 '1'</code> the 49 is representing the Unicode of that one int 1 and
        /// because of that the method <code>char.GetNumericValue</code> helps us to get 
        /// only the value 1 from that char and not with the Unicode(49) that comes together.
        /// </remarks>
        /// 
        /// <param name="value"></param>
        /// <param name="index">Represents de index of that string that you to convert to int <seealso href="https://docs.microsoft.com/pt-br/dotnet/api/system.index?view=net-6.0"/></param>
        /// 
        /// <returns>int value from the char at specified index</returns>
        public static int ToIntAt(this string value, Index index)
        {
            var indexValue = index.IsFromEnd 
                ? value.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(value, indexValue);
        }
    }
}
