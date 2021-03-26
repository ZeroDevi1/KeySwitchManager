using KeySwitchManager.UseCases.KeySwitches.Removing;

namespace KeySwitchManager.Presenters.KeySwitch
{
    public interface IRemovingPresenter : IPresenter<RemovingResponse>
    {
        public class Null : IRemovingPresenter
        {}

        public class Console : IRemovingPresenter
        {
            public void Present<T>( T param )
            {
                System.Console.WriteLine( param );
            }
        }
    }
}