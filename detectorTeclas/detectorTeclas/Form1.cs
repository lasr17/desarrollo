using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace detectorTeclas
{
    public partial class Form1 : Form
    {
        List<globalKeyboardHook> detectores = new List<globalKeyboardHook>();
        Boolean detectando = false;
        Boolean pulsaTecla1 = false;
        Boolean pulsaTecla2 = false;
        Boolean pulsaTecla3 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (detectando)
            {
                detectando = false;
                label1.Text = "Deje de Escuchar";
                pulsaTecla1 = false;
                pulsaTecla2 = false;
                pulsaTecla3 = false;
            }
            else
            {
                List<Keys> combinacion = new List<Keys>();
                combinacion.Add(Keys.LControlKey);
                combinacion.Add(Keys.S);
                detectarCombinacion(combinacion, 2);
            }
        }

        private void detectarCombinacion(List<Keys> teclas, int numTeclas)
        {
            switch (numTeclas)
            {
                case 1:
                    iniciarDetector1(teclas[0]);
                    break;
                case 2:
                    iniciarDetector1(teclas[0]);
                    iniciarDetector2(teclas[1]);
                    break;
                case 3:
                    iniciarDetector1(teclas[0]);
                    iniciarDetector2(teclas[1]);
                    iniciarDetector3(teclas[2]);
                    break;
            }
            detectando = true;
            detectar(numTeclas);
        }
        
        private void iniciarDetector1(Keys tecla)
        {
            var detector1 = new globalKeyboardHook();
            detectores.Add(detector1);
            detector1.HookedKeys.Add(tecla);
            detector1.KeyUp += new KeyEventHandler(detector1_KeyUp);
        }

        private void iniciarDetector2(Keys tecla)
        {
            var detector2 = new globalKeyboardHook();
            detectores.Add(detector2);
            detector2.HookedKeys.Add(tecla);
            detector2.KeyUp += new KeyEventHandler(detector2_KeyUp);
        }

        private void iniciarDetector3(Keys tecla)
        {
            var detector3 = new globalKeyboardHook();
            detectores.Add(detector3);
            detector3.HookedKeys.Add(tecla);
            detector3.KeyUp += new KeyEventHandler(detector3_KeyUp);
        }

        private void detector1_KeyUp(object sender, KeyEventArgs e)
        {
            pulsaTecla1 = true;
        }

        private void detector2_KeyUp(object sender, KeyEventArgs e)
        {
            pulsaTecla2 = true;
        }

        private void detector3_KeyUp(object sender, KeyEventArgs e)
        {
            pulsaTecla3 = true;
        }

        private async void detectar(int numTeclas)
        {
            while (detectando)
            {
                Boolean combinacion = false;
                switch (numTeclas)
                {
                    case 1:
                        combinacion = pulsaTecla1;
                        break;
                    case 2:
                        combinacion = pulsaTecla1 & pulsaTecla2;
                        break;
                    case 3:
                        combinacion = pulsaTecla1 & pulsaTecla2 & pulsaTecla3;
                        break;
                }
                if (combinacion)
                {
                    label1.Text = "Aplastada";
                }
                else
                {
                    label1.Text = "Pendiente";
                }
                await Task.Delay(1);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
