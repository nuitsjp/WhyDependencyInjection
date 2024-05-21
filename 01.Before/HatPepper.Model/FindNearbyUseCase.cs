using HatPepper.Model.Device;
using HatPepper.Model.HotPepper;

namespace HatPepper.Model.UseCase;

/// <summary>
/// 近隣検索ユースケース
/// </summary>
public class FindNearbyUseCase
{
    /// <summary>
    /// 現在地の近隣店舗を検索する。
    /// </summary>
    public async Task<GourmetSearchResult> FindNearbyAsync()
    {
        // 現在地を取得する。
        GeoCoordinator geoCoordinator = new();
        var location = geoCoordinator.GetCurrent();


        // 現在地から店舗を検索する。
        GourmetService gourmetService = new();
        return await gourmetService.FindNearbyAsync(location);
    }
}