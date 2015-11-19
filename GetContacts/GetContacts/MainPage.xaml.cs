using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GetContacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _button.Clicked += OnButtonClicked;
            MessagingCenter.Subscribe<object, string>(this, "contact", (obj, contact) => 
            {
                _label.Text += string.Format("\n{0}", contact);
            });
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object>(this, "get");
        }
    }
}
