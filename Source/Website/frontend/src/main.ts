import { IEffectOptions, applyEffect } from 'fluent-reveal-effect';
import { animateElementVisibility, openUrl, query, queryAll, scrollToTop } from './js/modules/helper';

import './styles/main.scss';


// fluent effect for header bar
const effectOptions: Partial<IEffectOptions> = {
  clickEffect: true,
  lightColor: 'var(--bgFluent)',
  gradientSize: 100,
};

applyEffect('.navbar-nav .nav-item > a', effectOptions);
applyEffect('.article-list li > a', {
  ...effectOptions,
  gradientSize: 150,
});


// Events for toggle element
query('[toggle-el]').addEventListener('click', async (e) => {
  e.preventDefault();
  const targetSelector = (e.currentTarget as HTMLElement).getAttribute('toggle-el');

  await animateElementVisibility(targetSelector);
}, false);


// Events for scrolling to element
query('[scroll-to-el]').addEventListener('click', async (e) => {
  e.preventDefault();

  const targetSelector = (e.currentTarget as HTMLElement).getAttribute('scroll-to-el');
  scrollToTop(targetSelector);
}, false);


// Events for MS Store badge
const storeBadgeEls = queryAll('ms-store-badge');
storeBadgeEls.forEach(el => {
  const productId = el.getAttribute('productid');
  const campaignId = el.getAttribute('cid') || '';
  const url = `https://www.microsoft.com/store/productId/${productId}?cid=${campaignId}&referrer=appbadge&source=ig_website`;

  el.addEventListener('keydown', (e) => {
    if (e.key === 'Space' || e.key === 'Enter') {
      e.preventDefault();
      openUrl(url);
    }
  });
});
