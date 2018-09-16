using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoManifoldRenderer
{
	public partial class Hammersley : Form
	{
		public Hammersley()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int n = (int)numericUpDown1.Value;
			uint[] yVals = hammersley(n);
			chart1.Series[0].Points.Clear();
			
			//add y vals to chart
			for(int i=0; i<yVals.Length; i++) {
				chart1.Series[0].Points.AddXY(i, yVals[i]);
			}
		}

		private uint[] hammersley(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("n must be positive", "n");
			}

			uint numGridLines = 1U << n;

			uint[] yValues = new uint[numGridLines];

			for (uint i = 0; i < numGridLines; i++)
			{
				yValues[i] = reverseBits(i, n);
			}

			return yValues;
		}

		private uint reverseBits(uint val, int numBits)
		{
			// the reveresed number
			uint reversed = 0;
			// for each bit
			for (int i = 0; i < numBits; i++)
			{
				// get the value of the right-most bit
				uint rightBit = val & 1U;
				// shift all bits to the right on the source number
				val = val >> 1;
				// shift all bits to the left on the reversed number
				reversed = reversed << 1;
				// set the right-most bit on the reversed number
				reversed = reversed | rightBit;
			}
			return reversed;
		}
	}
}
