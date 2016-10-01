using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TS3QueryLib.Net.Core.Common
{
    public class Util
    {
        #region Constants

        public const string QUERY_LINE_BREAK = "\n\r";
        public const string QUERY_REGEX_LINE_BREAK = @"\x0A\x0D";

        #endregion

        #region Non Public Members

        protected static Dictionary<string, string> EscapeCharacters { get; }
        protected static string DecodePattern { get; }

        #endregion

        #region Constructor

        static Util()
        {
            EscapeCharacters = new Dictionary<string, string>
            {
                { "\\", @"\\" }, { "/", @"\/" },  { " ", @"\s" },  { "|", @"\p" },  { "\a", @"\a" }, { "\b", @"\b" },
                { "\f", @"\f" }, { "\n", @"\n" }, { "\r", @"\r" }, { "\t", @"\t" }, { "\v", @"\v" }
            };

            DecodePattern = string.Join("|", EscapeCharacters.Select(x => string.Format("({0})", Regex.Escape(x.Value))).ToArray());
        }

        #endregion

        #region Public Methods

        public static string EncodeString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            StringBuilder result = new StringBuilder(value);

            foreach (KeyValuePair<string, string> escapeCharacter in EscapeCharacters)
            {
                result.Replace(escapeCharacter.Key, escapeCharacter.Value);
            }

            return result.ToString();
        }

        public static string DecodeString(string value)
        {
            return string.IsNullOrEmpty(value) ? value : Regex.Replace(value, DecodePattern, ReplaceEncodedValue, RegexOptions.Singleline);
        }

        private static string ReplaceEncodedValue(Match match)
        {
            return EscapeCharacters.First(kvp => kvp.Value == match.Value).Key;
        }

        #endregion
    }
}