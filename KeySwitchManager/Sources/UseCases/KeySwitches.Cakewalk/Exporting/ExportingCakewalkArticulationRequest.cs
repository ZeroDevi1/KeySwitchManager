using System;

namespace KeySwitchManager.UseCases.KeySwitches.Cakewalk.Exporting
{
    public class ExportingCakewalkArticulationRequest
    {
        public Guid Guid { get; }
        public string DeveloperName { get; }
        public string ProductName { get; }
        public string InstrumentName { get; }

        public ExportingCakewalkArticulationRequest(
            string developerName = "",
            string productName = "",
            string instrumentName = "" )
        {
            Guid           = default;
            DeveloperName  = developerName;
            ProductName    = productName;
            InstrumentName = instrumentName;
        }

        public ExportingCakewalkArticulationRequest(
            Guid guid = default,
            string developerName = "",
            string productName = "",
            string instrumentName = "" )
        {
            Guid           = guid;
            DeveloperName  = developerName;
            ProductName    = productName;
            InstrumentName = instrumentName;
        }
    }
}