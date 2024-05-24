using MudBlazor;

namespace KAST.Pages.Mission
{
    public partial class MissionOverview
    {
        string state = "MessageBox is open";

        private async void OnButtonClick()
        {
            bool? result = await DialogService.ShowMessageBox("Warning", "Das ist eine Message", yesText: "Delete!", cancelText: "Cancel");
            state = result == null ? "Canceld" : "Deleted";
            StateHasChanged();
        }


        private void OpenDialog()
        {
            var option = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<DialogMission>("DialogMission", option);

        }

    }
}
