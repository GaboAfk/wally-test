namespace WallyTest.Models
{
       public class User
       {
              public string name { get; set; }
              public string email { get; set; }
              public int Id { get; set; }
       }

       public class Tickets
       {
              public int Id { get; set; }
              public int Priority { get; set; }
              public List<string> CcEmails { get; set; }
              public List<string> ReplyCcEmails { get; set; }
       }

       public class Record
       {
              public List<Users> Users { get; set; }
              public List<Tickets> Tickets { get; set; }
       }

       public class ApiResponse
       {
              public Record Record { get; set; }
       }
}


