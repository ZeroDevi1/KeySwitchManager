using KeySwitchManager.Common.Exceptions;
using KeySwitchManager.Domain.MidiMessages.Value;

using NUnit.Framework;

namespace Domain.Testing.MidiMessages.Value
{
    [TestFixture]
    public class LeastSignificantByteTest
    {
        [TestCase( MidiLeastSignificantByte.MinValue - 1 )]
        [TestCase( MidiLeastSignificantByte.MaxValue + 1 )]
        public void OutOfRangeTest( int noteNumber )
        {
            Assert.Throws<ValueOutOfRangeException>( () => new MidiLeastSignificantByte( noteNumber ) );
        }

        [Test]
        public void EqualityTest()
        {
            var byte1 = new MidiLeastSignificantByte( 1 );
            var byte2 = new MidiLeastSignificantByte( 2 );
            Assert.IsTrue( byte1.Equals( new MidiLeastSignificantByte( 1 ) ) );
            Assert.IsFalse( byte1.Equals( byte2 ) );
        }

        [Test]
        public void ToStringEqualityTest()
        {
            Assert.AreEqual( new MidiLeastSignificantByte( 1 ).ToString(), "1" );
            Assert.IsTrue( new MidiLeastSignificantByte( 1 ).ToString() == "1" );
        }
    }
}