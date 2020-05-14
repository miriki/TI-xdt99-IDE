using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TI_xdt99_IDE
{

    public partial class Form1 : Form
    {

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   variables, conctants etc.                                    ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        private static readonly string[] keywords =
        {
            "<libpath>", "<lstfile>", "<srcfile>", "<prjname>",
            "<tisrcfile>", "<tiobjfile>", "<tilstfile>", "<tiimgfile>"
        };

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   constructor / destructor                                     ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        public Form1()
        {
            InitializeComponent();
        }

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   private helper                                               ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        // replace <library> <list> <source> <project>
        // <tisource> <tiobject> <tilist> <tiimage>
        private string replacePatterns(string raw)
        {
            string Result;
            int n;
            string[] keyvalues = { };
            string s;
            int f;

            // Console.WriteLine("replacePatterns: '" + raw + "'");

            Result = raw;

            n = keywords.Length;
            Array.Resize(ref keyvalues, n);
            for (int i = 0; i < n; i++)
            {
                if (i == 0) //libpath
                {
                    s = txt_Xdt_Base.Text + txt_Xdt_Library.Text;
                }
                else if (i == 1) //lstfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_List.Text;
                }
                else if (i == 2) //srcfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_Source.Text;
                }
                else if (i == 3) //prjname
                {
                    s = txt_Project.Text;
                }
                else if (i == 4) //tisrcfile
                {
                    s = txt_Source.Text + txt_ExtEmu_Source.Text;
                }
                else if (i == 5) //tiobjfile
                {
                    s = txt_Source.Text + txt_ExtEmu_Object.Text;
                }
                else if (i == 6) //tilstfile
                {
                    s = txt_Source.Text + txt_ExtEmu_List.Text;
                }
                else if (i == 7) //tiimgfile
                {
                    s = txt_Source.Text + txt_ExtEmu_Image.Text;
                }
                else
                {
                    // ...
                    s = "";
                }
                keyvalues[i] = s;
            }

            for (int i = 0; i < n; i++)
            {
                f = Result.IndexOf(keywords[i]);
                if (f >= 0)
                {
                    Result = Result.Substring(0, f) + keyvalues[i] + Result.Substring(f + keywords[i].Length);
                }
            }

            // Console.WriteLine("replacePatterns return: '" + Result + "'");

            return Result;

        }

        private static readonly string cmd = "C:\\WINDOWS\\system32\\cmd.exe";
        private static readonly string cmd1 = "cmd";
        private static readonly string pyt = "C:\\Python27\\python.exe";
        private static readonly string pyt1 = "python";
        private bool runExternal( string bin, string opt, string wrk, bool end )
        {
            bool Result;
            int runmod = 0;
            int n;
            string ext;
            string stdout="";
            string stderr="";

            Result = false;

            Console.WriteLine("runExternal: bin [" + bin + "], opt [" + opt + "], wrk [" + wrk + "]");

            n = bin.Length-1;
            while ((n>=0) & (bin.Substring(n,1)!="."))
            {
                n = n - 1;
            }
            ext = bin.Substring(n+1);
            if (ext=="exe")
            {
                runmod = 30;
            }
            else if (ext=="py")
            {
                runmod = 21;
            }
            Console.WriteLine("  trying runmod: " + runmod.ToString());

            ProcessStartInfo psi = new ProcessStartInfo();
            if (runmod == 10) // ok
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd;
                psi.Arguments = "/k " + pyt + " " + bin + " " + opt;
                // c:\win\cmd.exe   -   /k c:\prg\python.exe e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 11) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd1;
                psi.Arguments = "/k " + pyt1 + " " + bin + " " + opt;
                // cmd   -   /k python e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 20) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt;
                psi.Arguments = bin + " " + opt;
                // c:\prg\python.exe   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 21) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt1;
                psi.Arguments = bin + " " + opt;
                // python   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 30) // error: "System.ComponentModel.Win32Exception" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = bin;
                psi.Arguments = opt;
                // e:\pyt\script.py   -   opt1 opt2 ...
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            // psi.RedirectStandardInput = false;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Console.WriteLine("  psi Filename [" + psi.FileName + "], Arguments [" + psi.Arguments + "]");
                txt_Command_Stack.Text = txt_Command_Stack.Text + psi.FileName + " " + psi.Arguments + "\r\n";
                using (Process run = Process.Start(psi))
                {
                    if (end)
                    {
                        stdout = run.StandardOutput.ReadToEnd();
                        stderr = run.StandardError.ReadToEnd();
                        run.WaitForExit();
                    }
                }
                Console.WriteLine("StdOut: "+stdout);
                if (stdout != "")
                {
                    txt_Standard_Output.Text = txt_Standard_Output.Text + stdout + "\r\n";
                }
                Console.WriteLine("StdErr: "+stderr);
                if (stderr != "")
                {
                    txt_Error_Output.Text = txt_Error_Output.Text + stderr + "\r\n";
                }
            }
            catch
            {
                // ...
            }

            return Result;

        }

        private List<string> getProjectList()
        {
            List<string> Result;
            string s;
            string[] d;
            Result = new List<string>();
            s = txt_Xdt_Base.Text + txt_Xdt_Projects.Text;
            if (s.Substring(s.Length) != "\\")
            {
                s = s + "\\";
            }
            d = Directory.GetDirectories(s, "*", SearchOption.TopDirectoryOnly);
            for (int i=0; i<d.Length; i++)
            {
                Result.Add(d[i].Substring(s.Length));
            }
            return Result;
        }

        private List<string> getSourceList()
        {
            List<string> Result;
            string s;
            string[] f;
            Result = new List<string>();
            s = txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text;
            if ( s.Substring (s.Length) != "\\")
            {
                s = s + "\\";
            }
            f = Directory.GetFiles(s, "*." + txt_ExtWin_Source.Text, SearchOption.TopDirectoryOnly);
            for (int i = 0; i < f.Length; i++)
            {
                Result.Add(f[i].Substring(s.Length, f[i].Length - s.Length - txt_ExtWin_Source.Text.Length - 1));
            }
            return Result;
        }

        private bool refreshProjectList()
        {
            bool Result;
            List<string> l;
            Result = false;
            lst_Projects.DataSource = null;
            l = getProjectList();
            lst_Projects.DataSource = l;
            return Result;
        }

        private bool refreshSourceList()
        {
            bool Result;
            List<string> l;
            Result = false;
            lst_Sourcefiles.DataSource = null;
            l = getSourceList();
            lst_Sourcefiles.DataSource = l;
            return Result;
        }

        // start external editor with source file according to lst_sourcefiles
        private bool startEditor()
        {
            bool Result;
            string wrk;
            string bin;
            string opt;
            Result = false;
            bin = replacePatterns(txt_Editor_Binary.Text);
            opt = replacePatterns(txt_Editor_Options.Text);
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            Result = runExternal(bin, opt, wrk,false);
            return Result;
        }

        // start assembler with source file according to lst_sourcefiles
        // loop through all sources if chk_assemble_all is set
        // generate object file if chk_assemble_object is set
        // generate image file if chk_assemble_image is set
        // generate mess rpk if chk_assemble_mess is set
        private bool startAssembler()
        {
            bool Result;
            string wrk;
            string bin;
            string opt;
            List<string> src;
            string sav;
            Result = false;
            src = new List<string>();
            txt_Standard_Output.Text = "";
            txt_Error_Output.Text = "";
            if (chk_Assembler_all.Checked)
            {
                foreach (string s in lst_Sourcefiles.Items)
                {
                    src.Add(s);
                }
            }
            else
            {
                src.Add(txt_Source.Text);
            }
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Assembler.Text);
            sav = txt_Source.Text;
            foreach (string s in src)
            {
                txt_Source.Text = s;
                if (chk_Assembler_Object.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Object.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Assembler_Image.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Image.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Assembler_Rpk.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Rpk.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
            }
            txt_Source.Text = sav;
            if (txt_Standard_Output.Text != "")
            {
                MessageBox.Show("See results...");
                tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }
            return Result;
        }

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   lifetime cycle events                                        ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        // +--------------------------------------------------------------------+
        // | buttons                                                            |
        // +--------------------------------------------------------------------+

        private void btn_Editor_Click(object sender, EventArgs e)
        {

            startEditor();

        }

        private void btn_Assembler_Click(object sender, EventArgs e)
        {
            startAssembler();
        }

        // create disk image with the disk manager tool
        // copy source file to disk if chk_copy_source is set
        // copy list file to disk if chk_copy_list is set
        // copy object file to disk if chk_copy_object is set
        // copy image file to disk if chk_copy_image is set
        // copy all above to disk if chk_copy_all is set
        // create / copy catalog tool to disk if chk_copy_catalog is set
        // create / copy autostart tool if chk_copy_autostart is set
        private void btn_DiskManager_Click(object sender, EventArgs e)
        {
            // ...
        }

        // start the emulator
        // use cartridge editass, minimem or exbasic acc. to radiogroup grp_emu_cart
        // using püt_emu_editass, opt_emu_minimem and opt_emu_exbasic
        private void btn_Emulator_Click(object sender, EventArgs e)
        {
            // ...
        }

        // create new project sub folder
        private void btn_New_Project_Click(object sender, EventArgs e)
        {
            // ...
        }

        // create new source file
        // use an optional template file, create empty file otherwise
        private void btn_New_Source_Click(object sender, EventArgs e)
        {
            // ...
        }

        // +--------------------------------------------------------------------+
        // | listboxes                                                          |
        // +--------------------------------------------------------------------+

        // update lst_sourcefiles acc. to lst_projects subdir
        // set txt_project to selected project
        private void lst_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string s;
            i = lst_Projects.SelectedIndex;
            if (i >= 0)
            {
                s = lst_Projects.SelectedItem.ToString();
                txt_Project.Text = s;
            }
            refreshSourceList();
        }

        // set txt_source to selected source file
        // show details about selected file in project subdir
        private void lst_Sourcefiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string s;
            i = lst_Sourcefiles.SelectedIndex;
            if ( i >= 0)
            {
                s = lst_Sourcefiles.SelectedItem.ToString();
                txt_Source.Text = s;
            }
        }

        // start editor with actual source file
        private void lst_Sourcefiles_DoubleClick(object sender, EventArgs e)
        {
            int i;
            i = lst_Sourcefiles.SelectedIndex;
            if (i >= 0)
            {
                startEditor();
            }
        }

        // +--------------------------------------------------------------------+
        // | other                                                              |
        // +--------------------------------------------------------------------+

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            refreshProjectList();
        }

    }

}
