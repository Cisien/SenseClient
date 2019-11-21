using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;

namespace SenseClient.Internal
{
    internal class TimezoneMap
    {
        private const string SENSE_CLIENT_USE_SYSTEM_TIMEZONES = "SENSE_CLIENT_USE_SYSTEM_TIMEZONES";
        private static Lazy<supplementalData> _windowsTimezoneMap = new Lazy<supplementalData>(FillTimezoneMap, LazyThreadSafetyMode.ExecutionAndPublication);
        private static SemaphoreSlim _windowsTimezoneMapUpdateLock;

        private TimezoneMap()
        {
            _windowsTimezoneMapUpdateLock = new SemaphoreSlim(1, 1);
        }

        internal static TimeZoneInfo GetTimeZoneInfo(string id)
        {
            var shouldUseSystemTimezones = Environment.GetEnvironmentVariable(SENSE_CLIENT_USE_SYSTEM_TIMEZONES) == "1"
                                            || !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (shouldUseSystemTimezones)
            {
                return TimeZoneInfo.FindSystemTimeZoneById(id);
            }

            var map = _windowsTimezoneMap.Value.windowsZones.mapTimezones.mapZone;
            var windowsTimezone = map.FirstOrDefault(a => a.type == id)?.other;

            if(windowsTimezone == null)
            {
                throw new TimeZoneNotFoundException($"{id} was not found in the LDML specification (http://unicode.org/reports/tr35/)");
            }

            return TimeZoneInfo.FindSystemTimeZoneById(windowsTimezone);
        }

        private static supplementalData FillTimezoneMap() {

            var thisAssembly = typeof(TimezoneMap).Assembly;
            using var map = thisAssembly.GetManifestResourceStream("SenseClient.Internal.windowsZones.xml");

            var serializer = new XmlSerializer(typeof(supplementalData));
            var suppData = (supplementalData)serializer.Deserialize(map);
            return suppData;
        }
    }

#pragma warning disable IDE1006 // Naming Styles
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class supplementalData
    {
        public supplementalDataVersion version { get; set; }
        public supplementalDataWindowsZones windowsZones { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class supplementalDataVersion
    {
        [XmlAttribute()]
        public string number { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class supplementalDataWindowsZones
    {
        public supplementalDataWindowsZonesMapTimezones mapTimezones { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class supplementalDataWindowsZonesMapTimezones
    {
        [XmlElement("mapZone")]
        public supplementalDataWindowsZonesMapTimezonesMapZone[] mapZone { get; set; }

        [XmlAttribute()]
        public string otherVersion { get; set; }

        [XmlAttribute()]
        public string typeVersion { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class supplementalDataWindowsZonesMapTimezonesMapZone
    {

        [XmlAttribute()]
        public string other { get; set; }

        [XmlAttribute()]
        public string territory { get; set; }

        [XmlAttribute()]
        public string type { get; set; }
    }
}

#pragma warning restore IDE1006 // Naming Styles
