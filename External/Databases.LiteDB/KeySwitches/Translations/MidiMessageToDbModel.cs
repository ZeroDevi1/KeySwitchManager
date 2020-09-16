using KeySwitchManager.Databases.LiteDB.KeySwitches.Model;
using KeySwitchManager.Domain.MidiMessages.Aggregate;
using KeySwitchManager.Domain.Translations;

namespace KeySwitchManager.Databases.LiteDB.KeySwitches.Translations
{
    public class MidiMessageToDbModel : IDataTranslator<IMessage, MidiMessageModel>
    {
        public MidiMessageModel Translate( IMessage source )
        {
            return new MidiMessageModel(
                source.Status.Value,
                source.Channel.Value,
                source.DataByte1.Value,
                source.DataByte2.Value
            );
        }
    }
}