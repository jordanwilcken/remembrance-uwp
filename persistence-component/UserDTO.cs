namespace persistence_component
{
    public sealed class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(DataFields fields)
        {
            var idResult = fields.Get("rowid");
            if (string.IsNullOrEmpty(idResult.Error) && idResult.Value.GetType() == ID.GetType())
                ID = (long)idResult.Value;

            var nameResult = fields.Get("username");
            if (string.IsNullOrEmpty(nameResult.Error) && nameResult.Value.GetType() == Name.GetType())
                Name = (string)nameResult.Value;

            var passwordResult = fields.Get("hashed_password");
            if (string.IsNullOrEmpty(passwordResult.Error) && passwordResult.Value.GetType() == HashedPassword.GetType())
                HashedPassword = (string)passwordResult.Value;
        }

        public long ID { get; set; }

        public string Name { get; set; } = "";

        public string HashedPassword { get; set; } = "";
    }
}
