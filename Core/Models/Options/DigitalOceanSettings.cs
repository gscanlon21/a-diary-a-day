
namespace Core.Models.Options;

/// <summary>
/// App settings for azure.
/// </summary>
public class DigitalOceanSettings
{
    public string CDNBucket { get; set; } = null!;
    public string CDNLink { get; set; } = null!;
    public string AWSS3AccessKey { get; set; } = null!;
    public string AWSS3SecretKey { get; set; } = null!;
}
