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
await ConsoleApplication.CreateBuilder()
    .AddController<FindNearbyController>("近隣検索")
    .AddController<FindByNameController>("名称検索")

    // 近隣検索で必要な依存関係を追加する。
    .AddTransient<IFindNearbyView, FindNearbyView>()
    .AddTransient<IFindNearbyUseCase, FindNearbyUseCase>()
    .AddTransient<IGeoCoordinator, GeoCoordinator>()
    .AddTransient<IGourmetService, GourmetService>()

    // アプリケーションをビルド・実行する。
    .Build()
    .RunAsync();