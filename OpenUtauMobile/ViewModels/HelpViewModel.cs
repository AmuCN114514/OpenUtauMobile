using System.Reactive;
using System.Threading.Tasks;
using OpenUtauMobile.Helpers;
using OpenUtauMobile.Services.Dialogs;
using OpenUtauMobile.Services.Platform;
using ReactiveUI;

namespace OpenUtauMobile.ViewModels;

/// <summary>帮助与教程页视图模型，负责返回导航与外部资源链接。</summary>
public class HelpViewModel : NavigateViewModelBase
{
    public ReactiveCommand<Unit, Unit> BackCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenRepositoryCommand { get; }
    public ReactiveCommand<Unit, Unit> OpenIssuesCommand { get; }

    public HelpViewModel(MainViewModel navigator) : base(navigator)
    {
        BackCommand = ReactiveCommand.Create(OnBack);
        OpenRepositoryCommand = ReactiveCommand.CreateFromTask(
            () => OpenUrlAsync("https://github.com/vocoder712/OpenUtauMobile"));
        OpenIssuesCommand = ReactiveCommand.CreateFromTask(
            () => OpenUrlAsync("https://github.com/vocoder712/OpenUtauMobile/issues"));
    }

    private void OnBack()
    {
        Navigator.NavigateBack(this);
    }

    private static async Task OpenUrlAsync(string url)
    {
        ExternalUrlLaunchResult result = await ExternalUrlService.OpenAsync(url);
        if (!result.Succeeded)
        {
            ToastService.Enqueue(L.S("Help.Toast.OpenLinkFailed"));
        }
    }
}
