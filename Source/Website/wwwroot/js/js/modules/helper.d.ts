/**
 * Opens a url.
 * @param url Url to open
 */
export declare const openUrl: (url: string) => void;
/**
 * Gets the first matched element with the query selector.
 */
export declare const query: <T = HTMLElement>(selector: string, parentEl?: HTMLElement) => T;
/**
 * Gets all matched elements with the query selector.
 */
export declare const queryAll: <T = HTMLElement>(selector: string, parentEl?: HTMLElement) => T[];
/**
 * Pauses the thread for a period
 * @param time Duration to pause in millisecond
 * @param data Data to return after resuming
 * @returns a promise
 */
export declare const pause: <T>(time: number, data?: T) => Promise<T>;
/**
 * Toggles and animates element visibility.
 */
export declare const animateElementVisibility: (selector: string, forced?: boolean) => Promise<void>;
/**
 * Scroll to the element position.
 */
export declare const scrollToTop: (selector: string, gapY?: number) => Promise<void>;
