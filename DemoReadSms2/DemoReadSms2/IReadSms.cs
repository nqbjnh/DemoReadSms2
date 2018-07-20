using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DemoReadSms2
{
    public interface IReadSms
    {
        ObservableCollection<SmsObject> GetAll();
    }
}