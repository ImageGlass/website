export declare class GridGallery {
    #private;
    constructor(selector?: string);
    /**
     * Start Grid Gallery viewer
     */
    initViewer(): void;
    /**
     * Show the content
     */
    openContent(step?: number): void;
    /**
     * Event: gallery item click
     * @param {Event} e
     */
    handleGalleryItemClick(e: Event): void;
    /**
     * Event: Close button click
     */
    handleCloseButtonClick(): void;
    /**
     * Event: Next button click
     */
    handleNextButtonClick(): void;
    /**
     * Event: Back button click
     */
    handleBackButtonClick(): void;
    /**
     * Event key up
     * @param {Event} e
     */
    handleKeyUp(e: KeyboardEvent): void;
}
declare const _default: {
    GridGallery: typeof GridGallery;
};
export default _default;
