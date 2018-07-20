using System;

namespace DemoReadSms2
{
    public interface IReceiverSms
    {
        void Init(Action<SmsObject> onReceiverSmsComplete);
    }
}