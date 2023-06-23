import './styles/main.scss';

import { applyEffect } from 'fluent-reveal-effect';

// fluent effect for header bar
applyEffect('.navbar-nav .nav-item > a', {
  clickEffect: true,
  lightColor: 'rgb(var(--colorInvert) / 0.15)',
  gradientSize: 100,
});
