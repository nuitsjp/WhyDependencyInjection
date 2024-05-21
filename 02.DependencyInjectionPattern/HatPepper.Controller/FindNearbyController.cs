using ConsoleApplicationFramework;
using HatPepper.Model.UseCase;
using HatPepper.View;

namespace HatPepper.Controller;

/// <summary>
/// 近隣の店舗を検索する。
/// </summary>
public class FindNearbyController(IFindNearbyUseCase useCase, IFindNearbyView view) 
    : IController
{
    /// <summary>
    /// 近隣の店舗を検索する。
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        // 名称で店舗を検索する。
        var shops = await useCase.FindNearbyAsync();

        // 検索結果を表示する。
        view.Show(shops);
    }
}