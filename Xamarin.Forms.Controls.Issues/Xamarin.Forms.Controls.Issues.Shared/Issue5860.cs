using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.Forms.Core.UITests;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 5860, "5860 - EntryFlowDirection", PlatformAffected.UWP)]
	public class Issue5860 : TestContentPage
	{
		protected override async void Init()
		{
			await Navigation.PushModalAsync(new Issue5860Page());
		}

		public class Issue5860Page : ContentPage
		{
			public Issue5860Page()
			{
				Entry rtlEntry = new Entry
				{
					Text = "مرحبا بالعالم",
					FlowDirection = FlowDirection.RightToLeft,
				};

				Editor rtlEditor = new Editor
				{
					Text = "مرحبا بالعالم",
					FlowDirection = FlowDirection.RightToLeft,
				};


				Grid mainG = new Grid
				{
					RowDefinitions = {
					new RowDefinition { Height = GridLength.Star },
					new RowDefinition { Height = GridLength.Star }
					}
				};

				//mainG.Children.Add(rtlEntry, 0, 0);
				//mainG.Children.Add(rtlEditor, 0, 1);

				StackLayout mainStack = new StackLayout();

				mainStack.Children.Add(rtlEntry);
				mainStack.Children.Add(rtlEditor);

				Content = mainStack;
			}
		}

#if UITEST && __WINDOWS__
		[Test]
		[Category(UITestCategories.ManualReview)]
		public void Issue5860Test()
		{
			RunningApp.Screenshot("I am at Issue 5860 - Check alignment inside controls is as per the labels.");
		}
#endif
	}
}
