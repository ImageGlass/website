
/**
 * Opens a url.
 * @param url Url to open
 */
export const openUrl = (url: string) => {
  const a = document.createElement('a');
  a.target = '_blank';
  a.href = url;

  document.body.appendChild(a);
  a.click();

  setTimeout(() => {
    document.body.removeChild(a);
  }, 0);
};


/**
 * Gets the first matched element with the query selector.
 */
export const query = <T = HTMLElement>(
  selector: string,
  parentEl: HTMLElement = null,
): T | null => {
  try {
    const fromEl = parentEl ?? document;
    const el = fromEl.querySelector(selector) as T;

    if (!el) {
      console.warn(`🟠 query() returns NULL with selector '${selector}'`);
    }

    return el;
  }
  catch {}

  return null;
};


/**
 * Gets all matched elements with the query selector.
 */
export const queryAll = <T = HTMLElement>(
  selector: string,
  parentEl: HTMLElement = null,
) => {
  try {
    const fromEl = parentEl ?? document;
    const els = Array.from(fromEl.querySelectorAll(selector)) as T[];

    if (els.length === 0) {
      console.info(`🔵 queryAll() returns ZERO elements with selector '${selector}'`);
    }

    return els;
  }
  catch {}

  return [];
};


/**
 * Pauses the thread for a period
 * @param time Duration to pause in millisecond
 * @param data Data to return after resuming
 * @returns a promise
 */
export const pause = <T>(time: number, data?: T): Promise<T> => new Promise((resolve) => {
  setTimeout(() => resolve(data as T), time);
});


/**
 * Toggles and animates element visibility.
 */
export const animateElementVisibility = async (selector: string, forced?: boolean) => {
  const el = query(selector);
  const isHidden = forced ?? el.hidden;

  // show
  if (isHidden) {
    el.toggleAttribute('hidden', false);
    el.classList.add('aniHeightDown');
    el.classList.remove('aniHeightUp');
  }
  // hide
  else {
    el.classList.add('aniHeightUp');
    el.classList.remove('aniHeightDown');

    await pause(500);
    el.toggleAttribute('hidden', true);
    el.classList.remove('aniHeightUp');
  }
};


/**
 * Scroll to the element position.
 */
export const scrollToTop = async (selector: string, gapY = 90) => {
  const el = query(selector);
  document.body.scrollTo({ top: el.offsetTop - gapY, behavior: 'smooth' });
};
