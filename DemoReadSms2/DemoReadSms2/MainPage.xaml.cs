using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoReadSms2
{
	public partial class MainPage : ContentPage
	{
	    private ObservableCollection<SmsObject> _smss;
        private IEnumerable<SmsObject> listSmss;
	    public ObservableCollection<SmsObject> Smss
	    {
	        get { return _smss; }
	        set
	        {
	            _smss = value;
	            OnPropertyChanged();
	        }
	    }
        public MainPage()
		{
			InitializeComponent();
		    var iReadSms = DependencyService.Get<IReadSms>();
            var iReceiverSms = DependencyService.Get<IReceiverSms>();
            iReceiverSms.Init(RefreshListSms);
		    var tmp = iReadSms.GetAll();
		    Smss = new ObservableCollection<SmsObject>(tmp.Take(10));

            this.listSms.ItemsSource = Smss;
		   /* Device.StartTimer(TimeSpan.FromSeconds(10), () =>
		    {
		        Smss.Add(new SmsObject()
		        {
		            Id = "1",
                    Address = "11111111111111",
                    Body = "1111111111"
		        });

                return true;
		    });*/

		}

	    public void RefreshListSms(SmsObject smsObject)
	    {
	        Smss.Add(smsObject);
        }

	}
}
