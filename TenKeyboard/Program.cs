using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NumpadToAlpha {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            KeyboardHook.SetHook();
            Application.Run(new MainForm()); // フォームを起動
            KeyboardHook.Unhook();
        }

        public static void UpdateStatus(string vowel, int step, string status) {
            // フォームのラベルを更新するための処理をここに追加
            if (Application.OpenForms.Count > 0) {
                var mainForm = Application.OpenForms[0] as MainForm;
                if (mainForm != null) {
                    mainForm.Invoke(new Action(() => {
                        mainForm.labelStatus.Text = status;
                    }));
                }
            }
            MainForm.UpdateLabels(vowel, step);
        }
        public static void UpdateOnOff(bool enabled) {
            if (Application.OpenForms.Count > 0) {
                var mainForm = Application.OpenForms[0] as MainForm;
                if (mainForm != null) {
                    mainForm.Invoke(new Action(() => {
                        if (enabled) {
                            mainForm.onoff.Text = "On";
                            mainForm.onoff.ForeColor = System.Drawing.Color.OrangeRed;
                        } else {
                            mainForm.onoff.Text = "Off";
                            mainForm.onoff.ForeColor = System.Drawing.Color.DarkBlue;
                        }
                    }));
                }
            }

        }

        public static void UpdateLabels(string vowel, int step) {
            // フォームのラベルを更新するための処理をここに追加
            if (Application.OpenForms.Count > 0) {
                var mainForm = Application.OpenForms[0] as MainForm;
                if (mainForm != null) {
                    mainForm.Invoke(new Action(() => {
                        if (step == 0) {
                            mainForm.label_a.Text = "あ";
                            mainForm.label_k.Text = "か";
                            mainForm.label_s.Text = "さ";
                            mainForm.label_t.Text = "た";
                            mainForm.label_n.Text = "な";
                            mainForm.label_h.Text = "は";
                            mainForm.label_m.Text = "ま";
                            mainForm.label_y.Text = "や";
                            mainForm.label_r.Text = "ら";
                            mainForm.label_w.Text = "わ";
                        } else if (step == 1) {
                            switch (vowel) {
                                case "あ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "う";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "い";
                                    mainForm.label_n.Text = "あ";
                                    mainForm.label_h.Text = "え";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "お";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "小字";
                                    break;
                                case "か":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "く";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "き";
                                    mainForm.label_n.Text = "か";
                                    mainForm.label_h.Text = "け";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "こ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "濁点";
                                    break;
                                case "さ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "す";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "し";
                                    mainForm.label_n.Text = "さ";
                                    mainForm.label_h.Text = "せ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "そ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "濁点";
                                    break;
                                case "た":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "つ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ち";
                                    mainForm.label_n.Text = "た";
                                    mainForm.label_h.Text = "て";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "と";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "濁点";
                                    break;
                                case "な":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ぬ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "に";
                                    mainForm.label_n.Text = "な";
                                    mainForm.label_h.Text = "ね";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "の";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "";
                                    break;
                                case "は":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ふ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ひ";
                                    mainForm.label_n.Text = "は";
                                    mainForm.label_h.Text = "へ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ほ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "濁点";
                                    break;
                                case "ま":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "む";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "み";
                                    mainForm.label_n.Text = "ま";
                                    mainForm.label_h.Text = "め";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "も";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "";
                                    break;
                                case "や":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ゆ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "「";
                                    mainForm.label_n.Text = "や";
                                    mainForm.label_h.Text = "」";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "よ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "小字";
                                    break;
                                case "ら":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "る";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "り";
                                    mainForm.label_n.Text = "ら";
                                    mainForm.label_h.Text = "れ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ろ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "";
                                    break;
                                case "わ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ん";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "を";
                                    mainForm.label_n.Text = "わ";
                                    mainForm.label_h.Text = "ー";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "記号";
                                    break;
                            }
                        } else if (step == 2) {
                            switch (vowel) {
                                case "あ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ぅ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ぃ";
                                    mainForm.label_n.Text = "ぁ";
                                    mainForm.label_h.Text = "ぇ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ぉ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                                case "か":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ぐ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ぎ";
                                    mainForm.label_n.Text = "が";
                                    mainForm.label_h.Text = "げ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ご";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                                case "さ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ず";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "じ";
                                    mainForm.label_n.Text = "ざ";
                                    mainForm.label_h.Text = "ぜ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ぞ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                                case "た":
                                    mainForm.label_a.Text = "っ";
                                    mainForm.label_k.Text = "づ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ぢ";
                                    mainForm.label_n.Text = "だ";
                                    mainForm.label_h.Text = "で";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ど";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                                case "は":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ぶ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "び";
                                    mainForm.label_n.Text = "ば";
                                    mainForm.label_h.Text = "べ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ぼ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "半濁";
                                    break;
                                case "や":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ゅ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "";
                                    mainForm.label_n.Text = "ゃ";
                                    mainForm.label_h.Text = "";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ょ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                                case "わ":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "。";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "、";
                                    mainForm.label_n.Text = "ゎ";
                                    mainForm.label_h.Text = "！";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "？";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                            }
                        } else if (step == 3) {
                            switch (vowel) {
                                case "は":
                                    mainForm.label_a.Text = "";
                                    mainForm.label_k.Text = "ぷ";
                                    mainForm.label_s.Text = "";
                                    mainForm.label_t.Text = "ぴ";
                                    mainForm.label_n.Text = "ぱ";
                                    mainForm.label_h.Text = "ぺ";
                                    mainForm.label_m.Text = "";
                                    mainForm.label_y.Text = "ぽ";
                                    mainForm.label_r.Text = "";
                                    mainForm.label_w.Text = "戻る";
                                    break;
                            }
                        }

                    }));
                }
            }
        }

        private void InitializeComponent() {
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.onoff = new System.Windows.Forms.Label();
            this.panel_dot = new System.Windows.Forms.Panel();
            this.label_dot = new System.Windows.Forms.Label();
            this.panel_enter = new System.Windows.Forms.Panel();
            this.label_enter = new System.Windows.Forms.Label();
            this.panel_space = new System.Windows.Forms.Panel();
            this.label_space = new System.Windows.Forms.Label();
            this.panel_w = new System.Windows.Forms.Panel();
            this.label_w = new System.Windows.Forms.Label();
            this.panel_r = new System.Windows.Forms.Panel();
            this.label_r = new System.Windows.Forms.Label();
            this.panel_s = new System.Windows.Forms.Panel();
            this.label_s = new System.Windows.Forms.Label();
            this.panel_backspace = new System.Windows.Forms.Panel();
            this.label_backspace = new System.Windows.Forms.Label();
            this.panel_y = new System.Windows.Forms.Panel();
            this.label_y = new System.Windows.Forms.Label();
            this.panel_k = new System.Windows.Forms.Panel();
            this.label_k = new System.Windows.Forms.Label();
            this.panel_h = new System.Windows.Forms.Panel();
            this.label_h = new System.Windows.Forms.Label();
            this.panel_m = new System.Windows.Forms.Panel();
            this.label_m = new System.Windows.Forms.Label();
            this.panel_delete = new System.Windows.Forms.Panel();
            this.label_delete = new System.Windows.Forms.Label();
            this.panel1_n = new System.Windows.Forms.Panel();
            this.label_n = new System.Windows.Forms.Label();
            this.panel_a = new System.Windows.Forms.Panel();
            this.label_a = new System.Windows.Forms.Label();
            this.panel1_t = new System.Windows.Forms.Panel();
            this.label_t = new System.Windows.Forms.Label();
            this.panel_onoff = new System.Windows.Forms.Panel();
            this.label_onoff = new System.Windows.Forms.Label();
            this.panel_numlock = new System.Windows.Forms.Panel();
            this.label_numlock = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_dot.SuspendLayout();
            this.panel_enter.SuspendLayout();
            this.panel_space.SuspendLayout();
            this.panel_w.SuspendLayout();
            this.panel_r.SuspendLayout();
            this.panel_s.SuspendLayout();
            this.panel_backspace.SuspendLayout();
            this.panel_y.SuspendLayout();
            this.panel_k.SuspendLayout();
            this.panel_h.SuspendLayout();
            this.panel_m.SuspendLayout();
            this.panel_delete.SuspendLayout();
            this.panel1_n.SuspendLayout();
            this.panel_a.SuspendLayout();
            this.panel1_t.SuspendLayout();
            this.panel_onoff.SuspendLayout();
            this.panel_numlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("美咲ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStatus.Location = new System.Drawing.Point(12, 38);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(69, 19);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Step 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.onoff);
            this.panel1.Controls.Add(this.panel_dot);
            this.panel1.Controls.Add(this.panel_enter);
            this.panel1.Controls.Add(this.panel_space);
            this.panel1.Controls.Add(this.panel_w);
            this.panel1.Controls.Add(this.panel_r);
            this.panel1.Controls.Add(this.panel_s);
            this.panel1.Controls.Add(this.panel_backspace);
            this.panel1.Controls.Add(this.panel_y);
            this.panel1.Controls.Add(this.panel_k);
            this.panel1.Controls.Add(this.panel_h);
            this.panel1.Controls.Add(this.panel_m);
            this.panel1.Controls.Add(this.panel_delete);
            this.panel1.Controls.Add(this.panel1_n);
            this.panel1.Controls.Add(this.panel_a);
            this.panel1.Controls.Add(this.panel1_t);
            this.panel1.Controls.Add(this.panel_onoff);
            this.panel1.Controls.Add(this.panel_numlock);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 349);
            this.panel1.TabIndex = 1;
            // 
            // onoff
            // 
            this.onoff.AutoSize = true;
            this.onoff.Font = new System.Drawing.Font("美咲ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.onoff.ForeColor = System.Drawing.Color.OrangeRed;
            this.onoff.Location = new System.Drawing.Point(200, 36);
            this.onoff.Name = "onoff";
            this.onoff.Size = new System.Drawing.Size(32, 21);
            this.onoff.TabIndex = 19;
            this.onoff.Text = "On";
            // 
            // panel_dot
            // 
            this.panel_dot.BackColor = System.Drawing.Color.White;
            this.panel_dot.Controls.Add(this.label_dot);
            this.panel_dot.Location = new System.Drawing.Point(124, 284);
            this.panel_dot.Name = "panel_dot";
            this.panel_dot.Size = new System.Drawing.Size(50, 50);
            this.panel_dot.TabIndex = 18;
            // 
            // label_dot
            // 
            this.label_dot.AutoSize = true;
            this.label_dot.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_dot.Location = new System.Drawing.Point(15, 19);
            this.label_dot.Name = "label_dot";
            this.label_dot.Size = new System.Drawing.Size(15, 16);
            this.label_dot.TabIndex = 1;
            this.label_dot.Text = ".";
            // 
            // panel_enter
            // 
            this.panel_enter.BackColor = System.Drawing.Color.White;
            this.panel_enter.Controls.Add(this.label_enter);
            this.panel_enter.Location = new System.Drawing.Point(180, 228);
            this.panel_enter.Name = "panel_enter";
            this.panel_enter.Size = new System.Drawing.Size(50, 106);
            this.panel_enter.TabIndex = 13;
            // 
            // label_enter
            // 
            this.label_enter.AutoSize = true;
            this.label_enter.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_enter.Location = new System.Drawing.Point(3, 46);
            this.label_enter.Name = "label_enter";
            this.label_enter.Size = new System.Drawing.Size(47, 16);
            this.label_enter.TabIndex = 1;
            this.label_enter.Text = "Enter";
            // 
            // panel_space
            // 
            this.panel_space.BackColor = System.Drawing.Color.White;
            this.panel_space.Controls.Add(this.label_space);
            this.panel_space.Location = new System.Drawing.Point(180, 116);
            this.panel_space.Name = "panel_space";
            this.panel_space.Size = new System.Drawing.Size(50, 106);
            this.panel_space.TabIndex = 5;
            // 
            // label_space
            // 
            this.label_space.AutoSize = true;
            this.label_space.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_space.Location = new System.Drawing.Point(2, 45);
            this.label_space.Name = "label_space";
            this.label_space.Size = new System.Drawing.Size(47, 16);
            this.label_space.TabIndex = 1;
            this.label_space.Text = "Space";
            // 
            // panel_w
            // 
            this.panel_w.BackColor = System.Drawing.Color.White;
            this.panel_w.Controls.Add(this.label_w);
            this.panel_w.Location = new System.Drawing.Point(12, 284);
            this.panel_w.Name = "panel_w";
            this.panel_w.Size = new System.Drawing.Size(106, 50);
            this.panel_w.TabIndex = 16;
            // 
            // label_w
            // 
            this.label_w.AutoSize = true;
            this.label_w.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_w.Location = new System.Drawing.Point(15, 19);
            this.label_w.Name = "label_w";
            this.label_w.Size = new System.Drawing.Size(23, 16);
            this.label_w.TabIndex = 1;
            this.label_w.Text = "わ";
            // 
            // panel_r
            // 
            this.panel_r.BackColor = System.Drawing.Color.White;
            this.panel_r.Controls.Add(this.label_r);
            this.panel_r.Location = new System.Drawing.Point(124, 228);
            this.panel_r.Name = "panel_r";
            this.panel_r.Size = new System.Drawing.Size(50, 50);
            this.panel_r.TabIndex = 14;
            // 
            // label_r
            // 
            this.label_r.AutoSize = true;
            this.label_r.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_r.Location = new System.Drawing.Point(15, 19);
            this.label_r.Name = "label_r";
            this.label_r.Size = new System.Drawing.Size(23, 16);
            this.label_r.TabIndex = 1;
            this.label_r.Text = "ら";
            // 
            // panel_s
            // 
            this.panel_s.BackColor = System.Drawing.Color.White;
            this.panel_s.Controls.Add(this.label_s);
            this.panel_s.Location = new System.Drawing.Point(124, 116);
            this.panel_s.Name = "panel_s";
            this.panel_s.Size = new System.Drawing.Size(50, 50);
            this.panel_s.TabIndex = 6;
            // 
            // label_s
            // 
            this.label_s.AutoSize = true;
            this.label_s.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_s.Location = new System.Drawing.Point(15, 19);
            this.label_s.Name = "label_s";
            this.label_s.Size = new System.Drawing.Size(23, 16);
            this.label_s.TabIndex = 1;
            this.label_s.Text = "さ";
            // 
            // panel_backspace
            // 
            this.panel_backspace.BackColor = System.Drawing.Color.White;
            this.panel_backspace.Controls.Add(this.label_backspace);
            this.panel_backspace.Location = new System.Drawing.Point(180, 60);
            this.panel_backspace.Name = "panel_backspace";
            this.panel_backspace.Size = new System.Drawing.Size(50, 50);
            this.panel_backspace.TabIndex = 3;
            // 
            // label_backspace
            // 
            this.label_backspace.AutoSize = true;
            this.label_backspace.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_backspace.Location = new System.Drawing.Point(2, 10);
            this.label_backspace.Name = "label_backspace";
            this.label_backspace.Size = new System.Drawing.Size(47, 32);
            this.label_backspace.TabIndex = 1;
            this.label_backspace.Text = "Back\r\nSpace";
            this.label_backspace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_y
            // 
            this.panel_y.BackColor = System.Drawing.Color.White;
            this.panel_y.Controls.Add(this.label_y);
            this.panel_y.Location = new System.Drawing.Point(68, 228);
            this.panel_y.Name = "panel_y";
            this.panel_y.Size = new System.Drawing.Size(50, 50);
            this.panel_y.TabIndex = 15;
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_y.Location = new System.Drawing.Point(15, 19);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(23, 16);
            this.label_y.TabIndex = 1;
            this.label_y.Text = "や";
            // 
            // panel_k
            // 
            this.panel_k.BackColor = System.Drawing.Color.White;
            this.panel_k.Controls.Add(this.label_k);
            this.panel_k.Location = new System.Drawing.Point(68, 116);
            this.panel_k.Name = "panel_k";
            this.panel_k.Size = new System.Drawing.Size(50, 50);
            this.panel_k.TabIndex = 7;
            // 
            // label_k
            // 
            this.label_k.AutoSize = true;
            this.label_k.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_k.Location = new System.Drawing.Point(15, 19);
            this.label_k.Name = "label_k";
            this.label_k.Size = new System.Drawing.Size(23, 16);
            this.label_k.TabIndex = 1;
            this.label_k.Text = "か";
            // 
            // panel_h
            // 
            this.panel_h.BackColor = System.Drawing.Color.White;
            this.panel_h.Controls.Add(this.label_h);
            this.panel_h.Location = new System.Drawing.Point(124, 172);
            this.panel_h.Name = "panel_h";
            this.panel_h.Size = new System.Drawing.Size(50, 50);
            this.panel_h.TabIndex = 10;
            // 
            // label_h
            // 
            this.label_h.AutoSize = true;
            this.label_h.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_h.Location = new System.Drawing.Point(15, 19);
            this.label_h.Name = "label_h";
            this.label_h.Size = new System.Drawing.Size(23, 16);
            this.label_h.TabIndex = 1;
            this.label_h.Text = "は";
            // 
            // panel_m
            // 
            this.panel_m.BackColor = System.Drawing.Color.White;
            this.panel_m.Controls.Add(this.label_m);
            this.panel_m.Location = new System.Drawing.Point(12, 228);
            this.panel_m.Name = "panel_m";
            this.panel_m.Size = new System.Drawing.Size(50, 50);
            this.panel_m.TabIndex = 12;
            // 
            // label_m
            // 
            this.label_m.AutoSize = true;
            this.label_m.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_m.Location = new System.Drawing.Point(15, 19);
            this.label_m.Name = "label_m";
            this.label_m.Size = new System.Drawing.Size(23, 16);
            this.label_m.TabIndex = 1;
            this.label_m.Text = "ま";
            // 
            // panel_delete
            // 
            this.panel_delete.BackColor = System.Drawing.Color.White;
            this.panel_delete.Controls.Add(this.label_delete);
            this.panel_delete.Location = new System.Drawing.Point(124, 60);
            this.panel_delete.Name = "panel_delete";
            this.panel_delete.Size = new System.Drawing.Size(50, 50);
            this.panel_delete.TabIndex = 3;
            // 
            // label_delete
            // 
            this.label_delete.AutoSize = true;
            this.label_delete.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_delete.Location = new System.Drawing.Point(10, 20);
            this.label_delete.Name = "label_delete";
            this.label_delete.Size = new System.Drawing.Size(31, 16);
            this.label_delete.TabIndex = 1;
            this.label_delete.Text = "Del";
            this.label_delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1_n
            // 
            this.panel1_n.BackColor = System.Drawing.Color.White;
            this.panel1_n.Controls.Add(this.label_n);
            this.panel1_n.Location = new System.Drawing.Point(68, 172);
            this.panel1_n.Name = "panel1_n";
            this.panel1_n.Size = new System.Drawing.Size(50, 50);
            this.panel1_n.TabIndex = 11;
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_n.Location = new System.Drawing.Point(15, 19);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(23, 16);
            this.label_n.TabIndex = 1;
            this.label_n.Text = "な";
            // 
            // panel_a
            // 
            this.panel_a.BackColor = System.Drawing.Color.White;
            this.panel_a.Controls.Add(this.label_a);
            this.panel_a.Location = new System.Drawing.Point(12, 116);
            this.panel_a.Name = "panel_a";
            this.panel_a.Size = new System.Drawing.Size(50, 50);
            this.panel_a.TabIndex = 4;
            // 
            // label_a
            // 
            this.label_a.AutoSize = true;
            this.label_a.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_a.Location = new System.Drawing.Point(15, 19);
            this.label_a.Name = "label_a";
            this.label_a.Size = new System.Drawing.Size(23, 16);
            this.label_a.TabIndex = 1;
            this.label_a.Text = "あ";
            // 
            // panel1_t
            // 
            this.panel1_t.BackColor = System.Drawing.Color.White;
            this.panel1_t.Controls.Add(this.label_t);
            this.panel1_t.Location = new System.Drawing.Point(12, 172);
            this.panel1_t.Name = "panel1_t";
            this.panel1_t.Size = new System.Drawing.Size(50, 50);
            this.panel1_t.TabIndex = 8;
            // 
            // label_t
            // 
            this.label_t.AutoSize = true;
            this.label_t.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_t.Location = new System.Drawing.Point(15, 19);
            this.label_t.Name = "label_t";
            this.label_t.Size = new System.Drawing.Size(23, 16);
            this.label_t.TabIndex = 1;
            this.label_t.Text = "た";
            // 
            // panel_onoff
            // 
            this.panel_onoff.BackColor = System.Drawing.Color.White;
            this.panel_onoff.Controls.Add(this.label_onoff);
            this.panel_onoff.Location = new System.Drawing.Point(68, 60);
            this.panel_onoff.Name = "panel_onoff";
            this.panel_onoff.Size = new System.Drawing.Size(50, 50);
            this.panel_onoff.TabIndex = 3;
            // 
            // label_onoff
            // 
            this.label_onoff.AutoSize = true;
            this.label_onoff.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_onoff.Location = new System.Drawing.Point(10, 10);
            this.label_onoff.Name = "label_onoff";
            this.label_onoff.Size = new System.Drawing.Size(31, 32);
            this.label_onoff.TabIndex = 1;
            this.label_onoff.Text = "On/\r\nOff";
            this.label_onoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_numlock
            // 
            this.panel_numlock.BackColor = System.Drawing.Color.White;
            this.panel_numlock.Controls.Add(this.label_numlock);
            this.panel_numlock.Location = new System.Drawing.Point(12, 60);
            this.panel_numlock.Name = "panel_numlock";
            this.panel_numlock.Size = new System.Drawing.Size(50, 50);
            this.panel_numlock.TabIndex = 2;
            // 
            // label_numlock
            // 
            this.label_numlock.AutoSize = true;
            this.label_numlock.Font = new System.Drawing.Font("美咲ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_numlock.Location = new System.Drawing.Point(6, 10);
            this.label_numlock.Name = "label_numlock";
            this.label_numlock.Size = new System.Drawing.Size(39, 32);
            this.label_numlock.TabIndex = 1;
            this.label_numlock.Text = "Num\r\nLock";
            this.label_numlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 346);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Numpad Input";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_dot.ResumeLayout(false);
            this.panel_dot.PerformLayout();
            this.panel_enter.ResumeLayout(false);
            this.panel_enter.PerformLayout();
            this.panel_space.ResumeLayout(false);
            this.panel_space.PerformLayout();
            this.panel_w.ResumeLayout(false);
            this.panel_w.PerformLayout();
            this.panel_r.ResumeLayout(false);
            this.panel_r.PerformLayout();
            this.panel_s.ResumeLayout(false);
            this.panel_s.PerformLayout();
            this.panel_backspace.ResumeLayout(false);
            this.panel_backspace.PerformLayout();
            this.panel_y.ResumeLayout(false);
            this.panel_y.PerformLayout();
            this.panel_k.ResumeLayout(false);
            this.panel_k.PerformLayout();
            this.panel_h.ResumeLayout(false);
            this.panel_h.PerformLayout();
            this.panel_m.ResumeLayout(false);
            this.panel_m.PerformLayout();
            this.panel_delete.ResumeLayout(false);
            this.panel_delete.PerformLayout();
            this.panel1_n.ResumeLayout(false);
            this.panel1_n.PerformLayout();
            this.panel_a.ResumeLayout(false);
            this.panel_a.PerformLayout();
            this.panel1_t.ResumeLayout(false);
            this.panel1_t.PerformLayout();
            this.panel_onoff.ResumeLayout(false);
            this.panel_onoff.PerformLayout();
            this.panel_numlock.ResumeLayout(false);
            this.panel_numlock.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel panel1;
        private Panel panel_numlock;
        private Label label_numlock;
        private Panel panel_dot;
        private Label label_dot;
        private Panel panel_enter;
        private Label label_enter;
        private Panel panel_space;
        private Label label_space;
        private Panel panel_w;
        private Label label_w;
        private Panel panel_r;
        private Label label_r;
        private Panel panel_s;
        private Label label_s;
        private Panel panel_backspace;
        private Label label_backspace;
        private Panel panel_y;
        private Label label_y;
        private Panel panel_k;
        private Label label_k;
        private Panel panel_h;
        private Label label_h;
        private Panel panel_m;
        private Label label_m;
        private Panel panel_delete;
        private Label label_delete;
        private Panel panel1_n;
        private Label label_n;
        private Panel panel_a;
        private Label label_a;
        private Panel panel1_t;
        private Label label_t;
        private Panel panel_onoff;
        private Label label_onoff;
        private Label onoff;
        private System.Windows.Forms.Label labelStatus;
    }
}