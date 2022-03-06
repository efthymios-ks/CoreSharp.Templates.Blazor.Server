/**
 * Get current screen size of a page.
 */
export function getWindowSize() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
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