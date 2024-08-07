namespace ET
{
    public struct MicroDustLoginFinished { }
    public struct MicroDustAppStartFinished { }
    public struct MicroDustEnterMapFinish { }
    public struct MicroDustSceneChangeStart { }
    public struct MicroDustSceneChangeFinish { }
    public struct MicroDustAfterCreateCurrentScene { }
    public struct MicroDustMajorCityView { }
    public struct MicroDustRecruitResult { }
    public struct MicroDustFetchHerosFinished { public string uiType { get; set; } }
    public struct MicroDustFetchSkillsFinished { public string uiType { get; set; } }
    public struct MicroDustUpdateArmyPosition
    {
        public int currentX {  get; set; }
        public int currentY { get; set; }
        public int nextX { get; set; }
        public int nextY { get; set; }
        public int time { get; set; }
    }
}
