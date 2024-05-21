using Sharprompt;

namespace ConsoleApplicationFramework;

/// <summary>
/// コンソールアプリケーション
/// </summary>
public class ConsoleApplication(
    IReadOnlyList<string> controllerNames,
    IReadOnlyDictionary<string, IController> controllers)
{
    /// <summary>
    /// アプリケーションを実行委する
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        do
        {
            // コントローラーを選択してもらう。
            var controllerName = Prompt.Select("機能を選択してください。", controllerNames);
            // 選択されたコントローラーを取得する。
            var controller = controllers[controllerName];

            if (controller is ShutdownController)
            {
                // ShutdownControllerが選択された場合、アプリケーションを終了する。
                break;
            }

            try
            {
                // コントローラーを実行する。
                await controller.RunAsync();
            }
            catch (Exception e)
            {
                // 例外はコンソールに出力する。
                Console.WriteLine(e);
            }
        } while (true);
    }
}