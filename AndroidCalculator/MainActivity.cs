using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidCalculator
{
    [Activity(Label = "AndroidCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        private EditText first;
        private EditText second;
        private EditText result;
        private EditText error;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            Button add = FindViewById<Button>(Resource.Id.plus);
            Button sub = FindViewById<Button>(Resource.Id.minus);
            Button mult = FindViewById<Button>(Resource.Id.mult);

            first = FindViewById<EditText>(Resource.Id.edit1);
            second = FindViewById<EditText>(Resource.Id.edit2);
            result = FindViewById<EditText>(Resource.Id.result);
            error = FindViewById<EditText>(Resource.Id.error);

            if (bundle != null)
            {
                first.Text = bundle.GetString(TEXT_KEY_1);
                second.Text = bundle.GetString(TEXT_KEY_2);
                result.Text = bundle.GetString(TEXT_KEY_3);
                error.Text = bundle.GetString(TEXT_KEY_4);
            }

            double a = 0;
            double b = 0;

            add.Click += delegate
            {
                try
                {
                    a = double.Parse(first.Text);
                    b = double.Parse(second.Text);
                    result.Text = (a + b).ToString();
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message;
                }
            };

            sub.Click += delegate
            {
                try
                {
                    a = double.Parse(first.Text);
                    b = double.Parse(second.Text);
                    result.Text = (a - b).ToString();
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message;
                }
            };

            mult.Click += delegate
            {
                try
                {
                    a = double.Parse(first.Text);
                    b = double.Parse(second.Text);
                    result.Text = (a * b).ToString();
                }
                catch (Exception ex)
                {
                    error.Text = ex.Message;
                }
            };
        }

        #region Save State

        public const String TEXT_KEY_1 = "TEXT_KEY_1";
        public const String TEXT_KEY_2 = "TEXT_KEY_2";
        public const String TEXT_KEY_3 = "TEXT_KEY_3";
        public const String TEXT_KEY_4 = "TEXT_KEY_4";

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString(TEXT_KEY_1, first.ToString());
            outState.PutString(TEXT_KEY_2, second.ToString());
            outState.PutString(TEXT_KEY_3, result.ToString());
            outState.PutString(TEXT_KEY_4, error.ToString());
            base.OnSaveInstanceState(outState);
        }

        #endregion

    }
}

