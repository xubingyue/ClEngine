﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using ClEngine.CoreLibrary.Editor;
using ClEngine.ViewModel;
using CommonServiceLocator;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Search;

// ReSharper disable once CheckNamespace
namespace ClEngine
{
    /// <summary>
    /// ScriptWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScriptWindow
    {
        public static TextEditor ScriptEditor { get; internal set; }

        public ScriptWindow()
        {
            IHighlightingDefinition customHighlightingDefinition;

            using (var s = typeof(MainWindow).Assembly.GetManifestResourceStream("ClEngine.Lua.xshd"))
            {
                if (s == null)
                    throw new InvalidOperationException("没有找到对应资源");
                using (var reader = new XmlTextReader(s))
                {
                    customHighlightingDefinition =
                        HighlightingLoader.Load(reader,
                            HighlightingManager.Instance);
                }
            }

            HighlightingManager.Instance.RegisterHighlighting("Lua", new[] { ".lua" }, customHighlightingDefinition);

            InitializeComponent();

            SearchPanel.Install(TextEditor);

            TextEditor.TextArea.TextEntering += TextAreaOnTextEntering;
            TextEditor.TextArea.TextEntered += TextAreaOnTextEntered;

            ScriptEditor = TextEditor;
        }

        private CompletionWindow completionWindow;
        private void TextAreaOnTextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                completionWindow = new CompletionWindow(TextEditor.TextArea);
            }
        }

        private void CodeViewer_OnClick(object sender, RoutedEventArgs e)
        {
            if (CodeListBox.SelectedItem != null && CodeListBox.SelectedItem is TextBlock textBlock)
            {
                var scriptPath = Path.Combine(EditorRecord.MainViewModel.ProjectPosition, "scripts");
                if (Equals(textBlock.Text, Properties.Resources.Startup))
                {
                    LoadDocument(Path.Combine(scriptPath, "init.lua"));
                }
                else if (Equals(textBlock.Text, Properties.Resources.GameUpdate))
                {
                    LoadDocument(Path.Combine(scriptPath, "gameupdate.lua"));
                }
                else if (Equals(textBlock.Text, Properties.Resources.GameDraw))
                {
                    LoadDocument(Path.Combine(scriptPath, "gamedraw.lua"));
                }
                else if (Equals(textBlock.Text, Properties.Resources.LoadContent))
                {
                    LoadDocument(Path.Combine(scriptPath, "loadcontent.lua"));
                }
                else if (Equals(textBlock.Text, Properties.Resources.UnLoadContent))
                {
                    LoadDocument(Path.Combine(scriptPath, "unloadcontent.lua"));
                }
                else if (Equals(textBlock.Text, Properties.Resources.KeyEvent))
                {
                    LoadDocument(Path.Combine(scriptPath, "input.lua"));
                }
            }
        }

        public CompletionWindow CompletionWindow;
        private void TextAreaOnTextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && CompletionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    CompletionWindow.CompletionList.RequestInsertion(e);
                }
            }
        }

        private void LoadDocument(string filenamme)
        {
            if (TextEditor.IsModified)
            {
                var result = MessageBox.Show(@"监测到文本发生更改,是否保存？", @"脚本未保存");

                if (result == MessageBoxResult.Yes)
                    TextEditor.Save(((ScriptViewModel)DataContext).Name);
                else
                    return;
            }

            TextEditor.Load(filenamme);
            ((ScriptViewModel)DataContext).Name = filenamme;
        }

        public static void SaveScript()
        {
            var name = ServiceLocator.Current.GetInstance<ScriptViewModel>().Name;
            if (ScriptEditor.IsModified && File.Exists(name))
            {
                ScriptEditor.Save(name);
            }
        }


        // ReSharper disable once UnusedMember.Local
        private void SwitchOldXshdFile(string oldFile, string newFile)
        {
            XshdSyntaxDefinition xshd;
            using (var reader = new XmlTextReader(oldFile))
            {
                xshd = HighlightingLoader.LoadXshd(reader);
            }

            using (var writer = new XmlTextWriter(newFile, System.Text.Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                new SaveXshdVisitor(writer).WriteDefinition(xshd);
            }
        }
    }
}
