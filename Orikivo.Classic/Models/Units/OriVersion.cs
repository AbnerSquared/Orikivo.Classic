namespace Orikivo
{
    public class OriVersion
    {
        public OriVersion()
        {
            Major = 0;
            Minor = 0;
            Revision = 5;
            Patch = 0;
        }

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }
        public int Patch { get; set; }


        public void Update(UpdateType type)
        {
            switch (type)
            {
                case UpdateType.Major:
                    TickMajor();
                    break;
                case UpdateType.Minor:
                    TickMinor();
                    break;
                case UpdateType.Revision:
                    TickRevision();
                    break;
                default:
                    TickPatch();
                    break;
            }
        }

        public void TickPatch()
        {
            Patch += 1;
            if (Patch > 9)
            {
                while (Patch > 9)
                {
                    Patch = Patch - 10;
                    TickRevision();
                }
            }
        }

        public void TickRevision()
        {
            Revision += 1;
            if (Revision > 9)
            {
                while (Revision > 9)
                {
                    Revision = Revision - 10;
                    TickMinor();
                }
            }
        }

        public void TickMinor()
        {
            Minor += 1;
            if (Minor > 9)
            {
                while (Minor > 9)
                {
                    Minor = Minor - 10;
                    TickMajor();
                }
            }
        }
        public void TickMajor()
        {
            Major += 1;
        }

        public override string ToString()
            => $"{Major}.{Minor}.{Revision}{Patch}";
    }
}