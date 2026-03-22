public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Addres { get; set; }
    public string TelNo { get; set; }

    public User (int id , string name , string addres , string telNo)
    {
        Id = id;
        Name = name;
        Addres = addres;
        TelNo = telNo;

    }
}
