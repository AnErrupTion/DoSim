Module Main

    Public StopLoop As Boolean = False

    Sub Main()
        Console.Beep()
        Console.WriteLine(Reference.AppName & " v" & Reference.AppVersion)
        Console.Title = Reference.ClientName & " v" & Reference.AppVersion

        If Not My.Settings.autostart = "" Then
            Console.WriteLine("Executing autostart...")

            For Each Cmd As String In My.Settings.autostart.Split(";")
                Commands.Exec(Cmd)
            Next
        End If

        CheckForLoop()
    End Sub

    Public Sub CheckForLoop()
        If StopLoop = False Then
            Do
                If StopLoop = True Then
                    Exit Do
                End If

                NoMsg()
                Console.Write(Reference.AppName & ">")
                Commands.Exec(Console.ReadLine())
            Loop
        End If
    End Sub

End Module
