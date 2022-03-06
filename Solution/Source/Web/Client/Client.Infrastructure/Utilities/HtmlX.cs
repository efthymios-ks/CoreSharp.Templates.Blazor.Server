using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Enums;
using System;
using System.Text;
using static System.FormattableString;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Utilities
{
    /// <summary>
    /// Html related utilities.
    /// </summary>
    public static class HtmlX
    {
        /// <inheritdoc cref="RandomId(HtmlElementType, string)"/>
        public static string RandomId()
            => $"e_{Guid.NewGuid()}";

        /// <inheritdoc cref="RandomId(HtmlElementType, string)"/>
        public static string RandomId(HtmlElementType htmlElementType)
            => Id(htmlElementType, $"{Guid.NewGuid()}");

        /// <summary>
        /// Generate random id for html elements.
        /// </summary>
        public static string RandomId(HtmlElementType htmlElementType, string htmlElementName)
            => Id(htmlElementType, htmlElementName, Guid.NewGuid());

        /// <inheritdoc cref="Id(HtmlElementType, string, string)"/>
        public static string Id(HtmlElementType htmlElementType, string htmlElementName)
            => Id(htmlElementType, htmlElementName, null);

        /// <inheritdoc cref="Id(HtmlElementType, string, string)"/>
        public static string Id(HtmlElementType htmlElementType, string htmlElementName, int htmlElementId)
            => Id(htmlElementType, htmlElementName, Invariant($"{htmlElementId:F0}"));

        /// <inheritdoc cref="Id(HtmlElementType, string, string)"/>
        public static string Id(HtmlElementType htmlElementType, string htmlElementName, long htmlElementId)
            => Id(htmlElementType, htmlElementName, Invariant($"{htmlElementId:F0}"));

        /// <inheritdoc cref="Id(HtmlElementType, string, string)"/>
        public static string Id(HtmlElementType htmlElementType, string htmlElementName, Guid htmlElementId)
            => Id(htmlElementType, htmlElementName, $"{htmlElementId}");

        /// <summary>
        /// Generate consistent id for html elmenets.
        /// </summary>
        public static string Id(HtmlElementType htmlElementType, string htmlElementName, string htmlElementId)
        {
            var builder = new StringBuilder();

            //Type 
            builder.Append(GetElementTag(htmlElementType));

            //Name 
            builder.Append('_').Append(htmlElementName);

            //Id 
            if (htmlElementId is not null)
                builder.Append('_').Append(htmlElementId);

            //Build and format id 
            var id = builder.ToString().ToLowerInvariant();
            if (id.Contains(' '))
                id = id.Replace(" ", string.Empty);
            return id;
        }

        private static string GetElementTag(HtmlElementType element)
            => element switch
            {
                //Misc 
                HtmlElementType.Button => "btn",
                HtmlElementType.CheckBox => "check",
                HtmlElementType.Label => "label",
                HtmlElementType.Image => "img",

                //Inputs 
                HtmlElementType.TextBox or
                HtmlElementType.DatePicker or
                HtmlElementType.Numeric or
                HtmlElementType.Input => "input",

                //Selection 
                HtmlElementType.Tabs or
                HtmlElementType.DropDown or
                HtmlElementType.Selection => "select",

                //Groups 
                HtmlElementType.Form or
                HtmlElementType.Panel or
                HtmlElementType.Group => "group",

                //Lists 
                HtmlElementType.List => "list",

                //Entries 
                HtmlElementType.ListItem
                or HtmlElementType.Entry => "entry",

                _ => throw new ArgumentOutOfRangeException(nameof(element))
            };
    }
}
