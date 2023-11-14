using AN_UP.DateBase;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AN_UP.Window;

public partial class AddProcedureWindow : Avalonia.Controls.Window
{
    private DiseaseRecord _DiseaseRecord { get; set; }
    public AddProcedureWindow(DiseaseRecord diseaseRecord)
    {
        InitializeComponent();
        _DiseaseRecord = diseaseRecord;
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}