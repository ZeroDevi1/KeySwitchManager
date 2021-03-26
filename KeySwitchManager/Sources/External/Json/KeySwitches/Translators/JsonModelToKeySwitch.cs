using System.Text.Json;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches;
using KeySwitchManager.Domain.Translators;
using KeySwitchManager.Json.KeySwitches.Helpers;
using KeySwitchManager.Json.KeySwitches.Models;

namespace KeySwitchManager.Json.KeySwitches.Translators
{
    public class JsonModelToKeySwitch : ITextToKeySwitch
    {
        public KeySwitch Translate( IText source )
        {
            var model = JsonSerializer.Deserialize<KeySwitchModel>( source.Value ) ?? new KeySwitchModel();
            return JsonModelToKeySwitchHelper.Translate( model );
        }
    }
}