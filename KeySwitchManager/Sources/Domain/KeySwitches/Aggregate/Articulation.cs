using System;
using System.Linq;

using KeySwitchManager.Domain.Commons;
using KeySwitchManager.Domain.KeySwitches.Value;
using KeySwitchManager.Domain.MidiMessages.Aggregate;

namespace KeySwitchManager.Domain.KeySwitches.Aggregate
{
    public class Articulation : IEquatable<Articulation>
    {
        public ArticulationName ArticulationName { get; }
        public IDataList<IMidiMessage> MidiNoteOns { get; }
        public IDataList<IMidiMessage> MidiControlChanges { get; }
        public IDataList<IMidiMessage> MidiProgramChanges { get; }
        public ExtraData ExtraData { get; }

        public Articulation(
            ArticulationName articulationName,
            IDataList<IMidiMessage> midiNoteOns,
            IDataList<IMidiMessage> midiControlChanges,
            IDataList<IMidiMessage> midiProgramChanges,
            ExtraData extraData )
        {
            ArticulationName   = articulationName;
            MidiNoteOns        = midiNoteOns;
            MidiControlChanges = midiControlChanges;
            MidiProgramChanges = midiProgramChanges;
            ExtraData          = extraData;
        }

        #region Equals
        public bool Equals( Articulation? other )
        {
            if( ReferenceEquals( null, other ) )
            {
                return false;
            }

            if( ReferenceEquals( this, other ) )
            {
                return true;
            }

            return ArticulationName.Equals( other.ArticulationName ) &&
                   MidiNoteOns.SequenceEqual( other.MidiNoteOns ) &&
                   MidiControlChanges.SequenceEqual( other.MidiControlChanges ) &&
                   MidiProgramChanges.SequenceEqual( other.MidiProgramChanges );
        }
        #endregion Equals
    }
}