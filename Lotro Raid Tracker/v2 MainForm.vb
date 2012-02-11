Imports System.Data.SQLite

Public Class MainForm
#Region "Form Load and Variables"
    Dim CurrentCharacter As String = vbNullString
    Dim RaidLabels(100) As Label
    Structure Raid
        Dim RaidName As String
        Dim DayCompleted As DateTime
        Dim CharacterName As String
    End Structure
    Structure Character
        Dim Name As String
        Dim Server As String
    End Structure

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0
        FlowLayoutPanel1.Controls.Clear()
        Dim CharacterArray As New ArrayList
        Dim Characters As Character
        CharacterSelector.Items.Clear()
        RaidPicker.Items.Clear()
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        Try
            SQLconnect.Open()
        Catch ex As Exception

        End Try
        SQLcommand = SQLconnect.CreateCommand
        SQLcommand.CommandText = "Select * from Characters"
        Dim SQLReaderCharacter As SQLiteDataReader = SQLcommand.ExecuteReader()
        While SQLReaderCharacter.Read()
            Characters = New Character
            With Characters
                .Name = SQLReaderCharacter("CharacterName")
                .Server = SQLReaderCharacter("Server")
            End With
            CharacterArray.Add(Characters)
        End While
        SQLReaderCharacter.Close()
        For Each item In CharacterArray
            Dim newitem As String
            newitem = item.name + " - " + item.server
            CharacterSelector.Items.Add(newitem)
        Next
        If CharacterSelector.Items.Count > 0 Then
            CharacterSelector.SelectedIndex = 0
        End If
        SQLcommand.CommandText = "Select * from Dictionary WHERE IsRaid='True'"
        Dim SQLReaderRaids As SQLiteDataReader = SQLcommand.ExecuteReader()
        While SQLReaderRaids.Read()
            Dim raid As New Label
            Dim labelmargin As Padding = New Padding(3)

            raid.Name = SQLReaderRaids("UIObject")
            raid.Text = SQLReaderRaids("Translation")
            raid.ForeColor = Color.Lime
            raid.AutoSize = True
            raid.Margin = labelmargin
            RaidPicker.Items.Add(SQLReaderRaids("Translation"))
            FlowLayoutPanel1.Controls.Add(raid)

            RaidLabels(i) = raid
            i = i + 1
        End While
        SQLconnect.Close()
        SQLconnect.Dispose()
        LoadStatus()


    End Sub
#End Region
#Region "Support Functions"
    ''' <summary>
    ''' Find the upcoming thursday for resetting instances
    ''' dt is a date and time object
    ''' </summary>
    ''' <returns>dt</returns>
    ''' <remarks></remarks>
    Private Function NextThursday() As DateTime
        Dim dt As DateTime = DateTime.Today
        Dim datediff As TimeSpan
        datediff = DateAndTime.Now.Date - Date.FromOADate(0).Date
        dt = Date.FromOADate(datediff.Days + 0.291666666)
        If dt.DayOfWeek = DayOfWeek.Thursday Then

            dt = dt.AddDays(7)

        Else
            While dt.DayOfWeek <> DayOfWeek.Thursday

                dt = dt.AddDays(1)
            End While
        End If

        Return dt
    End Function
    ''' <summary>
    ''' Searches the array "RaidLabels" for an item that matches the string value passed in.
    ''' This function is used to search for the raid names to update the status.
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns>item as a label</returns>
    ''' <remarks></remarks>
    Private Function FindItem(ByVal SearchString As String)
        Try
            For Each item In RaidLabels
                If item Is Nothing Then
                    Return Nothing
                ElseIf item.Name = SearchString Then
                    Return item
                End If
            Next
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
#Region "Interface Actions"
    Private Sub cmdCompleteAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompleteAll.Click, menuCompleteAll.Click
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        Try


            SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
            SQLconnect.Open()
            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + NextThursday() + "' WHERE CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            SQLcommand.ExecuteNonQuery()
            SQLcommand.Dispose()
            SQLconnect.Close()
            SQLconnect.Dispose()
        Catch ex As Exception
            If CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim = "" Then
                MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            SQLconnect.Close()
            SQLconnect.Dispose()
        End Try
        LoadStatus()

    End Sub
    Private Sub CharacterSelector_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CharacterSelector.SelectedIndexChanged
        CurrentCharacter = CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim


        'LoadStatus()
    End Sub
    Private Sub cmdComplete_Click(sender As System.Object, e As System.EventArgs) Handles cmdComplete.Click, CmdNotComplete.Click
        Dim RaidName As String
        '	Dim RaidLabel As Label
        Dim SQLOutput As String = ""
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        'Insert Record into Foo
        'Update Last Created Record in Foo
        Try
            If RaidPicker.SelectedItem.ToString.Contains("'") Then
                RaidName = RaidPicker.SelectedItem.ToString.Replace("'", "''")
            Else
                RaidName = RaidPicker.SelectedItem.ToString
            End If
        Catch
            MessageBox.Show("Please select an item from the drop down menu first.")
            Return
        End Try

        SQLcommand.CommandText = "Select Dictionary.UIObject from Dictionary WHERE Translation='" + RaidName + "'"

        Dim UIObjectReader As SQLiteDataReader = SQLcommand.ExecuteReader()
        While UIObjectReader.Read()
            SQLOutput = UIObjectReader("UIObject")
        End While
        SQLcommand.Dispose()
        SQLconnect.Close()
        Dim FoundLabel As Label
        FoundLabel = FindItem(SQLOutput)
        If FoundLabel Is Nothing Then
            Exit Sub
        End If
        If sender Is cmdComplete Then
            SetComplete(FoundLabel)
        Else
            SetInComplete(FoundLabel)
        End If

    End Sub

