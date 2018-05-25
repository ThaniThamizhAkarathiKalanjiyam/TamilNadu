using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

namespace AnalogClockControl
{
	/// <summary>
	/// Control name: Analog Clock Control
	/// Description: A customizable and resizable clock control
	/// Developed by: Syed Mehroz Alam
	/// Email: smehrozalam@yahoo.com
	/// URL: Programming Home "http://www.geocities.com/smehrozalam/"
	/// </summary>
	public class AnalogClock : System.Windows.Forms.UserControl
	{
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		const float PI=3.141592654F;

		DateTime dateTime;

		float fRadius;
		float fCenterX;
		float fCenterY;
		float fCenterCircleRadius;

		float fHourLength;
		float fMinLength;
		float fSecLength;

		float fHourThickness;
		float fMinThickness;
		float fSecThickness;

		bool bDraw5MinuteTicks=true;
		bool bDraw1MinuteTicks=true;
		float fTicksThickness=1;

		Color hrColor=Color.DarkMagenta ;
		Color minColor=Color.Green ;
		Color secColor=Color.Red ;
		Color circleColor=Color.Red;
		Color ticksColor=Color.Black;

        private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public AnalogClock()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AnalogClock
            // 
            this.Name = "AnalogClock";
            this.Load += new System.EventHandler(this.AnalogClock_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);
            this.Resize += new System.EventHandler(this.AnalogClock_Resize);
            this.ResumeLayout(false);

		}
		#endregion

		private void AnalogClock_Load(object sender, System.EventArgs e)
		{
			dateTime=DateTime.Now;
			this.AnalogClock_Resize(sender,e);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.dateTime=DateTime.Now;
			this.Refresh();
		}

		public void Start()
		{
			timer1.Enabled=true;
			this.Refresh();
		}

		public void Stop()
		{
			timer1.Enabled=false;
		}

		private void DrawLine(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen( color, fThickness ),
				fCenterX - (float)(fLength/9*System.Math.Sin(fRadians)), 
				fCenterY + (float)(fLength/9*System.Math.Cos(fRadians)), 
				fCenterX + (float)(fLength*System.Math.Sin(fRadians)), 
				fCenterY - (float)(fLength*System.Math.Cos(fRadians)));
		}

		private void DrawPolygon(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
		{

			PointF A=new PointF( (float)(fCenterX+ fThickness*2*System.Math.Sin(fRadians+PI/2)), 
				(float)(fCenterY - fThickness*2*System.Math.Cos(fRadians+PI/2)) );
			PointF B=new PointF( (float)(fCenterX+ fThickness*2*System.Math.Sin(fRadians-PI/2)),
				(float)(fCenterY - fThickness*2*System.Math.Cos(fRadians-PI/2)) );
			PointF C=new PointF( (float)(fCenterX+ fLength*System.Math.Sin(fRadians)), 
				(float) (fCenterY - fLength*System.Math.Cos(fRadians)) );
			PointF D=new PointF( (float)(fCenterX- fThickness*4*System.Math.Sin(fRadians)), 
				(float)(fCenterY + fThickness*4*System.Math.Cos(fRadians) ));
			PointF[] points={A,D,B,C};
			e.Graphics.FillPolygon( new SolidBrush(color), points );
		}

		private void AnalogClock_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			float fRadHr=(dateTime.Hour%12+dateTime.Minute/60F) *30*PI/180;
			float fRadMin=(dateTime.Minute)*6*PI/180;
			float fRadSec=(dateTime.Second)*6*PI/180;

			DrawPolygon(this.fHourThickness, this.fHourLength, hrColor, fRadHr, e);
			DrawPolygon(this.fMinThickness, this.fMinLength, minColor, fRadMin, e);
			DrawLine(this.fSecThickness, this.fSecLength, secColor, fRadSec, e);


			for(int i=0;i<60;i++)
			{
				if ( this.bDraw5MinuteTicks==true && i%5==0 ) // Draw 5 minute ticks
				{
					e.Graphics.DrawLine( new Pen( ticksColor, fTicksThickness ),
						fCenterX + (float)( this.fRadius/1.50F*System.Math.Sin(i*6*PI/180) ) , 
						fCenterY - (float)( this.fRadius/1.50F*System.Math.Cos(i*6*PI/180) ),
						fCenterX + (float)( this.fRadius/1.65F*System.Math.Sin(i*6*PI/180) ), 
						fCenterY - (float)( this.fRadius/1.65F*System.Math.Cos(i*6*PI/180)) );
				}
				else if ( this.bDraw1MinuteTicks==true ) // draw 1 minute ticks
				{
					e.Graphics.DrawLine( new Pen( ticksColor, fTicksThickness ),
						fCenterX + (float) ( this.fRadius/1.50F*System.Math.Sin(i*6*PI/180) ), 
						fCenterY - (float) ( this.fRadius/1.50F*System.Math.Cos(i*6*PI/180) ),
						fCenterX + (float) ( this.fRadius/1.55F*System.Math.Sin(i*6*PI/180) ), 
						fCenterY - (float) ( this.fRadius/1.55F*System.Math.Cos(i*6*PI/180) ) );
				}
			}

			//draw circle at center
			e.Graphics.FillEllipse( new SolidBrush( circleColor ), fCenterX-fCenterCircleRadius/2, fCenterY-fCenterCircleRadius/2, fCenterCircleRadius, fCenterCircleRadius);
		}

		private void AnalogClock_Resize(object sender, System.EventArgs e)
		{
			this.Width = this.Height;
			this.fRadius = this.Height/2;
			this.fCenterX = this.ClientSize.Width/2;
			this.fCenterY = this.ClientSize.Height/2;
			this.fHourLength = (float)this.Height/3/1.65F;
			this.fMinLength = (float)this.Height/3/1.20F;
			this.fSecLength = (float)this.Height/3/1.15F;
			this.fHourThickness = (float)this.Height/100;
			this.fMinThickness = (float)this.Height/150;
			this.fSecThickness = (float)this.Height/200;
			this.fCenterCircleRadius = this.Height/50;
			this.Refresh();
		}
	
		public Color HourHandColor
		{
			get { return this.hrColor; }
			set { this.hrColor=value; }
		}

		public Color MinuteHandColor
		{
			get { return this.minColor; }
			set { this.minColor=value; }
		}

		public Color SecondHandColor
		{
			get { return this.secColor; }
			set { this.secColor=value;
				  this.circleColor=value; }
		}

		public Color TicksColor
		{
			get { return this.ticksColor; }
			set { this.ticksColor=value; }
		}

		public bool Draw1MinuteTicks
		{
			get { return this.bDraw1MinuteTicks; }
			set { this.bDraw1MinuteTicks=value; }
		}

		public bool Draw5MinuteTicks
		{
			get { return this.bDraw5MinuteTicks; }
			set { this.bDraw5MinuteTicks=value; }
		}

	}
}
