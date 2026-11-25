using Plugin.Maui.BottomSheet.Sample.ViewModels;

namespace Plugin.Maui.BottomSheet.Sample.Views;

public partial class BindingContextReproPage : ContentPage
{
    private int _generation = 1;

    public BindingContextReproPage()
    {
        InitializeComponent();
        BindingContext = new BindingContextReproViewModel(_generation);
    }

    private void OnOpenContentClicked(object? sender, EventArgs e)
    {
        ContentSheet.IsOpen = true;
    }

    private void OnOpenTemplateClicked(object? sender, EventArgs e)
    {
        TemplateSheet.IsOpen = true;
    }

    private void OnSwapClicked(object? sender, EventArgs e)
    {
        BindingContext = new BindingContextReproViewModel(++_generation);
    }
}
