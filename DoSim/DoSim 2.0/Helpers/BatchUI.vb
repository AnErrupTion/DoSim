Module BatchUI

    Public Sub SGUI()
        Commands.Exec("clear")

        Main.StopLoop = True

        Commands.NoMsg()
        Console.WriteLine("------------------------ " & Reference.UIName & " " & Reference.AppVersion & " ------------------------")
        Console.WriteLine("start | Start the Virtual Batch Operating Environment (VBOE)")
        Console.WriteLine("info | Get more informations about the creator, the github, etc..")
        Console.WriteLine("exit | Quit the GUI.")
        Console.WriteLine("------------------------ " & Reference.UIName & " " & Reference.AppVersion & " ------------------------")

        Do
            NoMsg()
            Console.Write(Reference.UIName & ">")
            Execute(Console.ReadLine())
        Loop
    End Sub

    Private Sub Execute(RL As String)
        If RL.Equals("start") Then
            NoMsg()
            Console.WriteLine("Coming soon!")
        ElseIf RL.Equals("info") Then
            NoMsg()
            Console.WriteLine("Made by ErrupTion_ | GitHub : https://github.com/AnErrupTion/DoSim-2.0 | Current Version : " & Reference.AppVersion)
        ElseIf RL.Equals("exit") Then
            Commands.Exec("clear")
            Main.StopLoop = False
            Main.CheckForLoop()
        End If
    End Sub

End Module
