/**
 * Get global css variable.
 */
export function get(key) {
    return getComputedStyle(document.documentElement).getPropertyValue(key);
}

/**
 * Set and return global css variable.
 */
export function set(key, value) {
    document.documentElement.style.setProperty(key, value);
    return get(key);
}
