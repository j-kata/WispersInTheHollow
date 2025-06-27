using WispersInTheHollow.World;

namespace WispersInTheHollow.Abstractions;

internal interface ILog
{
    void LogState(ILoggable source);
}
