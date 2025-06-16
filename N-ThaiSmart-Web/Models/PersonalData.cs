public class PersonalData
{
    public string CitizenID { get; set; }
    public PersonalInfo ThaiPersonalInfo { get; set; }
    public PersonalInfo EnglishPersonalInfo { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Sex { get; set; }
    public AddressInfo AddressInfo { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public string Issuer { get; set; }
    public string FullNameTH =>
    $"{this.ThaiPersonalInfo?.Prefix}{this.ThaiPersonalInfo?.FirstName} {this.ThaiPersonalInfo?.LastName}".Trim();

    public string FullNameEN =>
        $"{this.EnglishPersonalInfo?.Prefix}{this.EnglishPersonalInfo?.FirstName} {this.EnglishPersonalInfo?.LastName}".Trim();
}

public class PersonalPhoto : PersonalData
{
    public string Photo { get; set; }
}

public class PersonalInfo
{
    public string Prefix { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public override string ToString()
    {
        return string.Format(Prefix + FirstName + " " + LastName);
    }
}

public class AddressInfo
{
    public string HouseNo { get; set; }

    public string VillageNo { get; set; }

    public string Lane { get; set; }

    public string Road { get; set; }

    public string SubDistrict { get; set; }

    public string District { get; set; }

    public string Province { get; set; }

    public override string ToString()
    {
        string text = HouseNo;
        if (!string.IsNullOrEmpty(VillageNo))
        {
            text += string.Format(" ม." + VillageNo);
        }

        if (!string.IsNullOrEmpty(Lane))
        {
            text += string.Format(" ซ." + Lane);
        }

        if (!string.IsNullOrEmpty(Road))
        {
            text += string.Format(" ถ." + Road);
        }

        if (!string.IsNullOrEmpty(SubDistrict))
        {
            text += string.Format(" ต." + SubDistrict);
        }

        if (!string.IsNullOrEmpty(District))
        {
            text += string.Format(" อ." + District);
        }

        if (!string.IsNullOrEmpty(Province))
        {
            text += string.Format(" จ." + Province);
        }

        return text;
    }
}