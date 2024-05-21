// Microsoft.Extensions.DependencyInjectionのクラスを利用しています。
using Microsoft.Extensions.DependencyInjection;

namespace Services;

/// <summary>
/// サービスロケーター
/// </summary>
public static class ServiceLocator
{
    /// <summary>
    /// IServiceCollection
    /// </summary>
    private static IServiceCollection ServiceCollection { get; } = new ServiceCollection();

    /// <summary>
    /// ServiceProvider
    /// </summary>
    private static IServiceProvider ServiceProvider { get; set; } = default!;

    /// <summary>
    /// サービスを追加する。
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TImplementation"></typeparam>
    public static void AddTransient<TService, TImplementation>() 
        where TService : class 
        where TImplementation : class, TService
    {
        ServiceCollection.AddTransient<TService, TImplementation>();
    }

    /// <summary>
    /// サービスを追加する。
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public static void AddTransient<TService>()
        where TService : class
    {
        ServiceCollection.AddTransient<TService>();
    }

    /// <summary>
    /// ServiceLocatorをビルドする。
    /// </summary>
    public static void Build()
    {
        ServiceProvider = ServiceCollection.BuildServiceProvider();
    }

    /// <summary>
    /// サービスのインスタンスを作成する。
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <returns></returns>
    public static TService CreateInstance<TService>()
        where TService : class
    {
        return ServiceProvider.GetRequiredService<TService>();
    }

    /// <summary>
    /// サービスのインスタンスを作成する。
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static object CreateInstance(Type type)
    {
        return ServiceProvider.GetRequiredService(type);
    }

}