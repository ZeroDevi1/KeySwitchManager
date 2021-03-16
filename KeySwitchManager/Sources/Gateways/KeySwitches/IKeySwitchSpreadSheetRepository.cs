using System;
using System.Collections.Generic;

using KeySwitchManager.Domain.KeySwitches;

namespace KeySwitchManager.Gateways.KeySwitches
{
    public interface IKeySwitchSpreadSheetRepository : IDisposable
    {
        public IReadOnlyCollection<KeySwitch> Load();
        public bool Save( IReadOnlyCollection<KeySwitch> keySwitches );
    }
}