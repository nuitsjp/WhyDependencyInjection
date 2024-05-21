using FluentTextTable;
using HatPepper.Model.HotPepper;

namespace HatPepper.View;

/// <summary>
/// 店舗検索ビュー
/// </summary>
public class FindNearbyView
{
    /// <summary>
    /// 検索結果を表示する。
    /// </summary>
    public void Show(GourmetSearchResult result)
    {
        // 検索結果をテーブル状に表示する。
        Build
            // テーブルフォーマットを指定する。
            .TextTable<(string Genre, string Name)>(builder =>
            {
                builder
                    .Borders.InsideHorizontal.AsDisable()
                    .Columns.Add(x => x.Genre).NameAs("ジャンル")
                    .Columns.Add(x => x.Name).NameAs("店名");
            })
            // 行を書き出す。
            .WriteLine(result.Results.Shops.Select(x => (x.Genre.Name, x.Name)));
    }
}