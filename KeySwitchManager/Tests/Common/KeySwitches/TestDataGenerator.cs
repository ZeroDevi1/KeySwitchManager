using System;
using System.Collections.Generic;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches.Aggregate;
using KeySwitchManager.Domain.KeySwitches.Value;
using KeySwitchManager.Domain.MidiMessages.Aggregate;

using RkHelper.Time;

namespace KeySwitchManager.Common.Testing.KeySwitches
{
    public static class TestDataGenerator
    {
        #region KeySwitch
        public static KeySwitch CreateKeySwitch(
            string developerName = "DeveloperName",
            string productName = "ProductName",
            string instrumentName = "E.Guitar" )
        {
            var now = DateTimeHelper.NowUtc();

            return new KeySwitch(
                new EntityGuid( Guid.NewGuid() ),
                new Author( "Author" ),
                new Description( "Description" ),
                new EntityDateTime( now ),
                new EntityDateTime( now ),
                new DeveloperName( developerName ),
                new ProductName( productName ),
                new InstrumentName( instrumentName ),
                new DataList<Articulation>( new[] { CreateArticulation() } ),
                new ExtraData( new Dictionary<ExtraDataKey, ExtraDataValue>
                {
                    {new ExtraDataKey( "extKey" ), new ExtraDataValue( "extValue" ) }
                })
            );
        }

        public static KeySwitch CreateKeySwitch( Articulation articulation )
        {
            return CreateKeySwitch( new[] { articulation } );
        }

        public static KeySwitch CreateKeySwitch( IReadOnlyCollection<Articulation> articulations )
        {
            var now = DateTimeHelper.NowUtc();

            return new KeySwitch(
                new EntityGuid( Guid.NewGuid() ),
                new Author( "Author" ),
                new Description( "Description" ),
                new EntityDateTime( now ),
                new EntityDateTime( now ),
                new DeveloperName( "DeveloperName" ),
                new ProductName( "ProductName" ),
                new InstrumentName( "E.Guitar" ),
                new DataList<Articulation>( articulations ),
                new ExtraData( new Dictionary<ExtraDataKey, ExtraDataValue>
                {
                    { new ExtraDataKey( "extKey" ), new ExtraDataValue( "extValue" ) }
                })
            );
        }
        #endregion

        #region Articulation
        public static Articulation CreateArticulation( string articulationName = "Power Chord" )
        {
            return new Articulation(
                new ArticulationName( articulationName ),
                new DataList<MidiNoteOn>(),
                new DataList<MidiControlChange>(),
                new DataList<MidiProgramChange>(),
                new ExtraData( new Dictionary<ExtraDataKey, ExtraDataValue>
                {
                    { new ExtraDataKey( "extKey" ), new ExtraDataValue( "extValue" ) }
                })
            );
        }

        public static Articulation CreateArticulation(
            IReadOnlyCollection<MidiNoteOn> noteOns,
            IReadOnlyCollection<MidiControlChange> controlChanges,
            IReadOnlyCollection<MidiProgramChange> programChanges )
        {
            return new Articulation(
                new ArticulationName( "Power Chord" ),
                new DataList<IMidiMessage>( noteOns ),
                new DataList<IMidiMessage>( controlChanges ),
                new DataList<IMidiMessage>( programChanges ),
                new ExtraData( new Dictionary<ExtraDataKey, ExtraDataValue>
                {
                    { new ExtraDataKey( "extKey" ), new ExtraDataValue( "extValue" ) }
                })
            );
        }
        #endregion
    }
}