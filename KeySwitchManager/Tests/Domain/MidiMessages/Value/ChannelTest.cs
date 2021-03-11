using System;

using KeySwitchManager.Domain.MidiMessages.Value;

using NUnit.Framework;

namespace Domain.Testing.MidiMessages.Value
{
    [TestFixture]
    public class ChannelTest
    {
        [TestCase( -1 )]
        [TestCase( 16 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => _ = new MidiChannel( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var vel1 = new MidiChannel( 10 );
            var vel2 = new MidiChannel( 12 );
            Assert.IsTrue( vel1.Equals( new MidiChannel( 10 ) ) );
            Assert.IsFalse( vel1.Equals( vel2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiChannel( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiChannel( 1 ).ToString() == "1" );
        }
    }
}