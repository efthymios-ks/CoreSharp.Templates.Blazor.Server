// Local functions 
function getTooltip(elementReference) {
    return bootstrap.Tooltip.getOrCreateInstance(elementReference);
}

/**
 * Gives an element’s tooltip the ability to be shown.
 * Tooltips are enabled by default.
 */
export function enable(elementReference) {
    const tooltip = getTooltip(elementReference);
    if (tooltip) {
        tooltip.enable();
    }
}

/**
 * Removes the ability for an element’s tooltip to be shown.
 * The tooltip will only be able to be shown if it is re-enabled.
 */
export function disable(elementReference) {
    const tooltip = getTooltip(elementReference);
    if (tooltip) {
        tooltip.disable();
    }
}

/**
 * Hides and destroys an element’s tooltip (Removes stored data on the DOM element).
 * Tooltips that use delegation (which are created using the selector option)
 * cannot be individually destroyed on descendant trigger elements.
 */
export function dispose(elementReference) {
    const tooltip = getTooltip(elementReference);
    if (tooltip) {
        tooltip.dispose();
    }
}
