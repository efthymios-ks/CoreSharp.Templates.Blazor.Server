using CoreSharp.Templates.Blazor.Server.Application.Dto.Contracts;
using System.Diagnostics;
using JsonNet = Newtonsoft.Json;
using TextJson = System.Text.Json;

namespace CoreSharp.Templates.Blazor.Server.Application.Dto.Abstracts
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class DomainDtoBase<TKey> : IDomainDto<TKey>
    {
        //Properties
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
            => ToString();

        public TKey Id { get; set; }

        [TextJson.Serialization.JsonIgnore]
        [JsonNet.JsonIgnore]
        object IDomainDto.Id { get; set; }

        //Methods
        public override string ToString()
            => $"{Id}";
    }
}
