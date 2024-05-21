using ConsoleApplicationFramework;
using HatPepper.Model.UseCase;
using HatPepper.View;

namespace HatPepper.Controller;

/// <summary>
/// 近隣の店舗を検索する。
/// </summary>
public class FindNearbyController : IController
{
    /// <summary>
    /// 近隣の店舗を検索する。
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        // ユースケースを生成する。
        FindNearbyUseCase useCase = new();
        var result = await useCase.FindNearbyAsync();

        // ビューを生成する。
        FindNearbyView view = new();
        view.Show(result);
    }
}