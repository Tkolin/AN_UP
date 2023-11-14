using System;
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
        DataBaseManager.AddProcedure(new Procedure(
            0,
            (CBoxDisiaseRecord.SelectedItem as Doctor).Id,
            (CBoxDisiaseRecord.SelectedItem as DiseaseRecord).Id,
            TBoxDescription.Text,
            DPickerDateStart.SelectedDate.Value.Date,
            Convert.ToInt32(NUpDownDuration.Value.Value),
            NUpDownCost.Value.Value,
            (CBoxStatus.SelectedItem as Status).Id
        ));
    }
}