namespace Plugin.Maui.BottomSheet.Sample.ViewModels;

/// <summary>
/// Parent view model of the BindingContext repro page (see upstream PR #262).
/// It exposes a <see cref="Child"/> view model that a child view binds as its own BindingContext.
/// </summary>
public sealed class BindingContextReproViewModel(int generation)
{
    public string Title => $"Parent view model #{generation}";

    public ChildContextViewModel Child { get; } = new($"Bound child view model #{generation}");

    public IReadOnlyList<ReproItemViewModel> Items { get; } =
    [
        new($"Living room (#{generation})"),
        new($"Kitchen (#{generation})"),
        new($"Bedroom (#{generation})"),
    ];
}

/// <summary>
/// Item of a list rendered with a BindableLayout: each row gets its item as BindingContext.
/// </summary>
public sealed class ReproItemViewModel(string name)
{
    public string Name { get; } = name;
}

/// <summary>
/// View model used by a child view through <c>BindingContext="{Binding Child}"</c>.
/// </summary>
public sealed class ChildContextViewModel(string name)
{
    public string Name { get; } = name;
}

/// <summary>
/// View model assigned explicitly (in XAML) as the BindingContext of a child view.
/// </summary>
public sealed class ExplicitChildContextViewModel
{
    public string Name => "Explicit child view model";
}
