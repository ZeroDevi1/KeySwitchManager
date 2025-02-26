using System;

using KeySwitchManager.Domain.KeySwitches.Models;
using KeySwitchManager.Interactors.KeySwitches;
using KeySwitchManager.UseCase.KeySwitches.Import;

using RkHelper.System;

namespace KeySwitchManager.Applications.Core.Controllers.Import
{
    public class ImportFileController : IController
    {
        private IKeySwitchRepository DatabaseRepository { get; }
        private IKeySwitchReader KeySwitchReader { get; }
        private IImportFilePresenter Presenter { get; }
        private bool LeaveOpen { get; }

        private readonly IDisposable loggingSubscriber;

        #region Ctor
        public ImportFileController(
            IKeySwitchRepository databaseRepository,
            IKeySwitchReader reader,
            IImportFilePresenter presenter,
            bool leaveOpen = false )
        {
            DatabaseRepository = databaseRepository;
            KeySwitchReader    = reader;
            Presenter          = presenter;
            LeaveOpen          = leaveOpen;
            loggingSubscriber  = databaseRepository.OnLogging.Subscribe( onNext: presenter.Present, onError: presenter.Present );
        }
        #endregion

        public void Dispose()
        {
            Disposer.Dispose( loggingSubscriber );

            if( LeaveOpen )
            {
                return;
            }

            Disposer.Dispose( DatabaseRepository );

            if( !KeySwitchReader.LeaveOpen )
            {
                Disposer.Dispose( KeySwitchReader );
            }
        }

        public void Execute()
        {
            var keySwitches = KeySwitchReader.Read();
            var interactor = new ImportFileInteractor( DatabaseRepository, Presenter );
            var request = new ImportFileRequest( keySwitches );
            var response = interactor.Execute( request );
            DatabaseRepository.Flush();
            Presenter.Complete( response );
        }

    }
}
