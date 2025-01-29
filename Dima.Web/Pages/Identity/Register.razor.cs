using Dima.Core.Handlers;
using Dima.Web.Secutiry;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace Dima.Web.Pages.Identity;

public partial class RegisterPage : ComponentBase
{
    #region Dependencies
    
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
        
    [Inject]
    public IAccountHandler Handler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    #endregion
}

