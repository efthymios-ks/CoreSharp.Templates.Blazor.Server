using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using CoreSharp.Collections;
using System;
using System.Collections.Generic;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services
{
    public class AppContextService : IAppContextService
    {
        //Constructors
        public AppContextService()
        {
            var observableDictionary = new ObservableDictionary<string, object>();
            observableDictionary.CollectionChanged += (_, _) => OnStateHasChangedRequested();
            Variables = observableDictionary;
        }

        //Properties
        public IDictionary<string, object> Variables { get; }

        //Events
        public event Action StateHasChangedRequested;

        //Methods
        private void OnStateHasChangedRequested()
            => StateHasChangedRequested?.Invoke();
    }
}
