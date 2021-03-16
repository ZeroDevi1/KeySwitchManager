using System.Collections.Generic;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches;
using KeySwitchManager.Domain.Translations;

namespace KeySwitchManager.UseCases.KeySwitches.Translations
{
    public interface IKeySwitchListToJsonListText : IDataTranslator<IReadOnlyCollection<KeySwitch>, IText>
    {}
}