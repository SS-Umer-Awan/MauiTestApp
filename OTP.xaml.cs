using MauiTestApp.ViewModels;
using MauiTestApp.ViewModels.LoginViewModels;

namespace MauiTestApp;

public partial class OTP : ContentPage
{
    Entry[] entries;

    VerifySmsAndMailOTPViewModel vm;
    public OTP()
    {
    }
    public OTP(VerifySmsAndMailOTPViewModel viewModel)
	{
		InitializeComponent();

        foreach (Entry entry in entries)
        {
            entry.TextChanged += Entry_TextChanged;
        }
        this.vm = viewModel;

	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (string.IsNullOrEmpty(e.NewTextValue)) // If backspacing or clearing
        {
            int index = Array.IndexOf(entries, entry);
            if (index > 0)
            {
                entries[index - 1].Focus(); // Move focus to the previous entry
                entries[index - 1].Text = ""; // Clear the previous entry
            }
        }
        else // If entering a new character
        {
            int index = Array.IndexOf(entries, entry);
            if (index < entries.Length - 1)
            {
                entries[index + 1].Focus(); // Move focus to the next entry
            }
        }
    }
}