using HatPepper.Model.UseCase;

namespace HatPepper.View;

/// <summary>
/// 店舗検索ビュー
/// </summary>
public interface IFindNearbyView
{
    /// <summary>
    /// 検索結果を表示する。
    /// </summary>
    /// <param name="restaurants"></param>
    void Show(IEnumerable<Restaurant> restaurants);
}