import { IEffectOptions, applyEffect } from 'fluent-reveal-effect';
import { animateElementVisibility, openUrl, pause, query, queryAll, scrollToTop } from './js/modules/helper';

import './styles/main.scss';


// fluent effect for header bar
const effectOptions: Partial<IEffectOptions> = {
  clickEffect: true,
  lightColor: 'var(--bgFluent)',
  gradientSize: 100,
};

applyEffect('.navbar-nav .nav-item > a', effectOptions);
applyEffect('.sponsor-list .sponsor-card', {
  ...effectOptions,
  gradientSize: 200,
  lightColor: 'rgb(var(--colorInvert) / 0.1)',
});
applyEffect('.article-list li > a', {
  ...effectOptions,
  gradientSize: 150,
});
applyEffect('.grid-experience > li', {
  ...effectOptions,
  gradientSize: 300,
  lightColor: 'rgb(var(--colorInvert) / 0.1)',
});
applyEffect('.repo-stats > li', {
  ...effectOptions,
  gradientSize: 200,
});


// Events for toggle element
queryAll('[toggle-el]').forEach(el => {
  el.addEventListener('click', async (e) => {
    const targetSelector = (e.currentTarget as HTMLElement).getAttribute('toggle-el');

    // if browser supports popover
    if (el.showPopover
      // and the target el is a popover
      && query(targetSelector)?.hasAttribute('popover')) {
      // open the native popover
      return;
    }

    e.preventDefault();
    await animateElementVisibility(targetSelector);
  }, false);
});


// Events for scrolling to element
queryAll('[scroll-to-el]').forEach(el => {
  el.addEventListener('click', async (e) => {
    e.preventDefault();

    const targetSelector = (e.currentTarget as HTMLElement).getAttribute('scroll-to-el');
    scrollToTop(targetSelector);
  }, false);
});


// popover: add closing animation
queryAll('[popover]').forEach(el => {
  el.addEventListener('beforetoggle', async (e: ToggleEvent) => {
    // popover is being hidden
    if (e.newState === 'closed') {
      el.classList.add('is--closing');

      await pause(500);
      el.classList.remove('is--closing');
    }
  });
});
