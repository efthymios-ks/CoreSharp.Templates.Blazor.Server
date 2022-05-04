// Local functions 
function getDropdown(dropdownToggleReference) {
    return bootstrap.Dropdown.getOrCreateInstance(dropdownToggleReference);
}

/**
 * Shows the dropdown menu of a given item.
 */
export function show(dropdownToggleReference) {
    const dropdown = getDropdown(dropdownToggleReference);
    if (dropdown)
        dropdown.show();
}

/**
 * Hides the dropdown menu of a given item.
 */
export function hide(dropdownToggleReference) {
    const dropdown = getDropdown(dropdownToggleReference);
    if (dropdown)
        dropdown.hide();
} 
