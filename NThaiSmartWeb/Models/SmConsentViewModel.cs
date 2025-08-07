using System.ComponentModel.DataAnnotations;

public class SmConsentViewModel
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime CardIssuedDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime CardExpiryDate { get; set; }

    public string ImageBase64 { get; set; }
}