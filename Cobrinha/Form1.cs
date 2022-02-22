using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cobrinha
{
    public partial class Form1 : Form
    {
        List<ParteCobrinha> cobrinha = new List<ParteCobrinha>();
        Candy candy = new Candy();
        int DirecaoX = 0;
        int DirecaoY = 0;
        bool morreu = false;
        public Form1()
        {
            InitializeComponent();
            dgvConfig();
            inicia();
            var aTimer = new System.Timers.Timer();
            aTimer.Interval = 250;
            aTimer.Elapsed += GameLoop;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }

        public void updateCandy()
        {
            Random rnd = new Random();
            candy.Colun = rnd.Next(0, 15);
            candy.Row = rnd.Next(0, 15);

        }

        private void inicia()
        {
            morreu = false;
            cobrinha.Add(new ParteCobrinha());
            cobrinha[0].Colun = 9;
            cobrinha[0].Row = 8;
            DirecaoX = 0;
            DirecaoY = 1;

            for (int i = 1; i < 4; i++)
            {
                cobrinha.Add(new ParteCobrinha());
                cobrinha[i].Colun = 8;
                cobrinha[i].Row = 8;
            }
            desenhaCobrinha();
            updateCandy();
            
        }
        private void desenhaCobrinha()
        {

            for (int i = 0; i < dgv_Campo.Rows.Count; i++)
            {
                for (int r = 0; r < dgv_Campo.Rows.Count; r++)
                {
                    dgv_Campo.Rows[i].Cells[r].Style.BackColor = Color.White;
                }
            }
            for (int i = 0; i < cobrinha.Count; i++)
            {
                dgv_Campo.Rows[cobrinha[i].Row].Cells[cobrinha[i].Colun].Style.BackColor = Color.Black;

            }
            dgv_Campo.Rows[candy.Row].Cells[candy.Colun].Style.BackColor = Color.Green;
        }

        private void dgvConfig()
        {
            for(int i = 0; i < 16; i++)
            {
                dgv_Campo.Columns.Add("c" + i, "c" + i);
                dgv_Campo.Rows.Add();
                dgv_Campo.Columns["c" + i].Width = 20;
                dgv_Campo.Rows[i].Height = 20;
            }
            
        }

       
        private void GameLoop(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!morreu)
            {
                AndaCobrinha();
                GanhaScore();
                GameOver();
            }
            
        }

        private void GameOver()
        {
            for(int i = 1; i < cobrinha.Count; i++){
                if((cobrinha[0].Colun == cobrinha[i].Colun)&&(cobrinha[0].Row == cobrinha[i].Row))
                {
                    morreu = true;
                    MessageBox.Show("Você Perdeu");
                    cobrinha.Clear();
                    inicia();
                }
            }
        }

        private void GanhaScore()
        {
            if((cobrinha[0].Colun == candy.Colun)&&(cobrinha[0].Row == candy.Row))
            {
                cobrinha.Add(new ParteCobrinha());
                updateCandy();
            }
        }

        private void AndaCobrinha()
        {
            int[] cellAnterior = new int[cobrinha.Count];
            int[] rowAnterior = new int[cobrinha.Count];
            for (int i = 0; i < cobrinha.Count; i++)
            {
                cellAnterior[i] = cobrinha[i].Colun;
                rowAnterior[i] = cobrinha[i].Row;
            }
            if (DirecaoY == 1)
            {
                if(cobrinha[0].Colun >= 15)
                {
                    cobrinha[0].Colun = 0;
                }
                else
                {
                    cobrinha[0].Colun += 1;
                }
                
                for (int i = 1; i < cobrinha.Count; i++)
                {
                    cobrinha[i].Colun = cellAnterior[i - 1];
                    cobrinha[i].Row = rowAnterior[i - 1];
                }
            }
            else if (DirecaoX == -1)
            {
                if (cobrinha[0].Row >= 15)
                {
                    cobrinha[0].Row = 0;
                }
                else
                {
                    cobrinha[0].Row += 1;
                }
                
                for (int i = 1; i < cobrinha.Count; i++)
                {
                    cobrinha[i].Colun = cellAnterior[i - 1];
                    cobrinha[i].Row = rowAnterior[i - 1];
                }

            }
            else if (DirecaoY == -1)
            {
                if (cobrinha[0].Colun <= 0)
                {
                    cobrinha[0].Colun = 15;
                }
                else
                {
                    cobrinha[0].Colun -= 1;
                }
                
                for (int i = 1; i < cobrinha.Count; i++)
                {
                    cobrinha[i].Colun = cellAnterior[i - 1];
                    cobrinha[i].Row = rowAnterior[i - 1];
                }

            }
            else if (DirecaoX == 1)
            {
                if (cobrinha[0].Row <= 0)
                {
                    cobrinha[0].Row = 15;
                }
                else
                {
                    cobrinha[0].Row -= 1;
                }
                
                for (int i = 1; i < cobrinha.Count; i++)
                {
                    cobrinha[i].Colun = cellAnterior[i - 1];
                    cobrinha[i].Row = rowAnterior[i - 1];
                }
            }
            desenhaCobrinha();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                DirecaoY = 0;
                DirecaoX = 1;
                Console.WriteLine("w");
            }
            else if (e.KeyCode == Keys.S)
            {
                DirecaoY = 0;
                DirecaoX = -1;
            }
            else if (e.KeyCode == Keys.D)
            {
                DirecaoX = 0;
                DirecaoY = 1;
            }
            else if (e.KeyCode == Keys.A)
            {
                DirecaoX = 0;
                DirecaoY = -1;
            }
        }

        
    }
}
