```json
#metadata
{
  "Title": "Command line utilities",
  "Description": "ImageGlass provides a Command Line Interface designed to empower users with a set of tools for seamless management and interaction.",
  "Keywords": ["imageglass command line", "igcmd.exe"]
}
#metadata
```


# Command line utilities
ImageGlass provides a Command Line Interface designed to empower users with a set of tools for seamless management and interaction.


## Command lines for `ImageGlass.exe`
ImageGlass supports passing settings as command-line arguments. Each command must begin with a `/`. For instance: Open `C:\my photos\sky.jpg` file without the toolbar and gallery, and with an Acrylic backdrop
```bash
ImageGlass.exe /ShowToolbar=false /ShowGallery=false /WindowBackdrop="Acrylic" "C:\my photos\sky.jpg"
```


## Command lines for `igcmd.exe`
Take advantage of `igcmd.exe` to access a range of additional features. Explore the following command-line options:

### `set-wallpaper <string imgPath> [int style]`
Set the image specified by `imgPath` as the desktop wallpaper. The optional style parameter allows you to set the wallpaper style. Example:
```bash
igcmd.exe set-wallpaper "C:\my photos\sky.jpg"
```


### `set-lock-screen <string imgPath>`
Set the image specified by `imgPath` as the lock screen background. Example:
```bash
igcmd.exe set-lock-screen "C:\my photos\sky.jpg"
```


### `set-default-viewer [string exts]`
Set default viewer for the extensions. Example:
```bash
# Set ImageGlass as the default photo viewer for PNG, JPG, and WEBP formats
igcmd.exe set-default-viewer .png;.jpg;.webp
```


### `remove-default-viewer [string exts]`
Remove ImageGlass as the default viewer for specific file extensions. Example:
```bash
# Remove ImageGlass from being the default photo viewer for PNG, JPG, and WEBP formats
igcmd.exe remove-default-viewer .png;.jpg;.webp
```


### `export-frames <string filePath>`
Open a file picker and export image frames from the specified file. Example:
```bash
igcmd.exe export-frames "C:\my photos\dance.webp"
```


### `quick-setup`
Open ImageGlass Quick Setup to configure settings. Example:
```bash
igcmd.exe quick-setup
```


### `check-for-update`
Check for new updates for ImageGlass. Example:
```bash
igcmd.exe check-for-update
```


### `install-languages [string[] filePaths]`
Install language packs for ImageGlass. Example:
```bash
igcmd.exe install-languages "C:\langs\Vietnamese.iglang.json" "C:\langs\Japanese.iglang.json"
```


### `install-themes [string[] filePaths]`
Install theme packs for ImageGlass. Example:
```bash
igcmd.exe install-themes "C:\themes\Kobe.Duong-Dieu-Phap.igtheme" "C:\themes\Green-gradient.Duong-Dieu-Phap.igtheme"
```


### `uninstall-theme <string filePath>`
Uninstall a specific theme pack. Example:
```bash
igcmd.exe uninstall-theme "C:\themes\Green-gradient.Duong-Dieu-Phap.igtheme"
```
