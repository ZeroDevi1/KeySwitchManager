﻿using System;

using KeySwitchManager.Commons.Data;
using KeySwitchManager.GuiCore.View.LogView;
using KeySwitchManager.Infrastructure.Database.LiteDB.KeySwitches;
using KeySwitchManager.Infrastructure.Storage.Spreadsheet.ClosedXml.KeySwitches;
using KeySwitchManager.Storage.Yaml.KeySwitches;

namespace KeySwitchManager.GuiCore.Controllers.Import
{
    public static class ImportControllerFactory
    {
        public static IController Create( string databasePath, string importFilePath, ILogTextView logTextView )
        {
            var path = importFilePath.ToLower();

            if( path.EndsWith( ".xlsx" ) )
            {
                var databaseRepository = new LiteDbKeySwitchRepository( new FilePath( databasePath ) );
                var spreadSheetFileRepository = new ClosedXmlFileLoadRepository( new FilePath( importFilePath ) );
                var presenter = new ImportSpreadSheetPresenter( logTextView );
                return new ImportXlsxController( databaseRepository, spreadSheetFileRepository, presenter );
            }

            if( path.EndsWith( ".yaml" ) )
            {
                var databaseRepository = new LiteDbKeySwitchRepository( new FilePath( databasePath ) );
                var yamlFileRepository = new YamlKeySwitchFileRepository( new FilePath( importFilePath ), true );
                var presenter = new YamlImportPresenter( logTextView );
                return new ImportYamlController( databaseRepository, yamlFileRepository, presenter );
            }

            throw new ArgumentException( $"{importFilePath} is unknown file format" );
        }
    }
}
