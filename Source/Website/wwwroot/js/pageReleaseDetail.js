!function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t():"function"==typeof define&&define.amd?define("ig-ui",[],t):"object"==typeof exports?exports["ig-ui"]=t():e["ig-ui"]=t()}(this,(()=>(()=>{"use strict";var e={r:e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})}},t={};e.r(t);var i,n,s,o,r,a=function(e,t,i,n,s){if("m"===n)throw new TypeError("Private method is not writable");if("a"===n&&!s)throw new TypeError("Private accessor was defined without a setter");if("function"==typeof t?e!==t||!s:!t.has(e))throw new TypeError("Cannot write private member to an object whose class did not declare it");return"a"===n?s.call(e,i):s?s.value=i:t.set(e,i),i},l=function(e,t,i,n){if("a"===i&&!n)throw new TypeError("Private accessor was defined without a getter");if("function"==typeof t?e!==t||!n:!t.has(e))throw new TypeError("Cannot read private member from an object whose class did not declare it");return"m"===i?n:"a"===i?n.call(e):n?n.value:t.get(e)};class d{constructor(e=".grid-gallery"){if(i.set(this,""),n.set(this,0),s.set(this,500),o.set(this,[]),r.set(this,void 0),a(this,i,e,"f"),a(this,r,document.querySelector(l(this,i,"f")),"f"),!l(this,r,"f"))throw new Error(`Cannot find element: '${l(this,i,"f")}'`);a(this,o,Array.from(l(this,r,"f").querySelectorAll(".gallery-item")),"f"),this.initViewer=this.initViewer.bind(this),this.openContent=this.openContent.bind(this),this.handleGalleryItemClick=this.handleGalleryItemClick.bind(this),this.handleCloseButtonClick=this.handleCloseButtonClick.bind(this),this.handleNextButtonClick=this.handleNextButtonClick.bind(this),this.handleBackButtonClick=this.handleBackButtonClick.bind(this),this.handleKeyUp=this.handleKeyUp.bind(this)}initViewer(){l(this,o,"f").forEach(((e,t)=>{e.setAttribute("data-index",t.toString()),e.addEventListener("click",this.handleGalleryItemClick,!1)}))}openContent(e=0){const t=document.querySelector(".grid-gallery-viewer");let i=l(this,n,"f")+e;e>0?(i>l(this,o,"f").length-1&&(i=0),t.classList.add("closeViewer_Next")):e<0?(i<0&&(i=l(this,o,"f").length-1),t.classList.add("closeViewer_Back")):t.classList.add("closeViewer"),a(this,n,i,"f");const r=l(this,o,"f")[l(this,n,"f")].cloneNode(!0).innerHTML;setTimeout((()=>{t.classList.remove("closeViewer","closeViewer_Next","closeViewer_Back"),e>0?t.classList.add("openViewer_Next"):e<0?t.classList.add("openViewer_Back"):t.classList.add("openViewer");const i=t.querySelector(".viewer-body");i.innerHTML=r;i.querySelector(":first-child").addEventListener("click",(e=>{e.stopImmediatePropagation()}),!1),setTimeout((()=>{t.classList.remove("openViewer","openViewer_Next","openViewer_Back")}),l(this,s,"f"))}),l(this,s,"f"))}handleGalleryItemClick(e){a(this,n,parseInt(e.currentTarget.getAttribute("data-index")),"f");const t=document.createElement("span");t.classList.add("viewer-nav-back"),t.title="Previous",t.addEventListener("click",this.handleBackButtonClick,!1);const i=document.createElement("span");i.classList.add("viewer-nav-next"),i.title="Next",i.addEventListener("click",this.handleNextButtonClick,!1);const s=document.createElement("span");s.classList.add("viewer-close"),s.title="Close",s.addEventListener("click",this.handleCloseButtonClick,!1);const o=document.createElement("div");o.classList.add("viewer-body"),o.addEventListener("click",this.handleCloseButtonClick,!1);const r=document.createElement("div");r.classList.add("grid-gallery-viewer"),r.append(t),r.append(o),r.append(i),r.append(s),document.body.classList.add("grid-gallery-viewer-open"),document.body.append(r),document.addEventListener("keyup",this.handleKeyUp,!1),this.openContent()}handleCloseButtonClick(){document.body.classList.remove("grid-gallery-viewer-open"),document.removeEventListener("keyup",this.handleKeyUp,!1);const e=document.querySelector(".grid-gallery-viewer");e&&(e.classList.add("closing"),setTimeout((()=>{e.remove()}),l(this,s,"f")))}handleNextButtonClick(){this.openContent(1)}handleBackButtonClick(){this.openContent(-1)}handleKeyUp(e){e.ctrlKey||e.shiftKey||e.altKey||e.metaKey||("ArrowRight"===e.key?this.openContent(1):"ArrowLeft"===e.key?this.openContent(-1):"Escape"===e.key&&this.handleCloseButtonClick())}}i=new WeakMap,n=new WeakMap,s=new WeakMap,o=new WeakMap,r=new WeakMap;return new d(".grid-gallery").initViewer(),t})()));
//# sourceMappingURL=pageReleaseDetail.js.map