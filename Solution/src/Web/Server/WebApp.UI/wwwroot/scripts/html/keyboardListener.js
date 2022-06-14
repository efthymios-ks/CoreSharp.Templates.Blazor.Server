/**
 * Subscribe to global keydown event.
 */
export function addKeydownListener(dotNetReference, methodName) {
    window.document.addEventListener('keydown', args => dotNetReference.invokeMethodAsync(methodName, serializeArgs(args)));
};

function serializeArgs(args) {
    if (!args)
        return;

    return {
        key: args.key,
        code: args.keyCode.toString(),
        location: args.location,
        repeat: args.repeat,
        ctrlKey: args.ctrlKey,
        shiftKey: args.shiftKey,
        altKey: args.altKey,
        metaKey: args.metaKey,
        type: args.type
    };
};