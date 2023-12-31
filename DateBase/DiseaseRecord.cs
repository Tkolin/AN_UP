﻿using System;

namespace AN_UP.DateBase;

public class DiseaseRecord
{
    public int Id { get; set; }
    public int PatientID  { get; set; }
    public decimal FinalPrice  { get; set; }
    public DateTime DateStart  { get; set; }
    public DateTime DateEnd  { get; set; }
    public int StatusID  { get; set; }
    public int AttendingDoctorID  { get; set; }
    public int DiseaseID  { get; set; }

    public DiseaseRecord( int id, int patientId, decimal finalPrice, DateTime dateStart, DateTime dateEnd
    , int statusId, int attendingDoctorId, int diseaseId)
    {
        Id = id;
        PatientID = patientId;
        FinalPrice = finalPrice;
        DateStart = dateStart;
        DateEnd = dateEnd;
        StatusID = statusId;
        AttendingDoctorID = attendingDoctorId;
        DiseaseID = diseaseId;
    }
}