#End Region
#Region "Menu"
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub AddRaidToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddRaidToolStripMenuItem.Click
        'Add Code to add a new raid to database.
    End Sub
    Private Sub AddCharacterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddCharacterMenu.Click, cmdAddCharacter.Click
        Dim ServerInput
        Dim NameInput = InputBox("Enter your characters name.", "Character Name")
        If NameInput IsNot "" Then
            ServerInput = InputBox("Enter your characters server.", "Server Name")
        Else
            Return
        End If
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand

        SQLcommand.CommandText = "INSERT INTO Characters ('CharacterName','Server') VALUES('" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()

        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','The Siege of Gondamon','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Trouble in Tuckborough','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Stand at Amon Sûl','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Attack at Dawn','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','LabelThievery','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Defence of the Prancing Pony','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','The Ford of Bruinen','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','The Icy Crevasse','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Survival - Barrow-downs','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Battle of the Deep-way','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Battle of the Way of Smiths','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Battle of the Twenty-first Hall','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Strike Against Dannenglor','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Protectors of Thangúlhad','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Breaching the Necromancers Gate','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Assault on the Ringwraiths Lair','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','The Battle in the Tower','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Rescue in Nûrz Gâshu','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Draigoch the Red','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Helegrod: Spider Wing','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Helegrod: Giant Wing','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Helegrod: Drake Wing','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Helegrod: Dragon Wing','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "INSERT INTO Raids ('DayComplete','RaidName','CharacterName','Server') VALUES ('1/1/1990','Thievery and Mischief','" + NameInput + "','" + ServerInput + "')"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.Dispose()
        SQLconnect.Close()
        SQLconnect.Dispose()
        Me.Form1_Load(Me, e)
    End Sub
    Private Sub DeleteCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles DeleteCharacterMenu.Click, cmdDeleteCharacter.Click
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        Try
            SQLcommand.CommandText = "Delete FROM Raids WHERE CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            SQLcommand.ExecuteNonQuery()
            SQLcommand.CommandText = "Delete FROM Characters WHERE CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            SQLcommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CharacterSelector.Items.Remove(CharacterSelector.SelectedItem)
        Try
            If CharacterSelector.Items.Count > 0 Then
                CharacterSelector.SelectedIndex = 0
            Else
                CharacterSelector.Text = ""
            End If
        Catch ex As Exception

        End Try
        SQLcommand.Dispose()
        SQLconnect.Close()
        SQLconnect.Dispose()

        Me.Form1_Load(Me, e)
    End Sub
    Private Sub ResetCharacterMenu_Click(sender As System.Object, e As System.EventArgs) Handles menuResetCharacter.Click, cmdReset.Click
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        Try
            SQLcommand.CommandText = "UPDATE Raids SET DayComplete ='" + Date.Today + "' WHERE CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            SQLcommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Please select a character in the drop down list first.", "No Character Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        SQLcommand.Dispose()
        SQLconnect.Close()

        Me.Form1_Load(Me, e)
    End Sub
    Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupportToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://shatteredparadigm.com/?page_id=2")
    End Sub
    Private Sub AboutToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
