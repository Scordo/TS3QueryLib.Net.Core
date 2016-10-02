using System;
using System.Text.RegularExpressions;

namespace TS3QueryLib.Net.Core.Common.Entities
{
    public class SpacerInfo : IDump
    {
        #region Properties

        public SpacerAlignment Alignment { get; private set; }
        public string Name { get; private set; }
        public string VisibleName { get; private set; }

        #endregion

        #region Public Methods
        
        public static SpacerInfo Parse(string channelName)
        {
            if (channelName.IsNullOrTrimmedEmpty())
                return null;

            const string PATTERN = @"\[(?<Alignment>r|l|c|\*)spacer.*?\](?<VisibleName>.*)";
            Match match = Regex.Match(channelName, PATTERN, RegexOptions.Singleline);

            if (!match.Success)
                return null;

            char alignmentChar = match.Groups["Alignment"].Value[0];
            SpacerAlignment alignment = SpacerAlignment.Repeat;
            switch (alignmentChar)
            {
                case 'c':
                    alignment = SpacerAlignment.Center;
                    break;
                case 'r':
                    alignment = SpacerAlignment.Right;
                    break;
                case 'l':
                    alignment = SpacerAlignment.Left;
                    break;
            }

            string visibleName = match.Groups["VisibleName"].Value.Trim();

            if (visibleName.IsNullOrTrimmedEmpty())
                visibleName = channelName.Trim();

            return new SpacerInfo { Alignment = alignment, Name = channelName.Trim(), VisibleName = visibleName };
        }

        #endregion

        
    }
}
