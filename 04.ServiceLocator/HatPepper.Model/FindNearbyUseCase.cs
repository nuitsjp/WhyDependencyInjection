using Services;

namespace HatPepper.Model.UseCase;

/// <summary>
/// 近隣検索ユースケース
/// </summary>
public class FindNearbyUseCase : IFindNearbyUseCase
{
    /// <summary>
    /// 現在地の近隣店舗を検索する。
    /// </summary>
    public async Task<IReadOnlyList<Restaurant>> FindNearbyAsync()
    {
        // 現在地を取得する。
        var geoCoordinator = ServiceLocator.CreateInstance<IGeoCoordinator>();
        var location = geoCoordinator.GetCurrent();

        // 現在地から店舗を検索する。
        var gourmetService = ServiceLocator.CreateInstance<IGourmetService>();
        return await gourmetService.FindNearbyAsync(location);
    }
}