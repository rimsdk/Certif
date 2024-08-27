using System.ComponentModel.DataAnnotations;

public class UpdateRequestStatusDto
{
    [Required]
    public string Status { get; set; }
}
