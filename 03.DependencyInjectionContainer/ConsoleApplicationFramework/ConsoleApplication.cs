using Microsoft.Extensions.DependencyInjection;
using Sharprompt;

namespace ConsoleApplicationFramework;

/// <summary>
/// コンソールアプリケーション
/// </summary>
public class ConsoleApplication(
    IServiceProvider serviceProvider,
    IReadOnlyList<string> controllerNames,
    IReadOnlyDictionary<string, Type> controllerTypes)
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
            var controllerType = controllerTypes[controllerName];
            var controller = (IController)serviceProvider.GetRequiredService(controllerType);

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

    public static ConsoleApplicationBuilder CreateBuilder()
    {
        return new ConsoleApplicationBuilder();
    }
}