using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NumpadToAlpha {
    public static class KeyboardHook {
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static int step = 0;
        public static string vowel = "";
        public static bool isEnable = true;

        public static void SetHook() {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) {
                _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public static void Unhook() {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == (int)Keys.Divide) {
                    isEnable = !isEnable;
                    MainForm.UpdateOnOff(isEnable);
                    return (IntPtr)1; // キーイベントをキャンセル
                }
                if (isEnable) {
                    if (step == 0) {
                        switch (vkCode) {
                            case (int)Keys.NumPad7:
                                vowel = "あ";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: あ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            case (int)Keys.NumPad8:
                                vowel = "か";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: か");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad9:
                                vowel = "さ";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: さ");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad4:
                                vowel = "た";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: た");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad5:
                                vowel = "な";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: な");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad6:
                                vowel = "は";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: は");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad1:
                                vowel = "ま";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: ま");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad2:
                                vowel = "や";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: や");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad3:
                                vowel = "ら";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: ら");
                                return (IntPtr)1; // キーイベントをキャンセル;
                            case (int)Keys.NumPad0:
                                vowel = "わ";
                                step = 1;
                                MainForm.UpdateStatus(vowel, step, "Step 1: わ");
                                return (IntPtr)1; // キーイベントをキャンセル;
                        }
                    } else if (step == 1) {
                        // Step 1の処理をここに追加
                        if (vowel == "あ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("あ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("い");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("う");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("え");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("お");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "あ";
                                MainForm.UpdateStatus(vowel, step, "Step 2: あ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "か") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("か");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("き");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("く");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("け");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("こ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "か";
                                MainForm.UpdateStatus(vowel, step, "Step 2: か");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "さ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("さ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("し");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("す");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("せ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("そ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "さ";
                                MainForm.UpdateStatus(vowel, step, "Step 2: さ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "た") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("た");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ち");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("つ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("て");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("と");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "た";
                                MainForm.UpdateStatus(vowel, step, "Step 2: た");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "な") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("な");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("に");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ぬ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("ね");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("の");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3 || vkCode == (int)Keys.NumPad0) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "は") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("は");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ひ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ふ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("へ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ほ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "は";
                                MainForm.UpdateStatus(vowel, step, "Step 2: は");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "ま") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ま");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("み");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("む");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("め");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("も");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3 || vkCode == (int)Keys.NumPad0) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "や") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("や");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("「");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ゆ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("」");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("よ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "や";
                                MainForm.UpdateStatus(vowel, step, "Step 2: や");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "ら") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ら");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("り");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("る");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("れ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ろ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3 || vkCode == (int)Keys.NumPad0) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "わ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("わ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("を");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ん");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("ー");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 2;
                                vowel = "わ";
                                MainForm.UpdateStatus(vowel, step, "Step 2: わ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3 || vkCode == (int)Keys.NumPad2) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        }
                    } else if (step == 2) {
                        if (vowel == "あ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ぁ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ぃ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ぅ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("ぇ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ぉ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "あ";
                                MainForm.UpdateStatus(vowel, step, "Step 1: あ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "か") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("が");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ぎ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ぐ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("げ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ご");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "か";
                                MainForm.UpdateStatus(vowel, step, "Step 1: か");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "さ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ざ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("じ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ず");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("ぜ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ぞ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "さ";
                                MainForm.UpdateStatus(vowel, step, "Step 1: さ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "た") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("だ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ぢ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("づ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7) {
                                SendKeys.Send("っ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("で");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ど");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "た";
                                MainForm.UpdateStatus(vowel, step, "Step 2: た");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "は") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ば");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("び");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ぶ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("べ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ぼ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 3;
                                vowel = "は";
                                MainForm.UpdateStatus(vowel, step, "Step 2: は");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "や") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ゃ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ゅ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ょ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "や";
                                MainForm.UpdateStatus(vowel, step, "Step 1: や");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3 || vkCode == (int)Keys.NumPad4 || vkCode == (int)Keys.NumPad6) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        } else if (vowel == "わ") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ゎ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("、");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("。");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("！");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("？");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "わ";
                                MainForm.UpdateStatus(vowel, step, "Step 1: わ");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        }
                    } else if (step == 3) {
                        if (vowel == "は") {
                            if (vkCode == (int)Keys.NumPad5) {
                                SendKeys.Send("ぱ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad4) {
                                SendKeys.Send("ぴ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad8) {
                                SendKeys.Send("ぷ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad6) {
                                SendKeys.Send("ぺ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad2) {
                                SendKeys.Send("ぽ");
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad0) {
                                step = 1;
                                vowel = "は";
                                MainForm.UpdateStatus(vowel, step, "Step 1: は");
                                return (IntPtr)1; // キーイベントをキャンセル
                            } else if (vkCode == (int)Keys.NumPad7 || vkCode == (int)Keys.NumPad9 || vkCode == (int)Keys.NumPad1 || vkCode == (int)Keys.NumPad3) {
                                step = 0;
                                vowel = "";
                                MainForm.UpdateStatus(vowel, step, "Step 0:");
                                return (IntPtr)1; // キーイベントをキャンセル
                            }
                        }
                    }
                    switch (vkCode) {
                        case (int)Keys.Subtract:
                            SendKeys.Send("{BACKSPACE}");
                            return (IntPtr)1; // キーイベントをキャンセル
                        case (int)Keys.Multiply:
                            SendKeys.Send("{DELETE}");
                            return (IntPtr)1; // キーイベントをキャンセル
                        case (int)Keys.Add:
                            SendKeys.Send(" ");
                            return (IntPtr)1; // キーイベントをキャンセル
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}