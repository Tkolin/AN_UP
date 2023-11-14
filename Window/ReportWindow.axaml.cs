using System.Collections.Generic;
using AN_UP.DateBase;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AN_UP.Window;

public partial class ReportWindow : Avalonia.Controls.Window
{
    private List<Status> _StatusList { get; set; }
    private List<Doctor> _DoctorsList { get; set; }
    private List<Patient> _PatientsList { get; set; }
    public ReportWindow()
    {
        InitializeComponent();
        UpdateComboBox();
    }

    private void UpdateComboBox()
    {
        _StatusList = DataBaseManager.GetStatusList();
        _DoctorsList = DataBaseManager.GetDoctors();
        _PatientsList = DataBaseManager.GetPatients();

        CBoxStatus.SelectedItem = _StatusList;
        CBoxDoctor.SelectedItem = _DoctorsList;
        CBoxPatient.SelectedItem = _PatientsList;
    }
    
    private void GenerateReport()
    {
        List<Procedure> procedures = DataBaseManager.GetProcedures();

        decimal price = 0;

        if (CBoxPatient.SelectedItem == null)
            TBoxPatient.Text = "Все";
        else
            TBoxPatient.Text = (CBoxPatient.SelectedItem as Patient).FirstName + " " +
                               (CBoxPatient.SelectedItem as Patient).LastName;
        
        if (CBoxDoctor.SelectedItem == null)
            TBoxDoctor.Text = "Все";
        else
            TBoxDoctor.Text = (CBoxDoctor.SelectedItem as Doctor).FirstName + " " +
                              (CBoxDoctor.SelectedItem as Doctor).LastName;
        
        if (CBoxStatus.SelectedItem == null)
            TBoxStatus.Text = "Все";
        else
            TBoxStatus.Text = (CBoxStatus.SelectedItem as Status).Name;
           
        TBoxCountProcedure.Text = procedures.Count.ToString();
        TBoxDateSelected.Text =
            DPicerStart.SelectedDate.Value.ToString() + " - " + DPicerEnd.SelectedDate.Value.ToString();
        foreach (Procedure value in procedures)
        {
            TBoxProcedureList.Text += value.Id + " | " + value.DateStart.Date + " | " + value.Cost.ToString();
            price += value.Cost;
        }

        TBoxPrice.Text = price.ToString();

    }
    private void BtnPatientClear_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxPatient.SelectedItem = null;
    }

    private void BtnDoctorClear_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxDoctor.SelectedItem = null;
    }

    private void BtnStatusClear_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxStatus.SelectedItem = null;
    }

    private void BtnReset_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxPatient.SelectedItem = null;
        CBoxDoctor.SelectedItem = null;
        CBoxStatus.SelectedItem = null;
    }

    private void BtnGenerate_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxPatient.SelectedItem = null;
    }

    private void BtnGoPrint_OnClick(object? sender, RoutedEventArgs e)
    {
        CBoxPatient.SelectedItem = null;
        //Метод печати формы
    }
}