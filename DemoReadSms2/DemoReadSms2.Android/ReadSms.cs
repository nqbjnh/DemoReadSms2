using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using DemoReadSms2.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ReadSms))]
namespace DemoReadSms2.Droid
{
    public class ReadSms :IReadSms
    {
        public ObservableCollection<SmsObject> GetAll()
        {
            //ContentResolver.q
           
           
            string[] reqCols = { "_id", "address", "body", "read", "date" };
            Android.Net.Uri uri = Android.Net.Uri.Parse("content://sms/inbox");
           
            var cursor = Application.Context.ContentResolver.Query(uri, reqCols, null, null, null);
            var countSms = cursor.Count;
            var listSms = new ObservableCollection<DemoReadSms2.SmsObject>();
            while (cursor.MoveToNext())
            {
                var smsObject = new DemoReadSms2.SmsObject()
                {
                    Id = cursor.GetString(cursor.GetColumnIndexOrThrow("_id")),
                    Address = cursor.GetString(cursor.GetColumnIndexOrThrow("address")),
                    Body = cursor.GetString(cursor.GetColumnIndexOrThrow("body")),
                    Read = cursor.GetString(cursor.GetColumnIndexOrThrow("read")),
                    Date = cursor.GetString(cursor.GetColumnIndexOrThrow("date")),
                };

                listSms.Add(smsObject);
            }

            cursor.Close();
            return listSms;
        }

       
    }
}