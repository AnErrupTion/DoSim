Imports System.Threading
Imports System.Net

Module Commands

    Public Sub Exec(RL As String)
        If RL.Equals("help") Then
            NoMsg()
            Console.WriteLine("help | Show this command.")
            Console.WriteLine("slots | Show all slots and their commands.")
            Console.WriteLine("slot <s> | Execute the slot <s>'s command.")
            Console.WriteLine("save <s> <c>|clears | Save a command <c> on a slot <s> or clear (clears) the slot (can use multiple commands with ; (example : echo test;sleep 5000;clear will return the text test, sleep for 5 seconds then clear the console)).")
            Console.WriteLine("autostart <c>|clears | Save a command <c> to do on " & Reference.AppName & "'s startup or clear (clears) the autostart command (can use multiple commands with ; (example : echo test;sleep 5000;clear will return the text test, sleep for 5 seconds then clear the console)).")
            Console.WriteLine("echo <t> | Echo text <t> (can use multiple lines with ; (example : echo test;123 will return test, new line, 123)).")
            Console.WriteLine("clear | Clear the console.")
            Console.WriteLine("sleep <m> | Make the current window sleep for X millisecond(s) <m>")
            Console.WriteLine("pause | Make the console act like 'pause' in batch.")
            Console.WriteLine("gui | Show " & Reference.AppName & "'s GUI.")
            Console.WriteLine("math <1> <+> <2> | Do some simple math (example : <1> = 2, <+> = +, <2> = 2).")
            Console.WriteLine("color <i> <c> | Change the color <c> (up to 15, NOT including 0) of an item <i> (background / text).")
            Console.WriteLine("web <p> | Download the string of a web page <p>.")
        ElseIf RL.Equals("slots") Then
            NoMsg()
            Console.WriteLine("Slot 1 | " & My.Settings.slot1)
            Console.WriteLine("Slot 2 | " & My.Settings.slot2)
            Console.WriteLine("Slot 3 | " & My.Settings.slot3)
            Console.WriteLine("Slot 4 | " & My.Settings.slot4)
            Console.WriteLine("Slot 5 | " & My.Settings.slot5)
            Console.WriteLine("Slot 6 | " & My.Settings.slot6)
            NoMsg()
            Console.WriteLine("Auto Start | " & My.Settings.autostart)
        ElseIf RL.StartsWith("slot ") Then
            RL = RL.Replace("slot ", "")

            If RL = "1" Then
                For Each Cmd As String In My.Settings.slot1.Split(";")
                    Exec(Cmd)
                Next
            ElseIf RL = "2" Then
                For Each Cmd As String In My.Settings.slot2.Split(";")
                    Exec(Cmd)
                Next
            ElseIf RL = "3" Then
                For Each Cmd As String In My.Settings.slot3.Split(";")
                    Exec(Cmd)
                Next
            ElseIf RL = "4" Then
                For Each Cmd As String In My.Settings.slot4.Split(";")
                    Exec(Cmd)
                Next
            ElseIf RL = "5" Then
                For Each Cmd As String In My.Settings.slot5.Split(";")
                    Exec(Cmd)
                Next
            ElseIf RL = "6" Then
                For Each Cmd As String In My.Settings.slot6.Split(";")
                    Exec(Cmd)
                Next
            End If
        ElseIf RL.StartsWith("save 1 ") Then
            RL = RL.Replace("save 1 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot1 = ""
                My.Settings.Save()
            Else
                My.Settings.slot1 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("save 2 ") Then
            RL = RL.Replace("save 2 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot2 = ""
                My.Settings.Save()
            Else
                My.Settings.slot2 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("save 3 ") Then
            RL = RL.Replace("save 3 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot3 = ""
                My.Settings.Save()
            Else
                My.Settings.slot3 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("save 4 ") Then
            RL = RL.Replace("save 4 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot4 = ""
                My.Settings.Save()
            Else
                My.Settings.slot4 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("save 5 ") Then
            RL = RL.Replace("save 5 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot5 = ""
                My.Settings.Save()
            Else
                My.Settings.slot5 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("save 6 ") Then
            RL = RL.Replace("save 6 ", "")

            If RL.Equals("clears") Then
                My.Settings.slot6 = ""
                My.Settings.Save()
            Else
                My.Settings.slot6 = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("autostart ") Then
            RL = RL.Replace("autostart ", "")

            If RL.Equals("clears") Then
                My.Settings.autostart = ""
                My.Settings.Save()
            Else
                My.Settings.autostart = RL
                My.Settings.Save()
            End If
        ElseIf RL.StartsWith("echo ") Then
            For Each Line As String In RL.Replace("echo ", "").Split(";")
                NoMsg()
                Console.WriteLine(Line)
            Next
        ElseIf RL.Equals("clear") Then
            Console.Clear()
        ElseIf RL.StartsWith("sleep ") Then
            RL = RL.Replace("sleep ", "")
            Thread.Sleep(CInt(RL))
        ElseIf RL.Equals("pause") Then
            NoMsg()
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey(True)
        ElseIf RL.Equals("gui") Then
            BatchUI.SGUI()
        ElseIf RL.StartsWith("math ") Then
            Try
                RL = RL.Replace("math ", "")

                Dim result = New DataTable().Compute(RL, Nothing)

                NoMsg()
                Console.WriteLine(result)
            Catch ex As Exception
                Console.WriteLine("ERROR : " & ex.Message)
            End Try
        ElseIf RL.StartsWith("color background ") Then
            Try
                RL = RL.Replace("color background ", "")
                Console.BackgroundColor = CInt(RL)
            Catch
                NoMsg()
                Console.WriteLine("ERROR : Color must be a number from 1 to 15.")
            End Try
        ElseIf RL.StartsWith("color text ") Then
            Try
                RL = RL.Replace("color text ", "")
                Console.ForegroundColor = CInt(RL)
            Catch
                NoMsg()
                Console.WriteLine("ERROR : Color must be a number from 1 to 15.")
            End Try
        ElseIf RL.StartsWith("web ") Then
            RL = RL.Replace("web ", "")

            Try
                Dim sourceString As String = New WebClient().DownloadString(RL)
                NoMsg()
                Console.WriteLine(sourceString)
            Catch ex As Exception
                NoMsg()
                Console.WriteLine("ERROR : " & ex.Message)
            End Try
        Else
            NoMsg()
            Console.WriteLine("Unknown command.")
        End If
    End Sub

    Public Sub NoMsg()
        Console.WriteLine("")
    End Sub

End Module
