namespace FDTDWPF.Models
{
    class Grid
    {
        public double[,,] Ex;
        public double[,,] Ey;
        public double[,,] Ez;
        public double[,,] Hz;
        public double[,,] Hy;
        public double[,,] Hx;
        private double[,,] Chxh;
        private double[,,] Chxe;
        private double[,,] Chyh;
        private double[,,] Chye;
        private double[,,] Chzh;
        private double[,,] Chze;
        private double[,,] Cexe;
        private double[,,] Cexh;
        private double[,,] Ceye;
        private double[,,] Ceyh;
        private double[,,] Ceze;
        private double[,,] Cezh;
        private int x, y, z;
        public Grid(int x, int y, int z)
        {
            Hx = new double[x, y - 1, z - 1];
            Hy = new double[x - 1, y, z - 1];
            Hz = new double[x - 1, y - 1, z];
            Ex = new double[x - 1, y, z];
            Ey = new double[x, y - 1, z];
            Ez = new double[x, y, z - 1];
            Chxh = new double[x, y - 1, z - 1];
            Chxe = new double[x, y - 1, z - 1];
            Chyh = new double[x - 1, y, z - 1];
            Chye = new double[x - 1, y, z - 1];
            Chzh = new double[x - 1, y - 1, z];
            Chze = new double[x - 1, y - 1, z];
            Cexe = new double[x - 1, y, z];
            Cexh = new double[x - 1, y, z];
            Ceye = new double[x, y - 1, z];
            Ceyh = new double[x, y - 1, z];
            Ceze = new double[x, y, z - 1];
            Cezh = new double[x, y, z - 1];
        }
        public void UpdateH()
        {
            // Update Hx
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Hx[i, j, k] = Chxh[i, j, k] * Hx[i, j, k] + Chxe[i, j, k] * ((Ey[i, j, k + 1] - Ey[i, j, k]) - (Ez[i, j + 1, k] - Ez[i, j, k]));
                    }
                }
            }
            // Update Hy
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Hy[i, j, k] = Chyh[i, j, k] * Hy[i, j, k] + Chye[i, j, k] * ((Ez[i + 1, j, k] - Ez[i, j, k]) - (Ex[i, j, k + 1] - Ex[i, j, k]));
                    }
                }
            }
            
            // Update Hz
            for (int i = 0; i < x - 1; ++i)
            { 
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 0; k < z; ++k)
                    {
                        Hz[i, j, k] = Chzh[i, j, k] * Hz[i, j, k] + Chze[i, j, k] * ((Ex[i, j + 1, k] - Ex[i, j, k]) - (Ey[i + 1, j, k] - Ey[i, j, k]));
                    }
                }
            }
        }
        public void UpdateE()
        {
            // Update Ex
            for (int i = 0; i < x - 1; ++i)
            {
                for (int j = 1; j < y - 1; ++j)
                {
                    for (int k = 1; k < z - 1; ++k)
                    {
                        Ex[i, j, k] = Cexe[i, j, k] * Ex[i, j, k] + Cexh[i, j, k] * ((Hz[i, j, k] - Hz[i, j - 1, k]) - (Hy[i, j, k] - Hy[i, j, k - 1]));
                    }
                }
            }
            //Update Ey
            for (int i = 1; i < x - 1; ++i)
            {
                for (int j = 0; j < y - 1; ++j)
                {
                    for (int k = 1; k < z - 1; ++k)
                    {
                        Ey[i, j, k] = Ceye[i, j, k] * Ey[i, j, k] + Ceyh[i, j, k] * ((Hx[i, j, k] - Hx[i, j, k - 1]) - (Hz[i, j, k] - Hz[i - 1, j, k]));
                    }
                }
            }

            //Update Ez
            for (int i = 1; i < x - 1; ++i)
            {
                for (int j = 1; j < y - 1; ++j)
                {
                    for (int k = 0; k < z - 1; ++k)
                    {
                        Ez[i, j, k] = Ceze[i, j, k] * Ez[i, j, k] + Cezh[i, j, k] * ((Hy[i, j, k] - Hy[i - 1, j, k]) - (Hx[i, j, k] - Hx[i, j - 1, k]));
                    }
                }
            }
        }
    }
}
