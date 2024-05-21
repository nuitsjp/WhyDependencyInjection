namespace ConsoleApplicationFramework;

/// <summary>
/// コンソールアプリケーション用コントローラー
/// </summary>
public interface IController
{
    /// <summary>
    /// 処理を実行する。
    /// </summary>
    /// <returns></returns>
    Task RunAsync();
}