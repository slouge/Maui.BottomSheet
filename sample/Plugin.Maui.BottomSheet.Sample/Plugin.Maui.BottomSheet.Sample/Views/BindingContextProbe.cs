namespace Plugin.Maui.BottomSheet.Sample.Views;

/// <summary>
/// Label that displays the type of its current BindingContext and whether it matches <see cref="ExpectedType"/>.
/// Used by the BindingContext repro page to make the overwritten contexts visible.
/// </summary>
public sealed class BindingContextProbe : Label
{
    public static readonly BindableProperty ExpectedTypeProperty = BindableProperty.Create(
        nameof(ExpectedType),
        typeof(string),
        typeof(BindingContextProbe),
        propertyChanged: (bindable, _, _) => ((BindingContextProbe)bindable).Refresh());

    public BindingContextProbe()
    {
        FontSize = 12;
        FontAttributes = FontAttributes.Bold;
        Refresh();
    }

    public string? ExpectedType
    {
        get => (string?)GetValue(ExpectedTypeProperty);
        set => SetValue(ExpectedTypeProperty, value);
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Refresh();
    }

    private void Refresh()
    {
        string actual = BindingContext?.GetType().Name ?? "null";
        bool ok = string.Equals(actual, ExpectedType, StringComparison.Ordinal);

        Text = ok
            ? $"OK - BindingContext: {actual}"
            : $"BUG - BindingContext: {actual} (expected {ExpectedType})";
        TextColor = ok ? Colors.Green : Colors.Red;
    }
}
