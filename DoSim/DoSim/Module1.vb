Imports System.Windows.Forms
Imports System.IO

Module Module1
    Dim isloop As Boolean
    Function RT(ByVal e As String, ByVal tag As String)
      
        Return e
    End Function
    Function NumToSlot(ByVal e As Integer)
        If e = 1 Then
            Return My.Settings.slot1
        End If
        If e = 2 Then
            Return My.Settings.slot2
        End If
        If e = 3 Then
            Return My.Settings.slot3
        End If
        If e = 4 Then
            Return My.Settings.slot4
        End If
        If e = 5 Then
            Return My.Settings.slot5
        End If
        If e = 6 Then
            Return My.Settings.slot6
        End If
    End Function
    Function Exec(ByVal e As String)

        '-
        e = e.Replace("*1*", My.Settings.slot1)
        e = e.Replace("*2*", My.Settings.slot2)
        e = e.Replace("*3*", My.Settings.slot3)
        e = e.Replace("*4*", My.Settings.slot4)
        e = e.Replace("*5*", My.Settings.slot5)
        e = e.Replace("*6*", My.Settings.slot6)
        e = e.Replace("*p*", My.Settings.prompt)
        e = e.Replace("*clip*", My.Computer.Clipboard.GetText())


     '   If e.StartsWith("save 1 ") Then
     '       e = e.Replace("save 1 ", "")
     '       My.Settings.slot1 = e
     '       My.Settings.Save()
     '   End If
     '   If e.StartsWith("save 2 ") Then
     '       e = e.Replace("save 2 ", "")
     '       My.Settings.slot2 = e
     '       My.Settings.Save()
     '   End If
     '   If e.StartsWith("save 3 ") Then
     '      e = e.Replace("save 3 ", "")
     '       My.Settings.slot3 = e
     '       My.Settings.Save()
     '   End If
     '   If e.StartsWith("save 4 ") Then
     '       e = e.Replace("save 4 ", "")
     '       My.Settings.slot4 = e
     '       My.Settings.Save()
     '   End If
     '   If e.StartsWith("save 5 ") Then
     '       e = e.Replace("save 5 ", "")
     '       My.Settings.slot5 = e
     '       My.Settings.Save()
     '   End If
     '   If e.StartsWith("save 6 ") Then
     '       e = e.Replace("save 6 ", "")
     '       My.Settings.slot6 = e
     '       My.Settings.Save()
     '   End If
        '-

        If e.StartsWith("echo ") Then
            e = e.Replace("echo ", "")
            e = e.Replace(";", "")

            Console.WriteLine(e)
        End If

        If e.StartsWith("batch ") Then
            e = e.Replace("batch ", "")
            For Each Item In e.Split(";")
                Exec(Item)
            Next
        End If


  

    End Function

    

    Sub Main()
        Dim Path As String = Directory.GetCurrentDirectory()
        Dim i As Integer
        Console.Beep()
        Console.WriteLine("DoSim 1.3")
        Console.WriteLine("NoCommands Branch")
        Console.Title = "DoSim Client"
        'My.Settings.autostart = ""
        My.Settings.Save()
        If Not My.Settings.autostart = "" Then
            Console.WriteLine("Executing autostart...")
            Exec(My.Settings.autostart)
        End If

        Do
            Console.Write("Main>")
            Exec(Console.ReadLine())
        Loop
    End Sub

End Module
