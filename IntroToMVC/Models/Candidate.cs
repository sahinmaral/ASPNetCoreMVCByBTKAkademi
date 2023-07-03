using System.ComponentModel.DataAnnotations;

namespace IntroToMVC.Models;

public class Candidate
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = String.Empty;
    [Required(ErrorMessage = "Surname is required")]
    public string Surname { get; set; } = String.Empty;
    [Required(ErrorMessage = "E-mail is required")]
    public string Email { get; set; } = String.Empty;
    public string FullName => $"{Name} {Surname?.ToUpper()}";
    public int? Age { get; set; }
    public String? SelectedCourse { get; set; } = String.Empty;
    public DateTime ApplyAt { get; set; }
    public Candidate()
    {
        ApplyAt = DateTime.Now;
    }
}