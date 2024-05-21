using ConsoleApplicationFramework;
using HatPepper.Model.UseCase;
using HatPepper.View;
using Services;

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
        // 名称で店舗を検索する。
        var useCase = ServiceLocator.CreateInstance<IFindNearbyUseCase>();
        var shops = await useCase.FindNearbyAsync();

        // 検索結果を表示する。
        var view = ServiceLocator.CreateInstance<IFindNearbyView>();
        view.Show(shops);
    }
}