using System.IO;

using KeySwitchManager.Common.Testing;
using KeySwitchManager.Databases.LiteDB.KeySwitches;
using KeySwitchManager.Interactors.KeySwitches.Exporting.Text;
using KeySwitchManager.Json.KeySwitches.Translations;
using KeySwitchManager.Presenters.KeySwitches;
using KeySwitchManager.UseCases.KeySwitches.Exporting.Text;

using NUnit.Framework;

namespace KeySwitchManager.Interactors.Testing.KeySwitches
{
    [TestFixture]
    public class ExportingJsonInteractorTest
    {
        [Test]
        public void ExportTest()
        {
            #region Adding To DB
            var dbRepository = new LiteDbKeySwitchRepository( new MemoryStream() );
            var entity = TestDataGenerator.CreateKeySwitch();
            dbRepository.Save( entity );
            #endregion

            var inputData = new InputData( entity.DeveloperName.Value, entity.ProductName.Value );
            var interactor = new ExportingJsonInteractor(
                dbRepository,
                new IExportingTextPresenter.Console(),
                new EntityToJsonModel()
            );

            interactor.Execute( inputData );
        }
    }
}