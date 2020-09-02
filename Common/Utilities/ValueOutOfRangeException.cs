using System;

namespace ArticulationManager.Common.Utilities
{
    public sealed class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException( object value, object minValue, object maxValue )
            : this( $"Value is {value}. Min={minValue}, Max={maxValue}" )
        {}

        public ValueOutOfRangeException( string message ) : base( message )
        {}
    }
}