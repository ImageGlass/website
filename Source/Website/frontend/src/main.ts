import './styles/main.scss';

import { IEffectOptions, applyEffect } from 'fluent-reveal-effect';

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
