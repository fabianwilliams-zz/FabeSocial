using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FabeSocial.iOS
{
	public partial class SecondViewController : UIViewController
	{
        private SIService siService;

        public SecondViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Second", "Second");
			TabBarItem.Image = UIImage.FromBundle ("second");
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            siService = SIService.DefaultService;
            await siService.InitializeStoreAsync();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

        #region UI Items

        async partial void OnAdd (UIButton sender)
        {
            if (string.IsNullOrWhiteSpace(fname.Text))
                return;
            
            var newItem = new SocialItem
            {
                //add items here
                FirstName = fname.Text,
                LastName = lname.Text,
                EmailAddr = emailaddr.Text,
                MobilePhone = cphone.Text,
                TwitterHandle = twitterh.Text,
                IGName = igname.Text,
                FBName = fbname.Text
            };

            await siService.InsertSocItemAsync(newItem);

            var index = siService.Items.FindIndex(item => item.Id == newItem.Id);

            //TableView.InsertRows(new[] { NSIndexPath.FromItemSection(index, 0) },
            //UITableViewRowAnimation.Top);

            //itemText.Text = "";
        }

        #endregion
    }
}

