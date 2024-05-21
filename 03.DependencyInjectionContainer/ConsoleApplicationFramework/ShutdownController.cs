namespace ConsoleApplicationFramework;

/// <summary>
/// アプリケーション終了用コントローラー
/// </summary>
public class ShutdownController : IController
{
    /// <summary>
    /// 終了コントローラーは、実際には処理を実行しないため未実装。
    /// 終了処理が必要になったら追加してもよい。
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RunAsync()
    {
        throw new NotImplementedException();
    }
}