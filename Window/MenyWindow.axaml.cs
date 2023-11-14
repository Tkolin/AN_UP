using AN_UP.DateBase;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AN_UP.Window;

public partial class MenyWindow : Avalonia.Controls.Window
{
    private Doctor user;

    public MenyWindow(Doctor user)
    {
        InitializeComponent();
        this.user = user;
        switch (user.PositionID)
        {
            case 1: //Админ
                BtnProcedure.IsVisible = true;
                BtnDisease.IsVisible = true;
                BtnReports.IsVisible = true;
                break;
            case 2: //Менеджер
                BtnProcedure.IsVisible = false;
                BtnDisease.IsVisible = true;
                BtnReports.IsVisible = true;
                break;
            case 3: //Врач
                BtnProcedure.IsVisible = true;
                BtnDisease.IsVisible = false;
                BtnReports.IsVisible = false;
                break;
        }
    }

    private void BtnDisease_OnClick(object? sender, RoutedEventArgs e)
    {
        PacientDiseaseWindow window = new PacientDiseaseWindow();
        window.ShowDialog(this);
    }

    private void BtnProcedure_OnClick(object? sender, RoutedEventArgs e)
    {
        ProcedureWindow window = new ProcedureWindow();
        window.ShowDialog(this);
    }

    private void BtnBack_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void BtnReports_OnClick(object? sender, RoutedEventArgs e)
    {
        ReportWindow window = new ReportWindow();
        window.ShowDialog(this);
    }
}