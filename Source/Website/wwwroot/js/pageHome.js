!function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t():"function"==typeof define&&define.amd?define("ig-ui",[],t):"object"==typeof exports?exports["ig-ui"]=t():e["ig-ui"]=t()}(this,(()=>(()=>{"use strict";var e={r:e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})}},t={};e.r(t);const r=(e,t=null)=>{try{const r=(t??document).querySelector(e);return r||console.warn(`🟠 query() returns NULL with selector '${e}'`),r}catch{}return null},o=r("#lnkHomeFeature"),i=()=>{o.style.width=`${o.clientWidth}px`,o.innerHTML='\n    <div class="embed aniFadeIn">\n      <iframe src="https://www.youtube.com/embed/1NtfM8q1e8E?si=Y20MQg7AHRqRijCz" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>\n    </div>\n  ',o.removeEventListener("click",i)};return o.addEventListener("click",i),t})()));
//# sourceMappingURL=pageHome.js.map