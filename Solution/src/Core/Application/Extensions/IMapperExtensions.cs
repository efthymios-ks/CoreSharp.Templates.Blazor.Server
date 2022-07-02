using AutoMapper;
using CoreSharp.Models.Pages;
using System;
using System.Collections.Generic;

namespace CoreSharp.Templates.Blazor.Server.Application.Extensions;

/// <summary>
/// <see cref="IMapper"/> extensions.
/// </summary>
internal static class IMapperExtensions
{
    public static Page<TOut> MapPage<TIn, TOut>(this IMapper mapper, Page<TIn> page)
    {
        _ = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _ = page ?? throw new ArgumentNullException(nameof(page));

        return new(page.PageNumber,
                   page.PageSize,
                   page.TotalItems,
                   page.TotalPages,
                   mapper.Map<IEnumerable<TOut>>(page.Items));
    }
}
