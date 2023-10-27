```json
#metadata
{
  "Title": "Features",
  "Description": "ImageGlass is another open source basic image viewer, which, while simple, benefits from the speed that comes with being so lightweight, and is a good choice for Windows users.",
  "Keywords": ["imageglass features", "imageglass touch support", "imageglass slideshow"]
}
#metadata
```

# ImageGlass features
ImageGlass is a feature-rich, simple-to-use software designed for seamless viewing of images in a clean, modern and intuitive interface. With support for over 80 common image formats including WEBP, GIF, SVG, PNG, JXL, HEIC, RAW formats,... ImageGlass also offers advanced features that cater to the needs of both regular users and designers, making it the excellent tool to enhance workflow efficiency.


## Difference between ImageGlass Classic and Store release
ImageGlass offers two distinct versions: ImageGlass Classic and ImageGlass Store, each catering to different user preferences and needs.
- **ImageGlass Classic** serves as the base release, providing all the essential features for seamless image viewing and basic editing.
- **ImageGlass Store** is offered as a paid release. You will need to pay a small amount after 7-day trial. If you buy it, you'll be supporting its development directly and get the convenience of fast, easy installation onto all of your Windows devices along with fully automatic, behind-the-scenes updates.

Here's a comparison to help you choose the right version for your needs.

| Feature | ImageGlass Classic | ImageGlass Store |
| -- | -- | -- |
| All features | **Yes** | **Yes** |
| Theme, extension icon customization | **Yes** | **Yes** |
| Price | Free | 7-day trial |
| Commercial use | Free, recommended to [register](https://imageglass.org/license) | **Yes** |
| Distribution | [ImageGlass.org](https://imageglass.org) | [Microsoft Store](https://www.microsoft.com/store/productId/9N33VZK3C7TH?ocid=pdpshare)
| Auto-update | No,<br/>User self-managed | **Yes**,<br/>Seamless auto-update |


## Key features
Primarily a photo viewer, ImageGlass offers a wide array of features geared towards image viewing, with some limited editing capabilities.

### Viewing features
- Supports wide range image formats, thanks to [Magick.NET](https://github.com/dlemstra/Magick.NET) integration. You can explore the list here: [Docs / Supported formats](https://imageglass.org/docs/supported-formats).
- Enables format conversion for up to 10 different formats.
- Allows various methods for opening images, including drag-and-drop, pasting from the clipboard (image data, image file, or image file path).
- Extends support for viewing animated formats, including GIF, WEBP, APNG, SVG (using Webview2).
- Excels with multi-frame formats like TIF, ICO, GIF, WEBP, APNG, and more. The Page Navigation tool enables pausing or resuming animations, saving separate image frames, or exporting all frames to files.
- Monitors and updates changes to the viewed image in real-time.
- Enhances the viewing experience with 6 zoom modes:
  + Auto Zoom
  + Lock Zoom
  + Scale to Width
  + Scale to Height
  + Scale to Fit
  + Scale to Fill
- Offers flexibility in setting different image interpolation modes for zoom actions.
- Allows viewing images in different window modes: Full screen, Frameless, Window fit.
- Features a slideshow view in a separate window with a countdown timer.
- Provides fast thumbnail previews, which can be displayed in the current viewing folder.
- Includes a built-in Color Picker tool with support for various color formats.
- Supports viewing image information and EXIF metadata (using ExifGlass tool).
- Offers diverse sorting options for images, including File Explorer's sort order (with certain limitations).
- Supports color management.


### Editing features
While ImageGlass primarily serves as an image viewer, it can open external associated apps for more advanced editing capabilities. There are numerous excellent software options available for in-depth image editing. ImageGlass includes some basic editing features, such as:
- Support for rotating, flipping, and cropping the viewed image.
- Seamless association with third-party apps for extensive editing.


### Other features
- Automatic theme mode synchronization with the system.
- Gesture support for zooming and panning on touch devices.
- Complete customization options: app layout, theme, extension icon, and language pack.
- Customizing keyboard and mouse actions to your preferences.
- Capability to copy or cut multiple files to the clipboard.
- The ability to launch the app in a single or multiple instances.
- Integration with [external apps](https://imageglass.org/docs/imageglass-tools) through custom hotkeys.
- The flexibility to control ImageGlass settings via [configuration files](https://imageglass.org/docs/app-configs), pre-defining, or locking certain settings during installation.


## Limitations
- **Maximum image dimensions**: The maximum image dimension that ImageGlass can natively open is 16,380 x 16,380 pixels. For larger images, they will be scaled down to fit within these dimensions.
- **SVG viewing**: By default, ImageGlass uses Webview2 to view scalable SVG files.
  + Some features are unavailable when using Webview2, including Rotation, Flipping, Color picker, Cropping, Page navigation, Copy image data, Print, Set as Desktop/Lock screen, View image channels, Export image frames, and more.
  + You can switch back to the native engine by unchecking the option **"Use Webview2 for viewing SVG format"** in the app settings.
- **Window backdrop**: The window backdrop setting only works on Windows 11.
- **File Explorer sort order**: ImageGlass can detect and follow the File Explorer's sort order if
  + The folder window is open.
  + The sort order is by name, file extension, or file size.
