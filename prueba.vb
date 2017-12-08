    While Not File.Exists(Nwork + "tex\main.pdf")
                End While
-------------
  Public Shared Function DeterminarNoExistencia(ByVal PorNoEncontrar As String, ByVal tipo As String, ByVal segundos As Integer, Optional ByVal paso As Integer = 1) As Boolean
        Dim watch As Stopwatch
        Dim archivo As String = PorNoEncontrar
        Dim Existe As Boolean = False
        If tipo = cs"Archivo" Then
            watch = Stopwatch.StartNew()
            While FileIO.FileSystem.FileExists(archivo) And watch.Elapsed.TotalMilliseconds / 1000 < segundos
                Thread.Sleep(paso * 1000)
            End While
            watch.Stop()
        Else
            watch = Stopwatch.StartNew()
            While FileIO.FileSystem.DirectoryExists(archivo) And watch.Elapsed.TotalMilliseconds / 1000 < segundos
                Thread.Sleep(paso * 1000)
            End While
            watch.Stop()
        End If
        If watch.Elapsed.TotalMilliseconds / 1000 >= segundos Then
            Existe = True
        End If
        Return Existe
    End Function
---------------------
 Public Shared Function DeterminarExistencia(ByVal PorEncontrar As String, ByVal tipo As String, ByVal segundos As Integer, Optional ByVal paso As Integer = 1) As Boolean
        Dim watch As Stopwatch
        Dim archivo As String = PorEncontrar
        Dim Existe As Boolean = True
        If tipo = "Archivo" Then
            watch = Stopwatch.StartNew()
            While Not FileIO.FileSystem.FileExists(archivo) And watch.Elapsed.TotalMilliseconds / 1000 < segundos
                Thread.Sleep(paso * 1000)
            End While
            watch.Stop()
        Else
            watch = Stopwatch.StartNew()
            While Not FileIO.FileSystem.DirectoryExists(archivo) And watch.Elapsed.TotalMilliseconds / 1000 < segundos
                Thread.Sleep(paso * 1000)
            End While
            watch.Stop()
        End If
        If watch.Elapsed.TotalMilliseconds / 1000 >= segundos Then
            Existe = False
        End If
        Return Existe
    End Function
--------------------------
      MiProcesoMato("SumatraPDF", "main.pdf")
        AppActivate(swpId)
        My.Computer.Keyboard.SendKeys("^P")
        MiProceso("LaTeX passes", False, 10)
        AppActivate(swpId)
        My.Computer.Keyboard.SendKeys("{TAB}", True)
        AppActivate(swpId)
        My.Computer.Keyboard.SendKeys("{ENTER}", True)
        Thread.Sleep(100)


'Private Sub CompilarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompilarToolStripMenuItem.Click
    '    Dim L As New List(Of String)
    '    IdentificarSWP60()
    '    If Not Ndoc = "" Then
    '        NumCompilaciones = NumCompilaciones + 1
    '        Shell("latexmk.exe -pv -pdf -cd -silent -gg -f -view=none -interaction=nonstopmode " + Chr(34) & mainTeX & Chr(34))
    '        While Not File.Exists(Nwork + "tex\main.pdf")
    '        End While
    '        If NumCompilaciones > 1 Then
    '        Else
    '            Thread.Sleep(5000)
    '            While Not File.Exists(Nwork + "tex\main.pdf")
    '            End While
    '            Process.Start(ProgramFiles + "\SumatraPDF\SumatraPDF.exe", Chr(34) & Nwork + "tex\main.pdf" & Chr(34))
    '        End If
    '        NumCompilaciones = 1
    '        'Thread.Sleep(500)
    '    Else
    '        MessageBox.Show("Aun no ejecta SWP o Documento sin nombre")
    '    End If
    '    'TexPdf()
    '    'Menu1.Show(ButtonSCI, New System.Drawing.Point(2, 20))
    '    'Menu1.Visible = True
    'End Sub