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

### 1. `set-wallpaper <string imgPath> [int style]`
Set the image specified by `imgPath` as the desktop wallpaper. The optional style parameter allows you to set the wallpaper style. For instance:
```bash
igcmd.exe set-wallpaper "C:\my photos\sky.jpg"
```


### 2. `set-lock-screen <string imgPath>`
Set the image specified by `imgPath` as the lock screen background. For instance:
```bash
igcmd.exe set-lock-screen "C:\my photos\sky.jpg"
```


### 3. `set-default-viewer [string exts]`
Set default viewer for the extensions. For instance, to set ImageGlass as the default photo viewer for PNG, JPG, and WEBP formats:
```bash
igcmd.exe set-default-viewer .png;.jpg;.webp
```


### 4. `remove-default-viewer [string exts]`
Remove ImageGlass as the default viewer for specific file extensions. For instance, to remove ImageGlass from being the default photo viewer for PNG, JPG, and WEBP formats:
```bash
igcmd.exe remove-default-viewer .png;.jpg;.webp
```


### 5. `export-frames <string filePath>`
Open a file picker and export image frames from the specified file. For instance:
```bash
igcmd.exe export-frames "C:\my photos\dance.webp"
```


### 6. `quick-setup`
Open ImageGlass Quick Setup to configure settings. For instance:
```bash
igcmd.exe quick-setup
```


### 7. `check-for-update`
Check for new updates for ImageGlass. For instance:
```bash
igcmd.exe check-for-update
```


### 8. `install-languages [string[] filePaths]`
Install language packs for ImageGlass. For instance:
```bash
igcmd.exe install-languages "C:\langs\Vietnamese.iglang.json" "C:\langs\Japanese.iglang.json"
```


### 9. `install-themes [string[] filePaths]`
Install theme packs for ImageGlass. For instance:
```bash
igcmd.exe install-themes "C:\themes\Kobe.Duong-Dieu-Phap.igtheme" "C:\themes\Green-gradient.Duong-Dieu-Phap.igtheme"
```


### 10. `uninstall-theme <string filePath>`
Uninstall a specific theme pack. For instance:
```bash
igcmd.exe uninstall-theme "C:\themes\Green-gradient.Duong-Dieu-Phap.igtheme"
```
