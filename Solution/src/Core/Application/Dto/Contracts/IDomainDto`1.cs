namespace CoreSharp.Templates.Blazor.Server.Application.Dto.Contracts
{
    public interface IDomainDto<TKey> : IDomainDto
    {
        //Properties
        public new TKey Id { get; set; }
    }
}
