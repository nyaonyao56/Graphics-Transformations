using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace asgn5v1
{
	/// <summary>
	/// Summary description for Transformer.
	/// </summary>
	public class Transformer : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
        //private bool GetNewData();

        // basic data for Transformer
		int numpts = 0;
		int numlines = 0;
		bool gooddata = false;		
		double[,] vertices;
		double[,] scrnpts;
		double[,] ctrans = new double[4,4];  //your main transformation matrix
        	string axis;
		private ImageList tbimages;
		private ToolBar toolBar1;
		private ToolBarButton transleftbtn;
		private ToolBarButton transrightbtn;
		private ToolBarButton transupbtn;
		private ToolBarButton transdownbtn;
		private ToolBarButton toolBarButton1;
		private ToolBarButton scaleupbtn;
		private ToolBarButton scaledownbtn;
		private ToolBarButton toolBarButton2;
		private ToolBarButton rotxby1btn;
		private ToolBarButton rotyby1btn;
		private ToolBarButton rotzby1btn;
		private ToolBarButton toolBarButton3;
		private ToolBarButton rotxbtn;
		private ToolBarButton rotybtn;
		private ToolBarButton rotzbtn;
		private ToolBarButton toolBarButton4;
		private ToolBarButton shearrightbtn;
		private ToolBarButton shearleftbtn;
		private ToolBarButton toolBarButton5;
		private ToolBarButton resetbtn;
		private ToolBarButton exitbtn;
        	private Timer timer;

        	int[,] lines;

		public Transformer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			Text = "COMP 4560:  Assignment 5 (A00871993) (Stanley Chu)";
			ResizeRedraw = true;
			BackColor = Color.Black;
			MenuItem miNewDat = new MenuItem("New &Data...",
				new EventHandler(MenuNewDataOnClick));
			MenuItem miExit = new MenuItem("E&xit", 
				new EventHandler(MenuFileExitOnClick));
			MenuItem miDash = new MenuItem("-");
			MenuItem miFile = new MenuItem("&File",
				new MenuItem[] {miNewDat, miDash, miExit});
			MenuItem miAbout = new MenuItem("&About",
				new EventHandler(MenuAboutOnClick));
			Menu = new MainMenu(new MenuItem[] {miFile, miAbout});

			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transformer));
            this.tbimages = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.transleftbtn = new System.Windows.Forms.ToolBarButton();
            this.transrightbtn = new System.Windows.Forms.ToolBarButton();
            this.transupbtn = new System.Windows.Forms.ToolBarButton();
            this.transdownbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.scaleupbtn = new System.Windows.Forms.ToolBarButton();
            this.scaledownbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.rotxby1btn = new System.Windows.Forms.ToolBarButton();
            this.rotyby1btn = new System.Windows.Forms.ToolBarButton();
            this.rotzby1btn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.rotxbtn = new System.Windows.Forms.ToolBarButton();
            this.rotybtn = new System.Windows.Forms.ToolBarButton();
            this.rotzbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.shearrightbtn = new System.Windows.Forms.ToolBarButton();
            this.shearleftbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.resetbtn = new System.Windows.Forms.ToolBarButton();
            this.exitbtn = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // tbimages
            // 
            this.tbimages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tbimages.ImageStream")));
            this.tbimages.TransparentColor = System.Drawing.Color.Transparent;
            this.tbimages.Images.SetKeyName(0, "");
            this.tbimages.Images.SetKeyName(1, "");
            this.tbimages.Images.SetKeyName(2, "");
            this.tbimages.Images.SetKeyName(3, "");
            this.tbimages.Images.SetKeyName(4, "");
            this.tbimages.Images.SetKeyName(5, "");
            this.tbimages.Images.SetKeyName(6, "");
            this.tbimages.Images.SetKeyName(7, "");
            this.tbimages.Images.SetKeyName(8, "");
            this.tbimages.Images.SetKeyName(9, "");
            this.tbimages.Images.SetKeyName(10, "");
            this.tbimages.Images.SetKeyName(11, "");
            this.tbimages.Images.SetKeyName(12, "");
            this.tbimages.Images.SetKeyName(13, "");
            this.tbimages.Images.SetKeyName(14, "");
            this.tbimages.Images.SetKeyName(15, "");
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.transleftbtn,
            this.transrightbtn,
            this.transupbtn,
            this.transdownbtn,
            this.toolBarButton1,
            this.scaleupbtn,
            this.scaledownbtn,
            this.toolBarButton2,
            this.rotxby1btn,
            this.rotyby1btn,
            this.rotzby1btn,
            this.toolBarButton3,
            this.rotxbtn,
            this.rotybtn,
            this.rotzbtn,
            this.toolBarButton4,
            this.shearrightbtn,
            this.shearleftbtn,
            this.toolBarButton5,
            this.resetbtn,
            this.exitbtn});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.tbimages;
            this.toolBar1.Location = new System.Drawing.Point(484, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(24, 306);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // transleftbtn
            // 
            this.transleftbtn.ImageIndex = 1;
            this.transleftbtn.Name = "transleftbtn";
            this.transleftbtn.ToolTipText = "translate left";
            // 
            // transrightbtn
            // 
            this.transrightbtn.ImageIndex = 0;
            this.transrightbtn.Name = "transrightbtn";
            this.transrightbtn.ToolTipText = "translate right";
            // 
            // transupbtn
            // 
            this.transupbtn.ImageIndex = 2;
            this.transupbtn.Name = "transupbtn";
            this.transupbtn.ToolTipText = "translate up";
            // 
            // transdownbtn
            // 
            this.transdownbtn.ImageIndex = 3;
            this.transdownbtn.Name = "transdownbtn";
            this.transdownbtn.ToolTipText = "translate down";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // scaleupbtn
            // 
            this.scaleupbtn.ImageIndex = 4;
            this.scaleupbtn.Name = "scaleupbtn";
            this.scaleupbtn.ToolTipText = "scale up";
            // 
            // scaledownbtn
            // 
            this.scaledownbtn.ImageIndex = 5;
            this.scaledownbtn.Name = "scaledownbtn";
            this.scaledownbtn.ToolTipText = "scale down";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // rotxby1btn
            // 
            this.rotxby1btn.ImageIndex = 6;
            this.rotxby1btn.Name = "rotxby1btn";
            this.rotxby1btn.ToolTipText = "rotate about x by 1";
            //
            // timer
            //
            this.timer = new Timer();
            this.timer.Interval = 1;
            this.timer.Tick += new EventHandler(TimerTick);
            //
            // rotyby1btn
            // 
            this.rotyby1btn.ImageIndex = 7;
            this.rotyby1btn.Name = "rotyby1btn";
            this.rotyby1btn.ToolTipText = "rotate about y by 1";
            // 
            // rotzby1btn
            // 
            this.rotzby1btn.ImageIndex = 8;
            this.rotzby1btn.Name = "rotzby1btn";
            this.rotzby1btn.ToolTipText = "rotate about z by 1";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // rotxbtn
            // 
            this.rotxbtn.ImageIndex = 9;
            this.rotxbtn.Name = "rotxbtn";
            this.rotxbtn.ToolTipText = "rotate about x continuously";
            // 
            // rotybtn
            // 
            this.rotybtn.ImageIndex = 10;
            this.rotybtn.Name = "rotybtn";
            this.rotybtn.ToolTipText = "rotate about y continuously";
            // 
            // rotzbtn
            // 
            this.rotzbtn.ImageIndex = 11;
            this.rotzbtn.Name = "rotzbtn";
            this.rotzbtn.ToolTipText = "rotate about z continuously";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // shearrightbtn
            // 
            this.shearrightbtn.ImageIndex = 12;
            this.shearrightbtn.Name = "shearrightbtn";
            this.shearrightbtn.ToolTipText = "shear right";
            // 
            // shearleftbtn
            // 
            this.shearleftbtn.ImageIndex = 13;
            this.shearleftbtn.Name = "shearleftbtn";
            this.shearleftbtn.ToolTipText = "shear left";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // resetbtn
            // 
            this.resetbtn.ImageIndex = 14;
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.ToolTipText = "restore the initial image";
            // 
            // exitbtn
            // 
            this.exitbtn.ImageIndex = 15;
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.ToolTipText = "exit the program";
            // 
            // Transformer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(508, 306);
            this.Controls.Add(this.toolBar1);
            this.Name = "Transformer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Transformer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Transformer());
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
            float height = this.Height / 2;
            float width = this.Width / 2;
			Graphics grfx = pea.Graphics;
         Pen pen = new Pen(Color.White, 3);
			double temp;
			int k;

            if (gooddata)
            {
                //create the screen coordinates:
                // scrnpts = vertices*ctrans

                for (int i = 0; i < numpts; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        temp = 0.0d;
                        for (k = 0; k < 4; k++)
                            temp += vertices[i, k] * ctrans[k, j];
                        scrnpts[i, j] = temp;
                    }
                }

                //now draw the lines

                for (int i = 0; i < numlines; i++)
                {
                    grfx.DrawLine(pen, (int)scrnpts[lines[i, 0], 0], (int)scrnpts[lines[i, 0], 1],
                        (int)scrnpts[lines[i, 1], 0], (int)scrnpts[lines[i, 1], 1]);
                }


            } // end of gooddata block	
		} // end of OnPaint

		void MenuNewDataOnClick(object obj, EventArgs ea)
		{
			//MessageBox.Show("New Data item clicked.");
			gooddata = GetNewData();
			RestoreInitialImage();		
		}

		void MenuFileExitOnClick(object obj, EventArgs ea)
		{
			Close();
		}

		void MenuAboutOnClick(object obj, EventArgs ea)
		{
			AboutDialogBox dlg = new AboutDialogBox();
			dlg.ShowDialog();
		}

        void Init() {
            double width = this.Width / 2;
            double height = this.Height / 2;
            double xAxis = vertices[0, 0];
            double yAxis = vertices[0, 1];
            double scaleFactor = height / (2 * yAxis);

            double[,] tnet = new double[4, 4];

            tnet = multiplyMatrix(translationMatrix(-xAxis, -yAxis, 0), reflectionMatrix("xz"));
            tnet = multiplyMatrix(tnet, scalingMatrix(scaleFactor, scaleFactor, scaleFactor));
            this.ctrans = multiplyMatrix(tnet, translationMatrix(width, height, 0));
        }

        double[,] translationMatrix(double x, double y, double z) {
            double[,] bottomRow = new double[4, 4];
            setIdentity(bottomRow, 4, 4);
            bottomRow[3, 0] = x;
            bottomRow[3, 1] = y;
            bottomRow[3, 2] = z;
            return bottomRow;
        }

        double[,] scalingMatrix(double x, double y, double z) {
            double[,] diagonalRow = new double[4, 4];
            setIdentity(diagonalRow, 4, 4);
            diagonalRow[0, 0] = 1.0d * x;
            diagonalRow[1, 1] = 1.0d * y;
            diagonalRow[2, 2] = 1.0d * z;
            return diagonalRow;
        }

        double[,] reflectionMatrix(string axis) {
            double[,] diagonalRow = new double[4, 4];
            setIdentity(diagonalRow, 4, 4);
            
            if(axis.Equals("xy")) {
                diagonalRow[2, 2] = -1.0d;
            }else if (axis.Equals("xz")) {
                diagonalRow[1, 1] = -1.0d;
            }else if (axis.Equals("yz")) {
                diagonalRow[0, 0] = -1.0d;
            }
            

            return diagonalRow;
        }

        double[,] rotationMatrix(string axis) {
            double cos = Math.Cos(0.05);
            double sin = Math.Sin(0.05);
            double[,] rotationRows = new double[4, 4];
            setIdentity(rotationRows, 4, 4);

            switch (axis) {
                case "x":
                    rotationRows[1, 1] = cos;
                    rotationRows[1, 2] = sin;
                    rotationRows[2, 1] = -sin;
                    rotationRows[2, 2] = cos;
                    break;
                case "y":
                    rotationRows[0, 0] = cos;
                    rotationRows[0, 2] = -sin;
                    rotationRows[2, 0] = sin;
                    rotationRows[2, 2] = cos;
                    break;
                case "z":
                    rotationRows[0, 0] = cos;
                    rotationRows[0, 1] = sin;
                    rotationRows[1, 0] = -sin;
                    rotationRows[1, 1] = cos;
                    break;
                default:
                    Console.WriteLine("dodo");
                    break;
            }

            return rotationRows;

        }

        double[,] shearMatrix(string direction) {
            double[,] shearRow = new double[4, 4];
            setIdentity(shearRow, 4, 4);
            if (direction.Equals("right")) {
                shearRow[1, 0] = -0.1d;
            }else if(direction.Equals("left")) {
                shearRow[1, 0] = 0.1d;
            }

            return shearRow;
        }

        double[,] multiplyMatrix(double[,] matrixOne, double[,] matrixTwo) {
            double temp;
            double[,] resultMatrix = new double[4, 4];
            for(int i = 0; i < 4; i++) {
                for(int x = 0; x < 4; x++) {
                    temp = 0.0d;
                    for(int j = 0; j < 4; j++) {
                        temp += matrixOne[i, j] * matrixTwo[j, x];
                        resultMatrix[i, x] = temp;
                    }
                }
            }
           
            return resultMatrix;
        }
		void RestoreInitialImage()
		{
			Invalidate();
            Init();
		} // end of RestoreInitialImage

		bool GetNewData()
		{
			string strinputfile,text;
			ArrayList coorddata = new ArrayList();
			ArrayList linesdata = new ArrayList();
			OpenFileDialog opendlg = new OpenFileDialog();
			opendlg.Title = "Choose File with Coordinates of Vertices";
			if (opendlg.ShowDialog() == DialogResult.OK)
			{
				strinputfile=opendlg.FileName;				
				FileInfo coordfile = new FileInfo(strinputfile);
				StreamReader reader = coordfile.OpenText();
				do
				{
					text = reader.ReadLine();
					if (text != null) coorddata.Add(text);
				} while (text != null);
				reader.Close();
				DecodeCoords(coorddata);
			}
			else
			{
				MessageBox.Show("***Failed to Open Coordinates File***");
				return false;
			}
            
			opendlg.Title = "Choose File with Data Specifying Lines";
			if (opendlg.ShowDialog() == DialogResult.OK)
			{
				strinputfile=opendlg.FileName;
				FileInfo linesfile = new FileInfo(strinputfile);
				StreamReader reader = linesfile.OpenText();
				do
				{
					text = reader.ReadLine();
					if (text != null) linesdata.Add(text);
				} while (text != null);
				reader.Close();
				DecodeLines(linesdata);
			}
			else
			{
				MessageBox.Show("***Failed to Open Line Data File***");
				return false;
			}
			scrnpts = new double[numpts,4];
			setIdentity(ctrans,4,4);  //initialize transformation matrix to identity
			return true;
		} // end of GetNewData

		void DecodeCoords(ArrayList coorddata)
		{
			//this may allocate slightly more rows that necessary
			vertices = new double[coorddata.Count,4];
			numpts = 0;
			string [] text = null;
			for (int i = 0; i < coorddata.Count; i++)
			{
				text = coorddata[i].ToString().Split(' ',',');
				vertices[numpts,0]=double.Parse(text[0]);
				if (vertices[numpts,0] < 0.0d) break;
				vertices[numpts,1]=double.Parse(text[1]);
				vertices[numpts,2]=double.Parse(text[2]);
				vertices[numpts,3] = 1.0d;
				numpts++;						
			}
			
		}// end of DecodeCoords

		void DecodeLines(ArrayList linesdata)
		{
			//this may allocate slightly more rows that necessary
			lines = new int[linesdata.Count,2];
			numlines = 0;
			string [] text = null;
			for (int i = 0; i < linesdata.Count; i++)
			{
				text = linesdata[i].ToString().Split(' ',',');
				lines[numlines,0]=int.Parse(text[0]);
				if (lines[numlines,0] < 0) break;
				lines[numlines,1]=int.Parse(text[1]);
				numlines++;						
			}
		} // end of DecodeLines

		void setIdentity(double[,] A,int nrow,int ncol)
		{
			for (int i = 0; i < nrow;i++) 
			{
				for (int j = 0; j < ncol; j++) A[i,j] = 0.0d;
				A[i,i] = 1.0d;
			}
		}// end of setIdentity
      

		private void Transformer_Load(object sender, System.EventArgs e)
		{
			
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
            timer.Stop();
			if (e.Button == transleftbtn)
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-75, 0, 0));
				Refresh();
			}
			if (e.Button == transrightbtn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(75, 0, 0));
                Refresh();
			}
			if (e.Button == transupbtn)
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(0, -35, 0));
                Refresh();
			}
			
			if(e.Button == transdownbtn)
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(0, 35, 0));
                Refresh();
			}
			if (e.Button == scaleupbtn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], 0));
                ctrans = multiplyMatrix(ctrans, scalingMatrix(1.1d, 1.1d, 1.1d));
                ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], 0));
				Refresh();
			}
			if (e.Button == scaledownbtn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                ctrans = multiplyMatrix(ctrans, scalingMatrix(0.9d, 0.9d, 0.9d));
                ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
				Refresh();
			}
			if (e.Button == rotxby1btn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                ctrans = multiplyMatrix(ctrans, rotationMatrix("x"));
                ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                Refresh();
			}
			if (e.Button == rotyby1btn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                ctrans = multiplyMatrix(ctrans, rotationMatrix("y"));
                ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                Refresh();
			}
			if (e.Button == rotzby1btn) 
			{
                ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                ctrans = multiplyMatrix(ctrans, rotationMatrix("z"));
                ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                Refresh();
			}

			if (e.Button == rotxbtn) 
			{
                axis = "x";
                timer.Start();
			}
			if (e.Button == rotybtn) 
			{
                axis = "y";
                timer.Start();
			}
			
			if (e.Button == rotzbtn) 
			{
                axis = "z";
                timer.Start();
			}

			if(e.Button == shearleftbtn)
			{
                double temp = ctrans[3, 1];
                ctrans[3, 1] = 0.0d;
                ctrans = multiplyMatrix(ctrans, shearMatrix("left"));
                ctrans[3, 1] = temp;
                Refresh();
			}

			if (e.Button == shearrightbtn) 
			{
                double temp = ctrans[3, 1];
                ctrans[3, 1] = 0.0d;
                ctrans = multiplyMatrix(ctrans, shearMatrix("right"));
                ctrans[3, 1] = temp;
                Refresh();
			}

			if (e.Button == resetbtn)
			{
				RestoreInitialImage();
			}

			if(e.Button == exitbtn) 
			{
				Close();
			}

		}

        public void TimerTick(object sender, EventArgs e) {
            switch (axis) {
                case "x":
                    ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                    ctrans = multiplyMatrix(ctrans, rotationMatrix("x"));
                    ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                    break;
                case "y":
                    ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                    ctrans = multiplyMatrix(ctrans, rotationMatrix("y"));
                    ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                    break;
                case "z":
                    ctrans = multiplyMatrix(ctrans, translationMatrix(-scrnpts[0, 0], -scrnpts[0, 1], -scrnpts[0, 2]));
                    ctrans = multiplyMatrix(ctrans, rotationMatrix("z"));
                    ctrans = multiplyMatrix(ctrans, translationMatrix(scrnpts[0, 0], scrnpts[0, 1], scrnpts[0, 2]));
                    break;
                default:
                    Console.WriteLine("dodo");
                    break;
            }
            Refresh();
        }

		
	}

	
}
