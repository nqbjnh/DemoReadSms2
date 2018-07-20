using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Telephony;
using Android.Util;
using DemoReadSms2.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SmsBroadcastReceiver))]
namespace DemoReadSms2.Droid
{
    [BroadcastReceiver(Enabled = true, Label = "SMS Receiver")]
    public class SmsBroadcastReceiver : BroadcastReceiver, IReceiverSms
    {
        private static Action<SmsObject> _onReceiverSmsComplete;
        private const string IntentAction = "android.provider.Telephony.SMS_RECEIVED";
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                if (intent.Action != IntentAction)
                {
                    return;
                }
                var bundle = intent.Extras;
                if (bundle == null)
                {
                    return;
                }
                var pdus = bundle.Get("pdus");
                var castedPdus = JNIEnv.GetArray<Java.Lang.Object>(pdus.Handle);
                var msgs = new SmsMessage[castedPdus.Length];
                for (var i = 0; i < msgs.Length; i++)
                {
                    var bytes = new byte[JNIEnv.GetArrayLength(castedPdus[i].Handle)];
                    JNIEnv.CopyArray(castedPdus[i].Handle, bytes);
                    msgs[i] = SmsMessage.CreateFromPdu(bytes);
                    //if (null != msgs[i].DisplayMessageBody && msgs[i].DisplayMessageBody.ToUpper().StartsWith("SMS from source"))
                    //{
                    var smsObject = new SmsObject() {Address = "hehe", Body = "hihiiiiiiiiiii"};
                    try
                    {
                        string verificationCode = msgs[i].DisplayMessageBody;
                        /*Intent otpIntent = new Intent(Application.Context, typeof(MainActivity));
                        otpIntent.PutExtra("verificationCode", verificationCode.Trim());
                        otpIntent.PutExtra("fromsms", "OK");
                        otpIntent.AddFlags(ActivityFlags.NewTask | ActivityFlags.SingleTop);
                        context.StartActivity(otpIntent);*/
                        smsObject.Body = msgs[i].DisplayMessageBody;
                        smsObject.Address = msgs[i].OriginatingAddress;
                        smsObject.Date = msgs[i].TimestampMillis.ToString();
                        //smsObject.Id = msgs[i].
                    }
                    catch (Exception e)
                    {
                        
                    }
                        
                    //}
                    if (_onReceiverSmsComplete != null)
                    {
                        _onReceiverSmsComplete.Invoke(smsObject);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("DemoReadSms1", ex.Message);
            }
        }


        public void Init(Action<SmsObject> onReceiverSmsComplete)
        {
            _onReceiverSmsComplete = onReceiverSmsComplete;
        }
    }
}