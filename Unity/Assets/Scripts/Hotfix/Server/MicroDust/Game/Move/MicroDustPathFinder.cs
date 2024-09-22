namespace ET.Server
{
    public static class MicroDustPathFinder
    {
        public static ListComponent<MicroDustPosition> FindPath(MicroDustPosition start, MicroDustPosition end)
        {
            var result = new ListComponent<MicroDustPosition>();
            var current = start;
            var p = MicroDustPosition.Create();
            p.X = current.X;
            p.Y = current.Y;
            result.Add(p);
            while (current.X != end.X || current.Y != end.Y)
            {
                if (current.X < end.X)
                {
                    ++current.X;
                }
                else if (current.X > end.X)
                {
                    --current.X;
                }
                if (current.Y < end.Y)
                {
                    ++current.Y;
                }
                else if (current.Y > end.Y)
                {
                    --current.Y;
                }
                Log.Debug($"path, add current: {current.X}, {current.Y}");
                p = MicroDustPosition.Create();
                p.X = current.X;
                p.Y = current.Y;
                result.Add(p);
            }

            return result;
        }
    }
}
