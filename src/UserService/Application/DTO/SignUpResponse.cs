namespace UserService.DTO
{
    using System.Collections.Generic;
    using UserService.Domain;

    public record SignUpResponse
    {
        public string Login { get; set; } = string.Empty;

        public List<RoleType> Role { get; set; } = new ();
    }
}