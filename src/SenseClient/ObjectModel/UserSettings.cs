using ApiUserSettings = SenseClient.ApiModel.UserSettings;

namespace SenseClient.ObjectModel
{
    public sealed class UserSettings
    {
        internal static UserSettings Create(ApiUserSettings settings)
        {
            return new UserSettings
            {
                UserId = settings.UserId,
                Version = settings.Version,
                Settings = NotificationSettings.Create(settings.Settings)
            };
        }

        public int UserId { get; internal set; }

        public NotificationSettings Settings { get; internal set; }

        public int Version { get; internal set; }

    }
}