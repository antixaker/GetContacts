using System;
using System.Linq;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Contacts;
using System.Threading.Tasks;

namespace GetContacts.Droid
{
    [Activity(Label = "GetContacts", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MessagingCenter.Subscribe<object>(this, "get",  (o) =>
            {
                var book = new AddressBook(this);
                //if (!await book.RequestPermission())
                //{
                //    Toast.MakeText(this, "Go to ass", ToastLength.Long).Show();
                //    return;
                //}
                int counter = 0;
                //var kj = book.ToList<Contact>();
                foreach (var item in book)//.OrderBy(x => x.Emails!=null || x.Emails.Count<Email>()!=0/*.First<Email>().Address*/))
                {
                    var numb = item.Emails.Count<Email>();
                    if(numb>0)
                        MessagingCenter.Send<object, string>(this, "contact", item.Emails.FirstOrDefault<Email>().Address);
                    
                    Console.WriteLine(counter++);
                    //if (counter > 2)
                    //    return;
                }
                
            });

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

