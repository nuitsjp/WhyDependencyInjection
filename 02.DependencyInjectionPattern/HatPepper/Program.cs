using ConsoleApplicationFramework;
using HatPepper.Controller;
using HatPepper.Model.Device;
using HatPepper.Model.HotPepper;
using HatPepper.Model.UseCase;
using HatPepper.View;

// 引数でHotPepper APIのキーを取得し設定する。
// Powered by ホットペッパーグルメ Webサービス
GourmetService.ApiKey = args.First();

// コンソールアプリケーションを作成し、コントローラー（機能）を追加する。
await new ConsoleApplicationBuilder()
    .AddController(
        "近隣検索",
        new FindNearbyController(
            new FindNearbyUseCase(
                new GeoCoordinator(),
                new GourmetService()),
            new FindNearbyView()))
    .AddController("名称検索", new FindByNameController())
    // アプリケーションをビルド・実行する。
    .Build()
    .RunAsync();