#End Region
#Region "Status Changes"
    Private Sub SetComplete(ByVal LabelName As Label)


        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"

        SQLcommand = SQLconnect.CreateCommand
        Dim mThursday As DateTime = NextThursday()
        mThursday.AddHours(7)

        Try
            SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + mThursday + "' WHERE RaidName = '" + LabelName.Name + "' AND CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            SQLconnect.Open()
            SQLcommand.ExecuteNonQuery()
            SQLcommand.Dispose()
            SQLconnect.Close()
            LabelName.ForeColor = Color.Red
        Catch ex As Exception
            If CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim = "" Then
                MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            SQLconnect.Close()
            SQLconnect.Dispose()
        End Try


        SQLconnect.Dispose()
    End Sub
    Private Sub SetInComplete(ByVal LabelName As Label)
        Dim SQLconnect As New SQLite.SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        'SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        'Insert Record into Foo
        'Update Last Created Record in Foo
        Try
            SQLcommand.CommandText = "UPDATE Raids SET DayComplete = '" + Date.Today() + "' WHERE RaidName = '" + LabelName.Name + "' AND CharacterName = '" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"
            'Uncomment this to be able to insert Name fields in to the datbase.
            'SQLcommand.CommandText = "INSERT INTO Raids ('Name','CharacterName') VALUES('" + LabelName.Name + "','" + ComboBox1.SelectedItem.ToString.Split("-")(0).Trim + "'"
            SQLcommand.ExecuteNonQuery()
            SQLcommand.Dispose()
            LabelName.ForeColor = Color.Lime
        Catch ex As Exception
            MessageBox.Show("Please create a character under File -> Add character first.", "No Characters Found!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SQLconnect.Close()
            SQLconnect.Dispose()
            SQLconnect.Shutdown()
        End Try

        SQLconnect.Close()
        SQLconnect.Dispose()
        SQLconnect.Shutdown()
    End Sub
    Private Sub LoadStatus()
        Dim Raid(30) As Raid
        If CurrentCharacter IsNot vbNullString Then
            Dim SQLconnect As New SQLite.SQLiteConnection()
            Dim SQLcommand As SQLiteCommand
            SQLconnect.ConnectionString = "Data Source=.\Database\LotroRaids.sqlite;"
            Try
                SQLconnect.Open()
            Catch ex As Exception

            End Try
            SQLcommand = SQLconnect.CreateCommand
            Try
                SQLcommand.CommandText = "Select * from Raids WHERE CharacterName ='" + CharacterSelector.SelectedItem.ToString.Split("-")(0).Trim + "' AND Server ='" + CharacterSelector.SelectedItem.ToString.Split("-")(1).Trim + "'"


                Dim SQLreaderRaids As SQLiteDataReader = SQLcommand.ExecuteReader()

                Dim i = 0
                While SQLreaderRaids.Read()
                    Raid(i).DayCompleted = SQLreaderRaids("DayComplete")
                    Raid(i).RaidName = SQLreaderRaids("RaidName")

                    If Date.Now.ToUniversalTime < Raid(i).DayCompleted Then
                        For Each item In RaidLabels
                            If item Is Nothing Then

                            ElseIf item.Name = Raid(i).RaidName Then
                                item.ForeColor = Color.Red
                            End If

                        Next
                        'Select Case Raid(i).RaidName
                        '    Case "Label21st"
                        '        Label21st.ForeColor = Color.Red

                        '    Case "LabelAmonSul"
                        '        LabelAmonSul.ForeColor = Color.Red

                        '    Case "LabelAttackAtDawn"
                        '        LabelAttackAtDawn.ForeColor = Color.Red

                        '    Case "LabelBarrows"
                        '        LabelBarrows.ForeColor = Color.Red

                        '    Case "LabelBruinen"
                        '        LabelBruinen.ForeColor = Color.Red

                        '    Case "LabelDannenglor"
                        '        LabelDannenglor.ForeColor = Color.Red

                        '    Case "LabelDeepWay"
                        '        LabelDeepWay.ForeColor = Color.Red

                        '    Case "LabelDraigoch"
                        '        LabelDraigoch.ForeColor = Color.Red

                        '    Case "LabelGondamon"
                        '        LabelGondamon.ForeColor = Color.Red

                        '    Case "LabelIcy"
                        '        LabelIcy.ForeColor = Color.Red

                        '    Case "LabelNecromancer"
                        '        LabelNecromancer.ForeColor = Color.Red

                        '    Case "LabelPony"
                        '        LabelPony.ForeColor = Color.Red

                        '    Case "LabelRescue"
                        '        LabelRescue.ForeColor = Color.Red

                        '    Case "LabelRingwraith"
                        '        LabelRingwraith.ForeColor = Color.Red

                        '    Case "LabelSmiths"
                        '        LabelSmiths.ForeColor = Color.Red

                        '    Case "LabelThangulhad"
                        '        LabelThangulhad.ForeColor = Color.Red

                        '    Case "LabelThievery"
                        '        LabelThievery.ForeColor = Color.Red

                        '    Case "LabelTowerBattle"
                        '        LabelTowerBattle.ForeColor = Color.Red

                        '    Case "LabelTuckborough"
                        '        LabelTuckborough.ForeColor = Color.Red

                        '    Case "LabelSpiderWing"
                        '        LabelSpiderWing.ForeColor = Color.Red

                        '    Case "LabelGiantWing"
                        '        LabelGiantWing.ForeColor = Color.Red

                        '    Case "LabelDrakeWing"
                        '        LabelDrakeWing.ForeColor = Color.Red

                        '    Case "LabelDragonWing"
                        '        LabelDragonWing.ForeColor = Color.Red

                        'End Select
                    End If

                    i += 1
                End While
            Catch ex As Exception

            End Try
            SQLcommand.Dispose()
            SQLconnect.Close()
        End If

    End Sub
#End Region



End Class
