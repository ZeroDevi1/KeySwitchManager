using System;
using System.Linq;

using KeySwitchManager.Domain.KeySwitches.Helpers;
using KeySwitchManager.Domain.KeySwitches.Models;
using KeySwitchManager.UseCase.KeySwitches.Export.Daw;

namespace KeySwitchManager.Interactors.KeySwitches
{
    [Obsolete]
    public class ExportDawInteractor : IExportDawUseCase
    {
        private IKeySwitchRepository Repository { get; }
        private IKeySwitchRepository OutputRepository { get; }
        private IExportDawPresenter Presenter { get; }

        public ExportDawInteractor(
            IKeySwitchRepository repository,
            IKeySwitchRepository outputRepository ) :
            this( repository, outputRepository, new IExportDawPresenter.Null() )
        {}

        public ExportDawInteractor(
            IKeySwitchRepository repository,
            IKeySwitchRepository outputRepository,
            IExportDawPresenter presenter )
        {
            Repository       = repository;
            OutputRepository = outputRepository;
            Presenter        = presenter;
        }

        public ExportDawResponse Execute( ExportDawRequest request )
        {
            var developerName = request.DeveloperName;
            var productName = request.ProductName;
            var instrumentName = request.InstrumentName;

            var queryResult = SearchHelper.Search(
                Repository,
                request.Guid,
                developerName,
                productName,
                instrumentName
            );

            if( !queryResult.Any() )
            {
                Presenter.Present( "No keyswitch(es) found" );
                return new ExportDawResponse( false, queryResult );
            }

            foreach( var x in queryResult )
            {
                OutputRepository.Save( x );
            }

            var flushed = OutputRepository.Flush();

            if( flushed == 0 )
            {
                Presenter.Present( $"No keyswitch(es) flushed to storage/repository ({OutputRepository.GetType()})" );
            }

            return new ExportDawResponse( true, queryResult );
        }
    }
}