/**
 * Get list of requested properties for given element.
 */
export function getProperties(elementReference, ...keys) {
    if (!elementReference)
        return {};

    var dictionary = {};
    for (const key of keys) {
        if (elementReference[key])
            dictionary[key] = String(elementReference[key]);
    }

    return dictionary;
}

/**
 * Get the HTML content of an element by given id.
 */
export function getRawHtmlById(elementId) {
    const elementReference = document.getElementById(elementId);
    return getRawHtml(elementReference);
}

/**
 *
 * Get the HTML content of an element.
 */
export function getRawHtml(elementReference) {
    return elementReference.innerHTML;
}

/**
 *
 * Scroll to element.
 */
export function scrollIntoViewById(elementId) {
    const elementReference = document.getElementById(elementId);
    return scrollIntoView(elementReference);
}

/**
 *
 * Scroll to element.
 */
export function scrollIntoView(elementReference) {
    if (!elementReference)
        return;

    return elementReference.scrollIntoView({ behavior: 'smooth' });
}
