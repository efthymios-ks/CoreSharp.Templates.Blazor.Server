using System.Collections.Generic;

namespace CoreSharp.CleanStructure.Blazor.Shared.Exceptions
{
    public class ConfigurationKeyNotFoundException : KeyNotFoundException
    {
        //Constructors
        public ConfigurationKeyNotFoundException(string key)
            : base($"Could not find configuration entry for key=`{key}`.")
        {
        }
    }
}
