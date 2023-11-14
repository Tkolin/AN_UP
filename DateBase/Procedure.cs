using System;

namespace AN_UP.DateBase;

public class Procedure
{
       public int ID  { get; set; }
       public   int      DoctorID { get; set; }
       public  int  DiseaseRecordID { get; set; }
       public    string        Description { get; set; }
       public DateTime   DateStart { get; set; }
       public    int       Duration { get; set; }
       public decimal  Cost { get; set; }
}