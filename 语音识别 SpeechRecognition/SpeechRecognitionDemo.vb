Imports System.ComponentModel
Imports System.Speech.Recognition

Public Class SpeechRecognitionDemo
    Dim MySpeechRecognitionEngine As SpeechRecognitionEngine = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初始化引擎
        MySpeechRecognitionEngine = CreateSpeechEngine("zh-CN")

        '注册事件
        AddHandler MySpeechRecognitionEngine.AudioLevelUpdated, AddressOf engine_AudioLevelUpdated
        AddHandler MySpeechRecognitionEngine.SpeechRecognized, AddressOf engine_SpeechRecognized
        AddHandler MySpeechRecognitionEngine.AudioStateChanged, AddressOf engine_AudioStateChanged

        '导入语法
        LoadGrammar(Environment.CurrentDirectory + "\\Grammar.txt")

        '使用系统默认麦克风
        MySpeechRecognitionEngine.SetInputToDefaultAudioDevice()

        '开始监听
        MySpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
    End Sub

    '创建引擎
    Private Function CreateSpeechEngine(ByVal PreferredCulture As String) As SpeechRecognitionEngine
        Dim TempSpeechRecognitionEngine As SpeechRecognitionEngine = Nothing
        For Each Config As RecognizerInfo In SpeechRecognitionEngine.InstalledRecognizers()
            '遍历所有引擎语言匹配到指定语言，创建引擎，跳出
            If (Config.Culture.ToString() = PreferredCulture) Then TempSpeechRecognitionEngine = New SpeechRecognitionEngine(Config) : Exit For
        Next

        '未匹配到指定引擎，使用默认语言创建语音引擎
        If (TempSpeechRecognitionEngine Is Nothing) Then
            Dim tempPreferredCulture As String = SpeechRecognitionEngine.InstalledRecognizers().First.Culture.ToString()
            MsgBox("未安装指定语言，引擎将会使用默认语言： " & tempPreferredCulture, 64, "未找到指定语言")
            TempSpeechRecognitionEngine = New SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers().First)
        End If

        Return TempSpeechRecognitionEngine
    End Function

    '为语音引擎导入语法
    Private Sub LoadGrammar(Optional ByVal GrammarFilePath As String = vbNullString)
        '——组合语法：————————————————————————
        '——每个组合里只能取一个值，顺序从A到C，必须每个组合都有值———
        'Dim Grammars As GrammarBuilder = New GrammarBuilder()
        'Grammars.Append(New Choices("汽车", "飞机"))
        'Grammars.Append(New Choices("前进", "后退"))
        'Dim GrammarList As Grammar = New Grammar(Grammars)
        'MySpeechRecognitionEngine.LoadGrammar(GrammarList)

        '——单词语法：————————————————————————
        'Dim Grammars As GrammarBuilder = New GrammarBuilder()
        'Grammars.Append(New Choices("汽车", "飞机"))
        'Dim GrammarList As Grammar = New Grammar(Grammars)
        'MySpeechRecognitionEngine.LoadGrammar(GrammarList)

        '——从文本读取语法：—————————————————————
        If GrammarFilePath <> vbNullString And IO.File.Exists(GrammarFilePath) Then
            '有可用的语法文件，则读取规定的语法
            Dim Grammars As Choices = New Choices()
            Dim Lines() As String = IO.File.ReadAllLines(GrammarFilePath, System.Text.Encoding.Default)
            For Each Line As String In Lines
                Grammars.Add(Line)
            Next
            Dim GrammarList As Grammar = New Grammar(New GrammarBuilder(Grammars))
            MySpeechRecognitionEngine.LoadGrammar(GrammarList)
        Else
            '没有可用的语法，则使用桌面语音技术提供的默认语法
            MySpeechRecognitionEngine.LoadGrammar(New DictationGrammar)
        End If
    End Sub

    '采用与其加载启用的 Grammar 对象匹配的输入
    Private Sub engine_SpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs)
        ResultLabel.ForeColor = Color.Black
        ResultLabel.Text = e.Result.Text
    End Sub

    '报告音频输入的级别
    Private Sub engine_AudioLevelUpdated(sender As Object, e As AudioLevelUpdatedEventArgs)
        VoiceLevelBar.Value = e.AudioLevel
    End Sub

    '接收的音频更改
    Private Sub engine_AudioStateChanged(sender As Object, e As AudioStateChangedEventArgs)
        If e.AudioState = AudioState.Speech Then
            ResultLabel.ForeColor = Color.DarkGray
            Me.Text = "语音引擎：Speech..."
        ElseIf e.AudioState = AudioState.Silence Then
            Me.Text = "语音引擎：Silence..."
        Else
            Me.Text = "语音引擎：Stoped..."
        End If
    End Sub

    '程序关闭，停止监听，释放内存
    Private Sub SpeechRecognitionDemo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MySpeechRecognitionEngine.RecognizeAsyncStop()
        MySpeechRecognitionEngine.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        MySpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        MySpeechRecognitionEngine.RecognizeAsyncStop()
    End Sub
End Class
