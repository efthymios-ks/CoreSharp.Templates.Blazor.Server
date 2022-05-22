﻿using AutoMapper;

namespace CoreSharp.Templates.Blazor.Server.Application.Mappings.Abstracts
{
    public abstract class OneWayProfileBase<TSource, TTarget> : Profile
        where TSource : class
        where TTarget : class
    {
        //Constructors
        protected OneWayProfileBase()
            => ToTarget();

        //Methods
        private void ToTarget()
        {
            var mapping = CreateMap<TSource, TTarget>();
            ToTargetConfigure(mapping);
        }

        /// <summary>
        /// Override for custom configuration
        /// from <see cref="TSource"/> to
        /// <see cref="TTarget"/> mapping.
        /// </summary>
        public virtual void ToTargetConfigure(IMappingExpression<TSource, TTarget> mapping)
        {
        }
    }
}
