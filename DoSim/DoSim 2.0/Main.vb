Module Main

    Sub Main()
        Console.Beep()
        Console.WriteLine(Reference.AppName & " v" & Reference.AppVersion)
        Console.Title = Reference.ClientName & " v" & Reference.AppVersion

        If Not My.Settings.autostart = "" Then
            Console.WriteLine("Executing autostart...")
            Commands.Exec(My.Settings.autostart)
        End If

        Do
            NoMsg()
            Console.Write("Main>")
            Commands.Exec(Console.ReadLine())
        Loop
    End Sub

End Module
