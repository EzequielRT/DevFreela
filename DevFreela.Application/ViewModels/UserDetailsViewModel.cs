using System;

namespace DevFreela.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}