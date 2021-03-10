using System;

using KeySwitchManager.Domain.MidiMessages.Helpers;
using KeySwitchManager.Domain.MidiMessages.Value;

namespace KeySwitchManager.Domain.MidiMessages.Aggregate
{
    /// <summary>
    /// MIDI event aggregation that makes up the sound slot.
    /// Status bytes are not defined because they are not used.
    /// </summary>
    public interface IMidiMessage : IEquatable<IMidiMessage>
    {
        /// <summary>
        /// MIDI status code
        /// </summary>
        public IMidiMessageData Status { get; }

        /// <summary>
        /// MIDI channel code which is included status byte.
        /// Set to Zero if message has no channel data.
        /// </summary>
        public IMidiMessageData Channel =>
            new MidiChannel( MidiStatusHelper.GetChannel( Status.Value ) );

        /// <summary>
        /// MIDI event: 1st data byte
        /// </summary>

        public IMidiMessageData DataByte1 { get; }
        /// <summary>
        /// MIDI event: 2nd data byte
        /// </summary>
        public IMidiMessageData DataByte2 { get; }

        bool IEquatable<IMidiMessage>.Equals( IMidiMessage? other )
        {
            return other != null &&
                   Status.Value == other.Status.Value &&
                   Channel.Value == other.Channel.Value &&
                   DataByte1.Value == other.DataByte1.Value &&
                   DataByte2.Value == other.DataByte2.Value;
        }
    }
}