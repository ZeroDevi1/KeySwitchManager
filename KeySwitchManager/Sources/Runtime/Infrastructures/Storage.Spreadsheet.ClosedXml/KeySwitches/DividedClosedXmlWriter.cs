using System;
using System.Collections.Generic;

using KeySwitchManager.Commons.Data;
using KeySwitchManager.Domain.KeySwitches.Models;
using KeySwitchManager.Infrastructures.Storage.KeySwitches.Helper;

namespace KeySwitchManager.Infrastructures.Storage.Spreadsheet.ClosedXml.KeySwitches
{
    public class DividedClosedXmlWriter : IKeySwitchWriter
    {
        private const string Suffix = ".xlsx";

        public DirectoryPath OutputDirectory { get; }
        public bool LeaveOpen => false;

        public DividedClosedXmlWriter( DirectoryPath outputDirectory )
        {
            OutputDirectory = outputDirectory;
        }

        public void Dispose() {}

        public void Write( IReadOnlyCollection<KeySwitch> keySwitches, IObserver<string>? loggingSubject = null )
        {
            MultipleWritingHelper.Write(
                keySwitches,
                OutputDirectory,
                Suffix,
                loggingSubject,
                stream => new ClosedXmlWriter( stream, true )
            );
        }
    }
}
