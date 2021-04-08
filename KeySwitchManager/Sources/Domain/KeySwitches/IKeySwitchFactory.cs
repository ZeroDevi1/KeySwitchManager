using System;
using System.Collections.Generic;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches.Entity;
using KeySwitchManager.Domain.KeySwitches.Values;

using RkHelper.Time;

namespace KeySwitchManager.Domain.KeySwitches
{
    public interface IKeySwitchFactory
    {
        public KeySwitch Create(
            Guid id,
            string author,
            string description,
            DateTime created,
            DateTime lastUpdated,
            string developerName,
            string productName,
            string instrumentName,
            IEnumerable<Articulation> articulations,
            IReadOnlyDictionary<string, string> extraData );

        public static IKeySwitchFactory Default => new DefaultFactory();

        private class DefaultFactory : IKeySwitchFactory
        {
            public KeySwitch Create(
                Guid id,
                string author,
                string description,
                DateTime created,
                DateTime lastUpdated,
                string developerName,
                string productName,
                string instrumentName,
                IEnumerable<Articulation> articulations,
                IReadOnlyDictionary<string, string> extraData )
            {
                created     = DateTimeHelper.ToUtc( created );
                lastUpdated = DateTimeHelper.ToUtc( lastUpdated );

                return new KeySwitch(
                    new KeySwitchId( id ),
                    new Author( author ),
                    new Description( description ),
                    new UtcDateTime( created ),
                    new UtcDateTime( lastUpdated ),
                    new DeveloperName( developerName ),
                    new ProductName( productName ),
                    new InstrumentName( instrumentName ),
                    new DataList<Articulation>( articulations ),
                    IExtraDataFactory.Default.Create( extraData )
                );
            }
        }
    }
}