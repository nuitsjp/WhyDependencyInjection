using System.Text.Json.Serialization;

namespace HatPepper.Model.HotPepper;

/// <summary>
/// ジャンル
/// </summary>
/// <param name="Name">名称</param>
public record Genre(
    [property: JsonPropertyName("name")] string Name);