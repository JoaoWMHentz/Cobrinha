

namespace Cobrinha
{
    class Candy
    {
            public Candy() { }
            public int Colun { get; set; }
            public int Row { get; set; }

            public Candy(int Colun, int Row)
            {
                this.Row = Row;
                this.Colun = Colun;
            }
        }
}
