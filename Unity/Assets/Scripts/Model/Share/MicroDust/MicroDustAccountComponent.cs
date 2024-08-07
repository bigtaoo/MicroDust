namespace ET
{
    public class MicroDustAccount : Entity
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string UserId { get; set; }
    }
}
