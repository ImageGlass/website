```json
#metadata
{
  "Title": "ImageGlass Tools",
  "Description": "ImageGlass provides an API for third-party app integration. By utilizing the ImageGlass.Tools library, developers can expand the functionality of ImageGlass.",
  "Keywords": ["imageglass tools", "imageglass plugin", "imageglass extension"]
}
#metadata
```

# ImageGlass Tools
ImageGlass provides an API for third-party app integration. By utilizing the ImageGlass.Tools library, developers can expand the functionality of ImageGlass, creating a highly customizable and versatile tool for all image viewing needs.

You can download tools for ImageGlass 9 at: https://imageglass.org/tools.

## Build Tools for ImageGlass
Prerequisites:
- IDE: Visual Studio 2022
- Programming language: C#
- .NET 6 or above


Follow these simple steps to use the APIs from ImageGlass.Tools:
1. Create a new project in Visual Studio.
2. Install [ImageGlass.Tools](https://www.nuget.org/packages/ImageGlass.Tools) nudget package, or add [ImageGlass.Tools.csproj](https://github.com/ImageGlass/ImageGlass.Tools/tree/main/Source/ImageGlass.Tools) as a reference to your software.
4. Create a new instance of ImageGlassTool:
  ```cs
  private readonly ImageGlassTool _igTool = new ImageGlassTool();
  ```
5. Add event listeners to ImageGlass:
  ```cs
  _igTool.ToolMessageReceived += IgTool_ToolMessageReceived;
  _igTool.ToolClosingRequest += IgTool_ToolClosingRequest;
  ```
6. Handle event from ImageGlass:
  ```cs
  private void IgTool_ToolMessageReceived(object? sender, MessageReceivedEventArgs e)
  {
    if (string.IsNullOrEmpty(e.MessageData)) return;

    if (e.MessageName == ImageGlassEvents.IMAGE_LOADED)
    {
      Trace.WriteLine("Image is loaded");
      Trace.WriteLine(e.MessageData);
    }
  }
  ```

7. Start connecting to ImageGlass:
  ```cs
  await _igTool.ConnectAsync();
   ```

Now you have created an app that connects and handles events from ImageGlass. You can also explore a complete app in the [DemoApp project](https://github.com/ImageGlass/ImageGlass.Tools/tree/main/Source/DemoApp).


## Add Your Tool to ImageGlass
You can integrate external apps as ImageGlass Tools and assign hotkeys for them in ImageGlass 9. These tools will appear under the Tools menu. To achieve this, you can use the app settings UI or directly edit the user config file (`igconfig.json`).

### Using App Settings UI
- Open ImageGlass Settings and click on the "Tools" tab.
- Click the "Add..." button to add a new tool.
- Fill in all the fields accordingly.
  + In Argument text box, fill `<file>` to have ImageGlass send the full path of the currently viewed image file to the tool.
  + Check the option "Integrated with ImageGlass.Tools" if the tool has an implementation of `ImageGlass.Tools`.
  + Use the command preview to verify the correctness of your inputs.
- Click the "OK" button to close the dialog, and then click "OK" or "Apply" to save the changes.
![Use ImageGlass setting to add external tool](https://github.com/d2phap/ImageGlass/assets/3154213/d8d4d903-6407-41ed-9199-c5bcb2c3242d)

### Editing The User Config Dile (`igconfig.json`)
1. Make sure the ImageGlass app is not running.
2. Open the `igconfig.json` file with a text editor such as Notepad or VS Code.
3. In the `Tools` section of the `igconfig.json` file, add the following code:
  ```json
  // in igconfig.json
  "Tools": [
    {
      "ToolId": "Tool_MyDemoApp", // a unique ID
      "ToolName": "My Demo app", // name of the tool
      "Executable": "path\\to\\the\\DemoApp.exe",
      "Argument": "<file>", // file path to pass to the tool
      "Hotkeys": ["X", "Ctrl+E"], // press X or Ctrl+E to open/close the tool
      "IsIntegrated": true|false // true: if the tool supports 'ImageGlass.Tools'
    }
  ]
  ```
4. Save the file and launch ImageGlass.
