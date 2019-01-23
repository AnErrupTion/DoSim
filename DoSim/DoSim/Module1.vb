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
        If e = "slot-help" Then
            Console.WriteLine("Slot 1: Program slot, recommended for the main application, used by BATCH-UI to view or edit slots")
            Console.WriteLine("Slot 6: Compare slot, should contain the command to run if compare returns true")
            Console.WriteLine("Prompt Slot: Stores the text inputted into the prompt command, acts like a normal slot but cant be modified using save")


        End If
        '-
        e = e.Replace("*1*", My.Settings.slot1)
        e = e.Replace("*2*", My.Settings.slot2)
        e = e.Replace("*3*", My.Settings.slot3)
        e = e.Replace("*4*", My.Settings.slot4)
        e = e.Replace("*5*", My.Settings.slot5)
        e = e.Replace("*6*", My.Settings.slot6)
        e = e.Replace("*p*", My.Settings.prompt)
        e = e.Replace("*clip*", My.Computer.Clipboard.GetText())


        If e.StartsWith("save 1 ") Then
            e = e.Replace("save 1 ", "")
            My.Settings.slot1 = e
            My.Settings.Save()
        End If
        If e.StartsWith("save 2 ") Then
            e = e.Replace("save 2 ", "")
            My.Settings.slot2 = e
            My.Settings.Save()
        End If
        If e.StartsWith("save 3 ") Then
            e = e.Replace("save 3 ", "")
            My.Settings.slot3 = e
            My.Settings.Save()
        End If
        If e.StartsWith("save 4 ") Then
            e = e.Replace("save 4 ", "")
            My.Settings.slot4 = e
            My.Settings.Save()
        End If
        If e.StartsWith("save 5 ") Then
            e = e.Replace("save 5 ", "")
            My.Settings.slot5 = e
            My.Settings.Save()
        End If
        If e.StartsWith("save 6 ") Then
            e = e.Replace("save 6 ", "")
            My.Settings.slot6 = e
            My.Settings.Save()
        End If
        '-

        If e = "clear" Then
            Console.Clear()
        End If
        If e = "batch-ui" Then

            DSui()
        End If
        If e.StartsWith("sleep ") Then
            e = e.Replace("sleep ", "")
            Threading.Thread.Sleep(CInt(e))
        End If
        If e = "pause" Then
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey(True)
        End If

        If e.StartsWith("echo ") Then
            e = e.Replace("echo ", "")
            e = e.Replace(";", "")

            Console.WriteLine(e)
        End If
        If e.StartsWith("autostart ") Then
            e = e.Replace("autostart ", "")
            My.Settings.autostart = e
            My.Settings.Save()
        End If
        If e.StartsWith("prompt ") Then
            e = e.Replace("prompt ", "")

            Console.Write(e)
            My.Settings.prompt = Console.ReadLine
            My.Settings.Save()
        End If
        If e.StartsWith("compare") Then
            e = e.Replace("compare ", "")
            If e.Split(" ").First = e.Split(" ").Last Then
                Exec("*6*")
            End If

        End If

        If e.StartsWith("secho ") Then
            e = e.Replace("secho ", "")
            e = e.Replace(";", "")

            Console.Write(e)
        End If

        If e.StartsWith("math ") Then
            Try
                e = e.Replace("math ", "")
                
                Dim result = New DataTable().Compute(e, Nothing)

                Console.WriteLine(result)
            Catch b As Exception
                Console.WriteLine("ERROR! " + b.Message)
            End Try

        End If
        If e.StartsWith("batch ") Then
            e = e.Replace("batch ", "")
            For Each Item In e.Split(";")
                Exec(Item)
            Next
        End If
        If e.StartsWith("batch2 ") Then
            e = e.Replace("batch2 ", "")
            For Each Item In e.Split("-")
                Exec(Item)
            Next
        End If

        If e.StartsWith("loop ") Then
            isloop = True
            e = e.Replace("loop ", "")

            Do While isloop = True
                Exec(e)
                Threading.Thread.Sleep(1)
            Loop
        End If
        If e.StartsWith("stoploop") Then
            isloop = False

        End If
        If e.StartsWith("color bg ") Then

            e = e.Replace("color bg ", "")
            Console.BackgroundColor = e
        End If

        If e.StartsWith("color text") Then

            e = e.Replace("color text ", "")
            Console.ForegroundColor = e

            Console.WriteLine("ERROR! Color needs to be a number from 1 to 15")

        End If
        If e.StartsWith("view ") Then
            e = e.Replace("view ", "")
            For Each Item In NumToSlot(e).Split(";")
                Console.WriteLine(Item)
            Next
        End If
        If e.StartsWith("web ") Then
            e = e.Replace("web ", "")
            Try
                Dim sourceString As String = New System.Net.WebClient().DownloadString(e)
                Console.WriteLine(sourceString)
            Catch
                Console.WriteLine("ERROR")
            End Try
        End If


    End Function

    Function DSui()

        Console.Clear()
        Console.WriteLine("██████████████████ BATCH-UI 1.3 ██████████████████")
        Console.WriteLine("Please select your mode: edit, compare-edit, run or view")
        Console.WriteLine("edit - Edit slot 1")
        Console.WriteLine("compare-edit - Edit slot 6")
        Console.WriteLine("run - Run any slot")
        Console.WriteLine("view - View slot 1")
        Dim cr As String
        cr = Console.ReadLine()
        If cr = "edit" Then
            Console.WriteLine("Editing on Slot 1")
            Console.WriteLine("WARNING: THIS WILL OVERRIDE SLOT 1, PRESS ANY KEY TO ERASE AND CONTINUE!")
            Console.ReadKey(True)
            Console.WriteLine("Write exit to exit BATCH-UI")
            Console.WriteLine("███████████████████ SLOT 1 ███████████████████████")
            My.Settings.slot1 = "echo echo "
            Dim co As String
            Do
                Console.Write("BATCH 1>")
                co = Console.ReadLine()
                If co = "exit" Then
                    Console.Clear()
                    Exit Do
                Else
                    My.Settings.slot1 = My.Settings.slot1 + ";" + co
                End If
            Loop
        Else
            If cr = "compare-edit" Then
                Console.WriteLine("Editing on Slot 6")
                Console.WriteLine("WARNING: THIS WILL OVERRIDE SLOT 6, PRESS ANY KEY TO ERASE AND CONTINUE!")
                Console.ReadKey(True)
                Console.WriteLine("Write exit to exit BATCH-UI")
                Console.WriteLine("███████████████████ SLOT 6 ███████████████████████")
                My.Settings.slot6 = "echo echo "
                Dim co As String
                Do
                    Console.Write("BATCH 6>")
                    co = Console.ReadLine()
                    If co = "exit" Then
                        Console.Clear()
                        Exit Do
                    Else
                        My.Settings.slot6 = My.Settings.slot6 + ";" + co
                    End If
                Loop
            Else
                If cr = "run" Then
                    Console.WriteLine("Please specify your slot number from 1 to 6")
                    Console.WriteLine("Scripts created with Batch-UI are always saved to slot 1")
                    Exec("batch *" + Console.ReadLine() + "*")
                    Console.WriteLine("## Execution stopped ##")
                Else
                    If cr = "view" Then
                        Console.Clear()
                        Console.WriteLine("############## VIEWING SLOT 1 ###################")
                        For Each Item In My.Settings.slot1.Split(";")
                            Console.WriteLine(Item)
                        Next
                        Console.WriteLine("#################################################")
                    End If
                End If

            End If
        End If
    End Function

    Sub Main()
        Dim Path As String = Directory.GetCurrentDirectory()
        Dim i As Integer
        Console.Beep()
        Console.WriteLine("DoSim 1.3")
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
