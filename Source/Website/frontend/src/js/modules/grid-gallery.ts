
export class GridGallery {
  #selector = '';
  #currentIndex = 0;
  #animationDuration = 500;
  #galleryItemEls: HTMLElement[] = [];
  #galleryEl: HTMLElement;

  constructor(selector = '.grid-gallery') {
    this.#selector = selector;
    this.#galleryEl = document.querySelector(this.#selector);

    if (!this.#galleryEl) {
      throw new Error(`Cannot find element: '${this.#selector}'`);
    }

    this.#galleryItemEls = Array.from(this.#galleryEl.querySelectorAll<HTMLElement>('.gallery-item'));


    this.initViewer = this.initViewer.bind(this);
    this.openContent = this.openContent.bind(this);
    this.handleGalleryItemClick = this.handleGalleryItemClick.bind(this);
    this.handleCloseButtonClick = this.handleCloseButtonClick.bind(this);
    this.handleNextButtonClick = this.handleNextButtonClick.bind(this);
    this.handleBackButtonClick = this.handleBackButtonClick.bind(this);
    this.handleKeyUp = this.handleKeyUp.bind(this);
  }

  /**
   * Start Grid Gallery viewer
   */
  initViewer() {
    this.#galleryItemEls.forEach((item, index) => {
      item.setAttribute('data-index', index.toString());
      item.addEventListener('click', this.handleGalleryItemClick, false);
    });
  }


  /**
   * Show the content
   */
  openContent(step = 0) {
    const viewer = document.querySelector('.grid-gallery-viewer');
    let newIndex = this.#currentIndex + step;


    // view next
    if (step > 0) {
      if (newIndex > this.#galleryItemEls.length - 1) {
        newIndex = 0;
      }

      // animation: hide old content
      viewer.classList.add('closeViewer_Next');
    }
    // view back
    else if (step < 0) {
      if (newIndex < 0) {
        newIndex = this.#galleryItemEls.length - 1;
      }

      // animation: hide old content
      viewer.classList.add('closeViewer_Back');
    }
    // no change, refresh
    else {
      // animation: hide old content
      viewer.classList.add('closeViewer');
    }

    // update new index
    this.#currentIndex = newIndex;

    // new content
    const clonedEl = this.#galleryItemEls[this.#currentIndex].cloneNode(true) as HTMLElement;
    const content = clonedEl.innerHTML;

    setTimeout(() => {
      viewer.classList.remove('closeViewer', 'closeViewer_Next', 'closeViewer_Back');

      // view next
      if (step > 0) {
        // animation: hide old content
        viewer.classList.add('openViewer_Next');
      }
      // view back
      else if (step < 0) {
        // animation: hide old content
        viewer.classList.add('openViewer_Back');
      }
      // no change, refresh
      else {
        // animation: hide old content
        viewer.classList.add('openViewer');
      }

      // load content to the viewer
      const viewerBody = viewer.querySelector('.viewer-body');
      viewerBody.innerHTML = content;

      // prevent viewer closed when clicking the content
      const bodyContentEl = viewerBody.querySelector(':first-child');
      bodyContentEl.addEventListener('click', (e) => {
        e.stopImmediatePropagation();
      }, false);

      setTimeout(() => {
        viewer.classList.remove('openViewer', 'openViewer_Next', 'openViewer_Back');
      }, this.#animationDuration);

    }, this.#animationDuration);
  }


  /**
   * Event: gallery item click
   * @param {Event} e 
   */
  handleGalleryItemClick(e: Event) {
    // console.log(e.currentTarget)
    this.#currentIndex = parseInt((e.currentTarget as HTMLElement).getAttribute('data-index'));
    // console.log(this.currentIndex)

    // back button
    const navBack = document.createElement('span');
    navBack.classList.add('viewer-nav-back');
    navBack.title = 'Previous';
    navBack.addEventListener('click', this.handleBackButtonClick, false);

    // next button
    const navNext = document.createElement('span');
    navNext.classList.add('viewer-nav-next');
    navNext.title = 'Next';
    navNext.addEventListener('click', this.handleNextButtonClick, false);

    // close button
    const btnclose = document.createElement('span');
    btnclose.classList.add('viewer-close');
    btnclose.title = 'Close';
    btnclose.addEventListener('click', this.handleCloseButtonClick, false);

    // viewer body
    const viewerBody = document.createElement('div');
    viewerBody.classList.add('viewer-body');
    viewerBody.addEventListener('click', this.handleCloseButtonClick, false);

    // gallery viewer
    const viewer = document.createElement('div');
    viewer.classList.add('grid-gallery-viewer');
    viewer.append(navBack);
    viewer.append(viewerBody);
    viewer.append(navNext);
    viewer.append(btnclose);


    document.body.classList.add('grid-gallery-viewer-open');
    document.body.append(viewer);
    document.addEventListener('keyup', this.handleKeyUp, false);

    // open content
    this.openContent();
  }


  /**
   * Event: Close button click
   */
  handleCloseButtonClick() {
    document.body.classList.remove('grid-gallery-viewer-open');
    document.removeEventListener('keyup', this.handleKeyUp, false);

    const viewer = document.querySelector('.grid-gallery-viewer');
    if (viewer) {
      viewer.classList.add('closing');

      setTimeout(() => {
        viewer.remove();
      }, this.#animationDuration);
    }
  }


  /**
   * Event: Next button click
   */
  handleNextButtonClick() {
    // open content
    this.openContent(1);
  }


  /**
   * Event: Back button click
   */
  handleBackButtonClick() {
    // open content
    this.openContent(-1);
  }


  /**
   * Event key up
   * @param {Event} e 
   */
  handleKeyUp(e: KeyboardEvent) {
    if (!e.ctrlKey && !e.shiftKey && !e.altKey && !e.metaKey) {

      // NEXT key
      if (e.key === 'ArrowRight') {
        this.openContent(1);
      }
      // BACK key
      else if (e.key === 'ArrowLeft') {
        this.openContent(-1);
      }
      // ESC key
      else if (e.key === 'Escape') {
        this.handleCloseButtonClick();
      }
    }
  }
}


export default { GridGallery };
