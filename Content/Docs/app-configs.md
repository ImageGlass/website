```json
#metadata
{
  "Title": "Configuration Files",
  "Description": "Learn how to manage ImageGlass using configuration files, defining presets, and even locking specific settings during installation.",
  "Keywords": ["imageglass config files", "imageglass deploy"]
}
#metadata
```

# Configuration Files
Learn how to manage ImageGlass using configuration files, defining presets, and even locking specific settings during installation.

## Configuration Directories
When dealing with the working directories in ImageGlass, it's essential to understand two key phrases:
- **Startup directory (Startup Dir)**: This directory is where ImageGlass.exe is located, also known as the installation directory. For example: `C:\Program Files\ImageGlass\`.
- **Configuration directory (Config Dir)**: This directory houses the ImageGlass settings file (igconfig.json) and other related files. It's typically located in `%LocalAppData%\ImageGlass\`. In portable mode, the Config Dir is the same as the Startup Dir. If ImageGlass lacks write permissions in the Startup Dir, it will use `%LocalAppData%\ImageGlass\` instead.


## Manage ImageGlass Using Configuration Files
ImageGlass recognizes three distinct configuration files, which are loaded in the following sequence:

- `igconfig.default.json`: Located in the Startup Dir, this file specifies default settings that are used if no other settings are available upon the initial launch.
- `igconfig.json`: Found in the Config Dir, this file contains all user-specific settings and is written by ImageGlass after the application is closed. It takes precedence over the settings in the `igconfig.default.json` file.
- `igconfig.admin.json`: Located in the Startup Dir, this file contains settings that will override all settings in the files mentioned above.


Additionally, ImageGlass supports passing settings as command-line arguments. Each command must begin with a `/`. For instance, to launch ImageGlass without the toolbar and gallery, and with an Acrylic backdrop:
```bash
ImageGlass.exe /ShowToolbar=false /ShowGallery=false /WindowBackdrop="Acrylic"
```


ImageGlass systematically searches for these files in the described order and locations. The configuration is constructed from scratch, setting by setting, following these four steps:
1. It starts with the defaults set by the developer.
2. If an `igconfig.default.json` is found and contains relevant settings, it overrides the values from step 1.
3. If an `igconfig.json` is found and contains the relevant settings, it overrides the values from step 2.
4. If the user passes settings as command-line arguments, they override the values from step 3.
5. If an `igconfig.admin.json` is found and contains relevant settings, it will override the values from step 4.

Once every setting in the complete configuration is processed, ImageGlass will use the resulting configuration and write the entire configuration to its `igconfig.json` file (and only there). This ensures that your chosen settings are preserved for future use.
