﻿using Services;

namespace ConsoleApplicationFramework;

/// <summary>
/// コンソールアプリケーションビルダー
/// </summary>
public class ConsoleApplicationBuilder
{
    /// <summary>
    /// 実行可能なコントローラー
    /// </summary>
    private List<(string Name, Type Controller)> Controllers { get; } = [];

    /// <summary>
    /// サービスを追加する
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns></returns>
    public ConsoleApplicationBuilder AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
    {
        ServiceLocator.AddTransient<TService, TImplementation>();
        return this;
    }

    /// <summary>
    /// コントローラーを追加する
    /// </summary>
    public ConsoleApplicationBuilder AddController<TController>(string name) where TController : class, IController
    {
        Controllers.Add((name, typeof(TController)));
        ServiceLocator.AddTransient<TController>();
        return this;
    }

    /// <summary>
    /// アプリケーションをビルドする
    /// </summary>
    /// <returns></returns>
    public ConsoleApplication Build()
    {
        // ShutdownControllerを末尾に追加する。
        // Controllersに直接追加すると、2回目の実行時にShutdownControllerが増殖してしまうので
        // 一旦コピーする。
        var controllers = Controllers.ToList();
        controllers.Add(("終了", typeof(ShutdownController)));
        ServiceLocator.AddTransient<ShutdownController>();

        // サービスロケーターをビルドする。
        ServiceLocator.Build();

        // コンソールアプリケーションを作成する。
        return new ConsoleApplication(
            controllers.Select(x => x.Name).ToArray(),
            controllers.ToDictionary(
                x => x.Name,
                x => x.Controller));
    }
}