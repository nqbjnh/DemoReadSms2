using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Database;
using Android.OS;

namespace DemoReadSms2.Droid
{
    [Activity(Label = "DemoReadSms2", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            var smsReceiver = new SmsBroadcastReceiver();
            this.RegisterReceiver(smsReceiver, new IntentFilter("android.provider.Telephony.SMS_RECEIVED"));
            /*string[] reqCols = { "_id", "address", "body","read","date" };
            Android.Net.Uri uri = Android.Net.Uri.Parse("content://sms/inbox");
            var cursor = ContentResolver.Query(uri, reqCols, null, null, null);
            var countSms = cursor.Count;
            
            while (cursor.MoveToNext())
            {
                SmsObject smsObject = new SmsObject()
                {
                    Id = cursor.GetString(cursor.GetColumnIndexOrThrow("_id")),
                    Address = cursor.GetString(cursor.GetColumnIndexOrThrow("address")),
                    Body = cursor.GetString(cursor.GetColumnIndexOrThrow("body")),
                    Read= cursor.GetString(cursor.GetColumnIndexOrThrow("read")),
                    Date = cursor.GetString(cursor.GetColumnIndexOrThrow("date")),
                };


            }
            cursor.Close();*/
        }

       /* public ICursor GetCursorSms()
        {
            return ContentResolver.Query(uri, reqCols, null, null, null);
        }*/
        
    }

   /* public class ReadSms1 : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public void sdfdf()
        {
            global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity.
            string[] reqCols = { "_id", "address", "body", "read", "date" };
            Android.Net.Uri uri = Android.Net.Uri.Parse("content://sms/inbox");
            var cursor = ContentResolver.Query(uri, reqCols, null, null, null);
            var countSms = cursor.Count;

            while (cursor.MoveToNext())
            {
                SmsObject smsObject = new SmsObject()
                {
                    Id = cursor.GetString(cursor.GetColumnIndexOrThrow("_id")),
                    Address = cursor.GetString(cursor.GetColumnIndexOrThrow("address")),
                    Body = cursor.GetString(cursor.GetColumnIndexOrThrow("body")),
                    Read = cursor.GetString(cursor.GetColumnIndexOrThrow("read")),
                    Date = cursor.GetString(cursor.GetColumnIndexOrThrow("date")),
                };


            }
            cursor.Close();
        }
    }*/
   
}
