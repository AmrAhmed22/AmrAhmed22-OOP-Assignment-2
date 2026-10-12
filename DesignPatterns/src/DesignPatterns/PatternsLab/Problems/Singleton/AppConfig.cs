namespace PatternsLab.Problems.Singleton;

public class AppConfig
{

   /*
    public static AppConfig Instance { get; } = new AppConfig();
    
    // it will create only one time when the program begin (bec its static) and only one time bec it get only

    but it's eager singleton, even if we don't need the object it will make it anyway.
   
    and this exactly code is not threads safe   

    */


    // Lazy singleton, create when needed only. and thread safe (.net do locking for us)
    private static readonly Lazy<AppConfig> _lazy = new(() => new AppConfig());

    public static AppConfig Instance => _lazy.Value;



 
    public static int LoadCount;

    public string DbConnection { get; set; }
    public string Theme { get; set; }
  

    private AppConfig() // private cstr to prevent new() from anywhere
    {
        LoadCount++;
        Console.WriteLine($"[AppConfig] Loading settings from disk... (load #{LoadCount})");
        Thread.Sleep(300);
        DbConnection = "Server=localhost;Db=School";
        Theme = "Light";
    }
}

public class DatabaseService
{
    public AppConfig Config { get; } = AppConfig.Instance;

    public void Connect() => Console.WriteLine($"Connecting to {Config.DbConnection}");
}

public class UiService
{
    public AppConfig Config { get; } = AppConfig.Instance;

    public void Render() => Console.WriteLine($"UI is using theme: {Config.Theme}");
}
