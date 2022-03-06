//Local functions 
function getCollapsible(elementReference) {
    return new bootstrap.Collapse(elementReference);
}

/**
 * Shows a collapsible element. 
 * Returns to the caller before the collapsible element has actually been shown 
 * (e.g., before the shown.bs.collapse event occurs).
 */
export function show(elementReference) {
    const collapsible = getCollapsible(elementReference);
    if (collapsible) {
        collapsible.show();
    }
}

/**
 * Hides a collapsible element. 
 * Returns to the caller before the collapsible element has actually been hidden 
 * (e.g., before the hidden.bs.collapse event occurs).
 */
export function hide(elementReference) {
    const collapsible = getCollapsible(elementReference);
    if (collapsible) {
        collapsible.hide();
    }
}

/**
 * Toggles a collapsible element to shown or hidden. 
 * Returns to the caller before the collapsible element has actually been shown or hidden 
 * (i.e. before the shown.bs.collapse or hidden.bs.collapse event occurs).
 */
export function toggle(elementReference) {
    const collapsible = new getCollapsible(elementReference);
    if (collapsible) {
        collapsible.toggle();
    }
}
