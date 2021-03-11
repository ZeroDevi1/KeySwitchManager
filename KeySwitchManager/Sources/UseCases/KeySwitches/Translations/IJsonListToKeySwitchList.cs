using System.Collections.Generic;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches.Aggregate;
using KeySwitchManager.Domain.Translations;

namespace KeySwitchManager.UseCases.KeySwitches.Translations
{
    public interface IJsonListToKeySwitchList : IDataTranslator<IText, IReadOnlyCollection<KeySwitch>>
    {}
}