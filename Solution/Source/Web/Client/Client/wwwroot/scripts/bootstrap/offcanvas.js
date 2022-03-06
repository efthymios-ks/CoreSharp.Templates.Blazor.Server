// Local functions 
function getOffCanvas(elementReference) {
    return new bootstrap.Offcanvas(elementReference);
}

/**
 * Shows an offcanvas element. 
 * Returns to the caller before the offcanvas element has actually been shown 
 * (i.e. before the shown.bs.offcanvas event occurs).
 */
export function show(elementReference) {
    const offcanvas = getOffCanvas(elementReference);
    if (offcanvas) {
        offcanvas.show();
    }
}

/**
 * Hides an offcanvas element. 
 * Returns to the caller before the offcanvas element has actually been hidden 
 * (i.e. before the hidden.bs.offcanvas event occurs).
 */
export function hide(elementReference) {
    const offcanvas = getOffCanvas(elementReference);
    if (offcanvas) {
        offcanvas.hide();
    }
}

/**
 * Toggles an offcanvas element to shown or hidden. 
 * Returns to the caller before the offcanvas element has actually been shown or hidden 
 * (i.e. before the shown.bs.offcanvas or hidden.bs.offcanvas event occurs).
 */
export function toggle(elementReference) {
    const offcanvas = new getOffCanvas(elementReference);
    if (offcanvas) {
        offcanvas.toggle();
    }
}
