using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS3QueryLib.Net.Core.Common.CommandHandling;

namespace TS3QueryLib.Net.Core.Common.Commands
{
    public class Command
    {
        #region Properties

        public string Name { get; protected set; }
        protected List<string> Options { get; set; }
        protected CommandParameterGroupList ParameterGroups { get; set; }

        #endregion

        #region Constructors

        public Command(string commandName, params string[] options)
        {
            if (commandName.IsNullOrTrimmedEmpty())
                throw new ArgumentException("commandName is null or emtpy", nameof(commandName));

            Name = commandName;
            ParameterGroups = new CommandParameterGroupList();
            Options = new List<string>();
            options.ForEach(AddOption);
        }

        #endregion

        #region Public Methods

        public void AddParameter(string parameterName)
        {
            ParameterGroups.AddParameter(parameterName, null, 0);
        }

        public void AddParameter(string parameterName, string parameterValue)
        {
            ParameterGroups.AddParameter(parameterName, parameterValue, 0);
        }

        public void AddParameter(string parameterName, string parameterValue, uint? groupIndex)
        {
            ParameterGroups.AddParameter(parameterName, parameterValue, groupIndex ?? 0);
        }

        public void AddParameter(string parameterName, int parameterValue)
        {
            AddParameter(parameterName, parameterValue.ToString(), 0);
        }

        public void AddParameter(string parameterName, int parameterValue, uint? groupIndex)
        {
            AddParameter(parameterName, parameterValue.ToString(), groupIndex ?? 0);
        }

        public void AddParameter(string parameterName, uint parameterValue)
        {
            AddParameter(parameterName, parameterValue.ToString(), 0);
        }

        public void AddParameter(string parameterName, uint parameterValue, uint? groupIndex)
        {
            AddParameter(parameterName, parameterValue.ToString(), groupIndex ?? 0);
        }

        public void AddParameter(string parameterName, ulong parameterValue)
        {
            AddParameter(parameterName, parameterValue.ToString(), 0);
        }

        public void AddParameter(string parameterName, ulong parameterValue, uint? groupIndex)
        {
            AddParameter(parameterName, parameterValue.ToString(), groupIndex ?? 0);
        }

        public void AddParameter(string parameterName, bool parameterValue)
        {
            AddParameter(parameterName, parameterValue ? "1" : "0", 0);
        }

        public void AddParameter(string parameterName, bool parameterValue, uint? groupIndex)
        {
            AddParameter(parameterName, parameterValue ? "1" : "0", groupIndex ?? 0);
        }

        public void AddParameter(string parameterName, char parameterValue)
        {
            AddParameter(parameterName, parameterValue.ToString(), 0);
        }

        public void AddParameter(string parameterName, char parameterValue, uint? groupIndex)
        {
            AddParameter(parameterName, parameterValue.ToString(), groupIndex ?? 0);
        }

        public void AddOption(string optionName)
        {
            Options.Add(optionName.ToLower());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(Name.ToLower());

            if (ParameterGroups.Count > 0)
                result.AppendFormat(" {0}", ParameterGroups);

            if (Options.Count > 0)
                result.AppendFormat(" -{0}", string.Join(" -", Options.Select(o => o.ToString()).ToArray()));

            return result.ToString();
        }

        #endregion

        #region Conversion Overloading

        public static implicit operator string(Command command)
        {
            return command?.ToString();
        }

        #endregion
    }
}