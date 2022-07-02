﻿using AutoMapper;

namespace CoreSharp.Templates.Blazor.Server.Application.Mappings.Abstracts
{
    public abstract class TwoWayProfileBase<TSource, TTarget> : OneWayProfileBase<TSource, TTarget>
        where TSource : class
        where TTarget : class
    {
        //Constructors
        protected TwoWayProfileBase()
            => ToSource();

        //Methods 
        private void ToSource()
        {
            var mapping = CreateMap<TTarget, TSource>();
            ToSourceConfigure(mapping);
        }

        /// <summary>
        /// Override for custom configuration
        /// from <see cref="TTarget"/> to
        /// <see cref="TSource"/> mapping.
        /// </summary>
        public virtual void ToSourceConfigure(IMappingExpression<TTarget, TSource> mapping)
        {
        }
    }
}
