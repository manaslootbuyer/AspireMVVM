using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MvvmAspire.Controls
{
	/// <summary>
	/// Converter for using in Entry fields for masked input of currency.
	/// <para>The binded property must be of type decimal, and must invoke the PropertyChangedEventArgs event whenever the value is changed, so that the desired mask behavior is kept.</para>
	/// </summary>
	public class CurrencyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//return Decimal.Parse(value.ToString()).ToString("C");

			if (targetType != typeof(string))
				throw new InvalidOperationException("The target must be a boolean");

            if (string.IsNullOrEmpty(value.ToString()))
            {
                Regex check = new Regex(@"[^0-9]");

                string oldAmountString = value.ToString().Replace("$", "").Replace(",", "").Replace(".", "");
                string newAmountString;
                double newAmount;
                string formattedString;

                if (value.ToString() == "")
                {

                    newAmountString = oldAmountString.Substring(0, oldAmountString.Length - 1);

                    newAmount = System.Convert.ToDouble(newAmountString.Replace("$", "").Replace(",", "").Replace("(", "").Replace(")", ""), new CultureInfo("en-US"));

                    newAmount /= 100f;

                    formattedString = String.Format(new CultureInfo("en-US"), "{0:C}", newAmount);
                    value = formattedString;

                    return false;
                }

                if (value.ToString().Length > 20)
                {
                    return false;
                }

                if (check.IsMatch(value.ToString()))
                {
                    return false;
                }

                newAmountString = oldAmountString + value.ToString();

                if (newAmountString.Equals("."))
                {
                    newAmountString = "0.00";
                }

                newAmount = System.Convert.ToDouble(newAmountString, new CultureInfo("en-US"));
                newAmount /= 100f;

                formattedString = string.Format(new CultureInfo("en-US"), "{0:C}", newAmount);
                value = formattedString;

                return false;
            }

			return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
				return 0m;

			long valueLong;
			if (!long.TryParse(valueFromString, out valueLong))
				return 0m;

			if (valueLong <= 0)
				return 0m;

			return valueLong / 100m;
		}
	}
}
