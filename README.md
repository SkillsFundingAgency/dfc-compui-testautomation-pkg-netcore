# UI Automated Test Framework
An automation framework designed to drive browser based user interfaces to assist in automated test execution.

**Project name:** DFC.TestAutomation.UI

## Description
This project is designed to provide a useful array of logic to assist in driving browser based applications. Simple interactions with the browser can be simulated easily by calling on logic defined in this project. This project is predominantly a [Selenium](https://www.selenium.dev/) wrapper meaning that the core component within this project is the [Selenium Webdriver](https://www.selenium.dev/documentation/en/webdriver/).  The key components within the project include:

### Helpers
The helper classes are broken down into specific classes (i.e. *FormHelper.cs*, *ScreenshotHelper.cs*, *JavaScriptHelper.cs* etc.). These classes are packaged neatly in what we call the *helper library*. Each of these classes have their individual helper methods that provide invaluable actions. The helpers are what make driving the browser quick and simple.

### Test Support
The test support classes are intended to be used as a 'one off'. For example we have the *WebDriverSupport.cs* class which can be used to create an instance of the Selenium Webdriver. This class does not hold instance data and so it can be disposed of once it has been finished with. You would not expect to use support classes continuously throughout your project.

### Settings
The settings classes are used as models. These models are used when parsing your *appsettings.json* file. The settings files are passed to the helper library in order to initialise the helper classes.

# Installation
It is recommended that this project be used as a NuGet package. This package can be found on [nuget.org](https://www.nuget.org/packages/DFC.TestAutomation.UI/). To include this NuGet in your solution you can use the Visual Studio NuGet package manager. To do this right click on your project in the *solution explorer* and select *Manage Nuget Packages*. Ensure that your package source is set to *nuget.org* and search for *DFC.TestAutomation.UI*. You will find the package listed where you will be able to select the install option.

# Usage
Below are examples you can use to get started.

### 1. Create a settings class that conforms to *IAppSettings.cs*
    
    ```
    internal class AppSettings : IAppSettings
    {
        public string AppName { get; set; }
        
        public Uri AppUrl { get; set; }
    }
    ```

### 2. Set up your settings library

    ```
    private ScenarioContext Context { get; set; }
    
    public void SetUpSettingsLibrary()
    {
	    var settingsLibrary = new SettingsLibrary<AppSettings>();
		this.Context.SetSettingsLibrary(settingsLibrary);
	}
    ```

### 3. Set up your object context

    ```
    private ScenarioContext Context { get; set; }
    
    public void SetUpObjectContext()
    {
	    var objectContext= new ObjectContext();
		this.Context.SetObjectContext(objectContext);
	}
    ```
	
### 4. Set up your Selenuim Webdriver

    ```
    private ScenarioContext Context { get; set; }
    
    public void SetUpWebDriver()
    {
	    var webdriverSupport = new WebDriverSupport<AppSettings>(this.Context);
	    var webDriver = webdriverSupport.Create();
	    this.Context.SetWebDriver(webDriver);
    }
    ```

### 5. Set up the helper library

    ```
    private ScenarioContext Context { get; set; }
    
    public void SetUpHelperLibrary()
    {
	    var webDriver = this.Context.GetWebDriver();
	    var settingsLibrary = this.Context.GetSettingsLibrary<AppSettings>();
	    var helperLibrary = new HelperLibrary<AppSettings>(webDriver, settingsLibrary);
	    this.Context.SetHelperLibrary(helperLibrary);
    }
    ```

### Other useful examples

    ```
    private ScenarioContext Context { get; set; }
    
    public void TakeAScreenshot() 
    {
	    var helperLibrary = this.Context.GetHelperLibrary<AppSettings>();
		helperLibrary.ScreenshotHelper.TakeScreenshot(this.Context);
    }
    
    public void GetTextFromAnIWebElement() 
    {
	    var webElementLocator = By.CssSelector("my_css_selector");
	    var helperLibrary = this.Context.GetHelperLibrary<AppSettings>();
		var elementText = helperLibrary.CommonActionHelper.GetText(webElementLocator);
    }
    ```