namespace PersonalityIdentification.Helpers
{
    public class AuthResponseModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string jwtToken { get; set; }
    }
}