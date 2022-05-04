// Local functions 
function getModal(elementReference) {
    return bootstrap.Modal.getOrCreateInstance(elementReference);
}

/**
 * Manually opens a modal.
 * Returns to the caller before the modal has actually been shown
 * (i.e. before the shown.bs.modal event occurs).
 */
export function show(elementReference) {
    const modal = getModal(elementReference);
    if (modal) {
        modal.show();
    }
}

/**
 * Manually hides a modal.
 * Returns to the caller before the modal has actually been hidden
 * (i.e. before the hidden.bs.modal event occurs).
 */
export function hide(elementReference) {
    const modal = getModal(elementReference);
    if (modal) {
        modal.hide();
    }
}
