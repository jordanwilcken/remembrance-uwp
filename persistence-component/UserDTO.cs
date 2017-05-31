namespace persistence_component
{
    public sealed class UserDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string HashedPassword { get; set; }
    }
}
