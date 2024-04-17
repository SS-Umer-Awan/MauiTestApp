using MauiTestApp.ViewModels;
using System.Text;

namespace MauiTestApp.Views;

public partial class OTP : ContentPage
{
    OTPViewModel viewModel;
    private Entry[] _entries;
    private int _currentIndex;
    public OTP(OTPViewModel vm)
	{
        InitializeComponent();
        this.viewModel = vm;
        BindingContext = vm;
        _entries = new Entry[] { Entry1, Entry2, Entry3, Entry4, Entry5, Entry6 };

        foreach (var entry in _entries)
        {
            entry.TextChanged += OnEntryTextChanged;
        }
        _currentIndex = 0;

    }
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        Entry currentEntry = (Entry)sender;

        // If the text is cleared, move the cursor back
        if (string.IsNullOrEmpty(e.NewTextValue))
        {
            // Deleting a number
            if (_currentIndex > 0)
            {
                _currentIndex--;
                _entries[_currentIndex].Focus();
            }
            return;
        }

        if (!int.TryParse(e.NewTextValue, out int number) || number.ToString().Length > 1)
        {
            currentEntry.Text = "";
            return;
        }

        // Move to the next entry if a number is entered
        if (_currentIndex < _entries.Length - 1 && !string.IsNullOrEmpty(e.NewTextValue))
        {
            _currentIndex++;
            _entries[_currentIndex].Focus();
        }
        else if (_currentIndex == _entries.Length - 1 && !string.IsNullOrEmpty(e.NewTextValue))
        {
            // If the last entry is filled, trigger verification
            StringBuilder otpBuilder = new StringBuilder();
            foreach (var entry in _entries)
            {
                otpBuilder.Append(entry.Text);
            }
            string otp = otpBuilder.ToString();

        }

    }
}