using System;
using System.Collections.Generic;
using System.Linq;
using AN_UP.DateBase;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AN_UP.Window;

public partial class PacientDiseaseWindow : Avalonia.Controls.Window
{
    private List<DiseaseRecord> _DataDiseaseRecord { get; set; }
    private List<DiseaseRecord> _ViewDiseaseRecord { get; set; }

    private List<Patient> _PatientList { get; set; }
    private List<Doctor> _DoctorList { get; set; }
    private List<Status> _StatusList { get; set; }
    private List<Disease> _DiseaseList { get; set; }
    public PacientDiseaseWindow()
    {
        InitializeComponent();
        DownloadDataGrid();
        UpdateComboBox();
    }
    public void DownloadDataGrid()
    {
        _DataDiseaseRecord = DataBaseManager.GetDiseaseRecords();
        UpdateDataGrid();
    }
    private void UpdateDataGrid()
    {
        _ViewDiseaseRecord = _DataDiseaseRecord;
        
        if (SearchBox.Text.Length > 0)
            _ViewDiseaseRecord = _ViewDiseaseRecord.Where(c => 
                c.Id.ToString().Contains(SearchBox.Text) ||
                c.PatientID.ToString().Contains(SearchBox.Text) ||
                c.FinalPrice.ToString().Contains(SearchBox.Text) ||
                c.DateStart.ToString().Contains(SearchBox.Text) ||
                c.DateEnd.ToString().Contains(SearchBox.Text) ||
                c.StatusID.ToString().Contains(SearchBox.Text) ||
                c.AttendingDoctorID.ToString().Contains(SearchBox.Text) ||
                c.DiseaseID.ToString().Contains(SearchBox.Text)
                                                              ).ToList();
        
        DataGrid.ItemsSource = _ViewDiseaseRecord;
        
    }

    private void UpdateComboBox()
    {
        _DiseaseList = DataBaseManager.GetDiseases();
        _StatusList= DataBaseManager.GetStatusList();
        _DoctorList = DataBaseManager.GetDoctors();
        _PatientList= DataBaseManager.GetPatients();
        
        CBoxDisease.ItemsSource = _DiseaseList;
        CBoxPatient.ItemsSource = _PatientList;
        CBoxStatus.ItemsSource = _StatusList;
        CBoxAttendingDoctor.ItemsSource = _DoctorList;
    }
    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataGrid.SelectedItem == null)
        {

            CBoxPatient.SelectedItem = null;
            NUpDownFinalPrice.Value = null;
            DPickerDateStart.SelectedDate = DateTimeOffset.Now;
            DPickerDateEnd.SelectedDate = null;
            CBoxPatient.SelectedItem = null;
            CBoxPatient.SelectedItem = null;
            CBoxPatient.SelectedItem = null;

        }
        else
        {
            DiseaseRecord value = DataGrid.SelectedItem as DiseaseRecord; 
            CBoxPatient.SelectedItem = _PatientList.Where(c => value.PatientID == c.Id);
            NUpDownFinalPrice.Value = value.FinalPrice;
            DPickerDateStart.SelectedDate = value.DateStart;
            DPickerDateEnd.SelectedDate = value.DateEnd;
            CBoxPatient.SelectedItem = _PatientList.Where(c => value.PatientID == c.Id);
            CBoxPatient.SelectedItem = _PatientList.Where(c => value.PatientID == c.Id);
            CBoxPatient.SelectedItem = _PatientList.Where(c => value.PatientID == c.Id);
        }
    }

    private void BtnDelet_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
        
        DataBaseManager.RemoveDiseaseRecord(DataGrid.SelectedItem as DiseaseRecord);
        
        DownloadDataGrid();
    }

    private void BtnRemoveSelect_OnClick(object? sender, RoutedEventArgs e)
    {
        DataGrid.SelectedItem = null;
    }
    
    private void ResetBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        SearchBox.Text = "";
    }

    private void BtnSavet_OnClick(object? sender, RoutedEventArgs e)
    {
        if (CBoxPatient.SelectedItem == null || 
            DPickerDateStart.SelectedDate == null || 
            CBoxStatus.SelectedItem == null || 
            CBoxAttendingDoctor.SelectedItem == null ||
            CBoxDisease.SelectedItem == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не заполнены", ButtonEnum.Ok).ShowAsync();
            return;
        }


        if (DataGrid.SelectedItem == null)
        {
            DataBaseManager.AddDiseaseRecord(new DiseaseRecord(
                0, 
                (CBoxPatient.SelectedItem as Patient).Id,
                NUpDownFinalPrice.Value.Value,
                DPickerDateStart.SelectedDate.Value.Date,
                DPickerDateEnd.SelectedDate.Value.Date,
                (CBoxStatus.SelectedItem as Status).Id,
                (CBoxAttendingDoctor.SelectedItem as Doctor).Id,
                (CBoxDisease.SelectedItem as Disease).Id
                ));
        }
  
        else
        {
            DataBaseManager.UpdateDiseaseRecord(new DiseaseRecord(
                ((DiseaseRecord)DataGrid.SelectedItem).Id,              
                (CBoxPatient.SelectedItem as Patient).Id,
                NUpDownFinalPrice.Value.Value,
                DPickerDateStart.SelectedDate.Value.Date,
                DPickerDateEnd.SelectedDate.Value.Date,
                (CBoxStatus.SelectedItem as Status).Id,
                (CBoxAttendingDoctor.SelectedItem as Doctor).Id,
                (CBoxDisease.SelectedItem as Disease).Id
            ));
        }

        DownloadDataGrid();
    }
    

    private void BtnCreateProcedure_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
       
        AddProcedureWindow wAddReport =
            new AddProcedureWindow(DataGrid.SelectedItem as DiseaseRecord);
        wAddReport.ShowDialog(this);
    }

    private void BtnRecover_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
        
        DiseaseRecord diseaseRecord = DataGrid.SelectedItem as DiseaseRecord;

        diseaseRecord.StatusID = 4;
        diseaseRecord.DateEnd = DateTime.Now;
        
        DataBaseManager.UpdateDiseaseRecord(diseaseRecord);
        
        DownloadDataGrid();
    }
}