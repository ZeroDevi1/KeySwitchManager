using System;

using KeySwitchManager.Domain.MidiMessages.Value;

using NUnit.Framework;

namespace Domain.Testing.MidiMessages.Value
{
    [TestFixture]
    public class NoteNumberTest
    {
        [TestCase( -1 )]
        [TestCase( 128 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => _ = new MidiNoteNumber( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var note1 = new MidiNoteNumber( 1 );
            var note2 = new MidiNoteNumber( 2 );
            Assert.IsTrue( note1.Equals( new MidiNoteNumber( 1 ) ) );
            Assert.IsFalse( note1.Equals( note2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiNoteNumber( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiNoteNumber( 1 ).ToString() == "1" );
        }
    }
}