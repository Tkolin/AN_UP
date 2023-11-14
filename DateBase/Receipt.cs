using System;

namespace AN_UP.DateBase;

public class Receipt
{
    public int ID { get; set; }
    public   decimal Amount { get; set; }
    public  int DiseaseRecordID { get; set; }
    public   DateTime  DatePayment { get; set; }
}