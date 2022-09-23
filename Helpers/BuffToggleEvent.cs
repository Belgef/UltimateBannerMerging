using System;
using Terraria;

namespace UltimateBannerMerging.Helpers;

internal class BuffToggleEvent
{
    private bool _isOn;
    public Action OnStart;
    public Action OnStop;
    public Func<bool> CheckStart;
    public Func<bool> CheckStop;

    public BuffToggleEvent(int type, Player player, Func<bool> checkStart, Func<bool> checkStop, bool defaultState = false)
    {
        CheckStart = checkStart;
        CheckStop = checkStop;
        OnStart = () => player.AddBuff(type, int.MaxValue);
        OnStop = () => player.ClearBuff(type);
        _isOn = defaultState;
    }

    public void Update()
    {
        switch (_isOn)
        {
            case false when CheckStart():
                _isOn = true;
                OnStart();
                break;
            case true when CheckStop():
                _isOn = false;
                OnStop();
                break;
        }
    }
}