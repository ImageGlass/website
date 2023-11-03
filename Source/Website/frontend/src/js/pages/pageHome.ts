import { query } from '../modules/helper';


const lnk = query('#lnkHomeFeature');

const onLnkHomeFeatureClicked = () => {
  lnk.style.width = `${lnk.clientWidth}px`;

  lnk.innerHTML = `
    <div class="embed aniFadeIn">
      <iframe src="https://www.youtube.com/embed/1NtfM8q1e8E?si=Y20MQg7AHRqRijCz" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
    </div>
  `;

  lnk.removeEventListener('click', onLnkHomeFeatureClicked);
};

lnk.addEventListener('click', onLnkHomeFeatureClicked);
