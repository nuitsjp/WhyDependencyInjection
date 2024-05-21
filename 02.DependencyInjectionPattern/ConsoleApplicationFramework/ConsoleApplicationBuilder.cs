namespace ConsoleApplicationFramework;

/// <summary>
/// ConsoleApplicationのビルダー
/// </summary>
public class ConsoleApplicationBuilder
{
    /// <summary>
    /// 実行可能なコントローラー
    /// </summary>
    private List<(string Name, IController Controller)> Controllers { get; } = [];

    /// <summary>
    /// コントローラーを追加する。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="controller"></param>
    /// <returns></returns>
    public ConsoleApplicationBuilder AddController(string name, IController controller)
    {
        Controllers.Add((name, controller));
        return this;
    }

    /// <summary>
    /// コンソールアプリケーションを構築する。
    /// </summary>
    /// <returns></returns>
    public ConsoleApplication Build()
    {
        // ShutdownControllerを末尾に追加する。
        // Controllersに直接追加すると、2回目の実行時にShutdownControllerが増殖してしまうので
        // 一旦コピーする。
        var controllers = Controllers.ToList();
        controllers.Add(("終了", new ShutdownController()));

        // コンソールアプリケーションを作成する。
        return new ConsoleApplication(
            controllers.Select(x => x.Name).ToArray(),
            controllers.ToDictionary(
                x => x.Name, 
                x => x.Controller));
    }
}