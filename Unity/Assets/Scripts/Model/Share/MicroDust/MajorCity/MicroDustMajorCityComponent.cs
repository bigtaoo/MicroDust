namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustMajorCityComponent : Entity, IAwake
    {
        public string UserId;
        public MicroDustCityInfo MajorCityInfo { get; set; } = new();
        public MicroDustCityInfo SecondCityInfo { get; set; } = new();
    }
}
