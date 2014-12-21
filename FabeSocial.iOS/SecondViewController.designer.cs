// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FabeSocial.iOS
{
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton addbutton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField cphone { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField emailaddr { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField fbname { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField fname { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField igname { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField lname { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField twitterh { get; set; }

		[Action ("OnAdd:")]
		partial void OnAdd (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (fname != null) {
				fname.Dispose ();
				fname = null;
			}

			if (lname != null) {
				lname.Dispose ();
				lname = null;
			}

			if (cphone != null) {
				cphone.Dispose ();
				cphone = null;
			}

			if (emailaddr != null) {
				emailaddr.Dispose ();
				emailaddr = null;
			}

			if (twitterh != null) {
				twitterh.Dispose ();
				twitterh = null;
			}

			if (igname != null) {
				igname.Dispose ();
				igname = null;
			}

			if (fbname != null) {
				fbname.Dispose ();
				fbname = null;
			}

			if (addbutton != null) {
				addbutton.Dispose ();
				addbutton = null;
			}
		}
	}
}
