using System.Reactive;
using ReactiveUI;

namespace OpenUtauMobile.ViewModels;

public class OptionsViewModel : NavigateViewModelBase
{
    public ReactiveCommand<Unit, Unit> BackCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenSettingsCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenDependencyManagerCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenPluginManagerCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenHelpCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenExportLogsCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenAboutCommand { get; }

    public OptionsViewModel(MainViewModel navigator) : base(navigator)
    {
        BackCommand = ReactiveCommand.Create(OnBack);
        OpenSettingsCommand = ReactiveCommand.Create(OnOpenSettings);
        OpenDependencyManagerCommand = ReactiveCommand.Create(OnOpenDependencyManager);
        OpenPluginManagerCommand = ReactiveCommand.Create(() => Navigator.Navigate(new PluginManagerViewModel(Navigator)));
        OpenHelpCommand = ReactiveCommand.Create(OnOpenHelp);
        OpenExportLogsCommand = ReactiveCommand.Create(OnOpenExportLogs);
        OpenAboutCommand = ReactiveCommand.Create(OnOpenAbout);
    }

    private void OnBack()
    {
        Navigator.NavigateBack(this);
    }

    private void OnOpenSettings()
    {
        Navigator.Navigate(new SettingsViewModel(Navigator));
    }

    private void OnOpenDependencyManager()
    {
        Navigator.Navigate(new DependencyManagerViewModel(Navigator));
    }

    private void OnOpenHelp()
    {
        Navigator.Navigate(new HelpViewModel(Navigator));
    }

    private void OnOpenExportLogs()
    {
        Navigator.Navigate(new ExportLogsViewModel(Navigator));
    }

    private void OnOpenAbout()
    {
        Navigator.Navigate(new AboutViewModel(Navigator));
    }
}
